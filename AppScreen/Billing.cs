using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;    // For Document, Paragraph, Font, BaseColor, etc.
using iTextSharp.text.pdf; // For PdfWriter, PdfPTable, PdfPCell, BaseFont, etc.

namespace WaterBillingManagement
{
    public partial class Billing : Form
    {
        private readonly string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\codew\OneDrive\Documents\WaterBillingDb.mdf;Integrated Security=True;Encrypt=False;Connect Timeout=30";

        int Key = 0;
        string ConsumerAgent = ""; // To store the agent name fetched from ConsumerTbl

        // Uncomment these if you add TextBoxes to your form to display calculated Tax Amount and Total Amount live
        // public TextBox TaxAmountDisplayTb; // e.g., to show "12.50"
        // public TextBox TotalAmountDisplayTb; // e.g., to show "262.50"


        public Billing()
        {
            InitializeComponent();
            GetCons();
            ShowBills();
            AgentsLbl.Text = Login.User; // Assuming Login.User is accessible
        }

        // --- MODIFIED METHOD: GetCalculatedBillValues ---
        // This method will now return a tuple with calculated values (Base, Tax Amount, Total Amount)
        // It's separated from UI updates to make it reusable and testable.
        private (double baseAmount, double calculatedTax, double calculatedTotal) GetCalculatedBillValues()
        {
            // Default return in case of invalid input
            double baseAmount = 0.0;
            double calculatedTax = 0.0;
            double calculatedTotal = 0.0;

            // 1. Validate and parse Rate
            if (!int.TryParse(RateTb.Text, out int ratePerDM3) || ratePerDM3 < 0)
            {
                // Optionally display an error message for the user if this is called directly from a UI event
                // MessageBox.Show("Invalid Rate per DM3 entered. Please enter a non-negative whole number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return (baseAmount, calculatedTax, calculatedTotal);
            }

            // 2. Validate and parse Consumption
            if (!int.TryParse(ConsTb.Text, out int waterConsumption) || waterConsumption < 0)
            {
                // MessageBox.Show("Invalid Water Consumption entered. Please enter a non-negative whole number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return (baseAmount, calculatedTax, calculatedTotal);
            }

            // 3. Validate and parse Tax Percentage (e.g., "5" for 5%)
            if (!double.TryParse(TaxTb.Text, out double taxPercentageInput) || taxPercentageInput < 0)
            {
                // You might want to cap it at 100 or show a warning for very high percentages if appropriate
                // MessageBox.Show("Invalid Tax Percentage. Enter a non-negative number (e.g., 5 for 5%, 12.5 for 12.5%).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return (baseAmount, calculatedTax, calculatedTotal);
            }

            // Perform calculations
            baseAmount = (double)waterConsumption * ratePerDM3;
            double taxRateDecimal = taxPercentageInput / 100.0; // Convert 5 (for 5%) to 0.05
            calculatedTax = baseAmount * taxRateDecimal;
            calculatedTotal = baseAmount + calculatedTax;

            // Uncomment these lines if you have dedicated TextBoxes on your form to display these live
            // if (TaxAmountDisplayTb != null) TaxAmountDisplayTb.Text = calculatedTax.ToString("F2");
            // if (TotalAmountDisplayTb != null) TotalAmountDisplayTb.Text = calculatedTotal.ToString("F2");

            return (baseAmount, calculatedTax, calculatedTotal);
        }

        // Helper method to trigger calculation and update UI (if display textboxes exist)
        private void UpdateCalculatedDisplays()
        {
            // Calling GetCalculatedBillValues here populates the display TextBoxes if they exist and are uncommented.
            // Even if they don't exist, this call validates inputs and provides internal calculated values.
            GetCalculatedBillValues();
        }

        private void ShowBills()
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    String Query = "SELECT * FROM BillTbl";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                    SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    BillingDGV.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bills: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetCons()
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CId FROM ConsumerTbl", Con);
                    SqlDataReader Rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CId", typeof(int));
                    dt.Load(Rdr);
                    CIdCb.ValueMember = "CId";
                    CIdCb.DataSource = dt;
                    Rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching consumer IDs: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetConsRate()
        {
            if (CIdCb.SelectedValue != null && CIdCb.SelectedValue != DBNull.Value)
            {
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    try
                    {
                        Con.Open();
                        String Query = "SELECT CRate, CName FROM ConsumerTbl WHERE CId=@CId";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.Parameters.AddWithValue("@CId", Convert.ToInt32(CIdCb.SelectedValue));

                        SqlDataReader Rdr = cmd.ExecuteReader();
                        if (Rdr.Read())
                        {
                            RateTb.Text = Rdr["CRate"].ToString();
                            ConsumerAgent = Rdr["CName"].ToString();
                        }
                        else
                        {
                            RateTb.Text = "";
                            ConsumerAgent = "";
                        }
                        Rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fetching consumer rate or agent: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RateTb.Text = "";
                ConsumerAgent = "";
            }
            UpdateCalculatedDisplays(); // Call after rate is fetched to update any display fields
        }

        private void Clear()
        {
            ConsTb.Text = "";
            RateTb.Text = "";
            TaxTb.Text = "";
            // Uncomment if you have display textboxes
            // if (TaxAmountDisplayTb != null) TaxAmountDisplayTb.Text = "";
            // if (TotalAmountDisplayTb != null) TotalAmountDisplayTb.Text = "";
            CIdCb.SelectedIndex = -1;
            BPeriod.Value = DateTime.Now;
            Key = 0;
            ConsumerAgent = "";
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            // Initial load operations are in the constructor
        }

        private void CIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetConsRate();
        }

        // --- Event Handlers to trigger calculations on text changes ---
        private void ConsTb_TextChanged(object sender, EventArgs e)
        {
            UpdateCalculatedDisplays();
        }

        private void TaxTb_TextChanged(object sender, EventArgs e)
        {
            UpdateCalculatedDisplays();
        }
        // --- END Event Handlers ---

        private void BillingDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = BillingDGV.Rows[e.RowIndex];

                Key = Convert.ToInt32(row.Cells["BNum"].Value);
                CIdCb.SelectedValue = Convert.ToInt32(row.Cells["CId"].Value);

                if (DateTime.TryParse(row.Cells["BPeriod"].Value.ToString(), out DateTime billDate))
                {
                    BPeriod.Value = billDate;
                }
                else
                {
                    BPeriod.Value = DateTime.Now;
                }

                ConsTb.Text = row.Cells["Consuption"].Value.ToString();
                RateTb.Text = row.Cells["Rate"].Value.ToString();
                // When loading from DB, 'Tax' column can store percentage or amount.
                // Assuming it stores the percentage for the UI to show.
                TaxTb.Text = row.Cells["Tax"].Value.ToString();

                if (row.Cells["Agent"].Value != null)
                {
                    ConsumerAgent = row.Cells["Agent"].Value.ToString();
                }
                else
                {
                    ConsumerAgent = "";
                }
                UpdateCalculatedDisplays(); // Call after populating all fields from DGV
            }
        }

        // --- MODIFIED METHOD: SaveBtn_Click ---
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CIdCb.SelectedValue == null || CIdCb.SelectedValue == DBNull.Value || string.IsNullOrWhiteSpace(ConsTb.Text) || string.IsNullOrWhiteSpace(RateTb.Text) || string.IsNullOrWhiteSpace(TaxTb.Text) || string.IsNullOrWhiteSpace(ConsumerAgent))
            {
                MessageBox.Show("Missing Information! Please fill all fields or select a valid Consumer ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the calculated values from the robust calculation method
            var (baseAmount, calculatedTax, calculatedTotal) = GetCalculatedBillValues();

            // Validate that calculations were successful and not due to bad input
            if (calculatedTotal == 0.0 && (string.IsNullOrWhiteSpace(ConsTb.Text) || string.IsNullOrWhiteSpace(RateTb.Text) || string.IsNullOrWhiteSpace(TaxTb.Text)))
            {
                MessageBox.Show("Calculation error due to invalid input. Please check Consumption, Rate, and Tax fields.", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    string Period = BPeriod.Value.ToString("MM/yyyy");

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO BillTbl (CId, Agent, BPeriod, Consuption, Rate, Tax, Total) VALUES (@CId, @Agent, @BPeriod, @Consuption, @Rate, @Tax, @Total)", Con);
                    cmd.Parameters.AddWithValue("@CId", Convert.ToInt32(CIdCb.SelectedValue));
                    cmd.Parameters.AddWithValue("@Agent", ConsumerAgent);
                    cmd.Parameters.AddWithValue("@BPeriod", Period);
                    cmd.Parameters.AddWithValue("@Consuption", Convert.ToInt32(ConsTb.Text)); // Storing raw consumption
                    cmd.Parameters.AddWithValue("@Rate", Convert.ToInt32(RateTb.Text));       // Storing raw rate

                    // IMPORTANT:
                    // If your DB column "Tax" is meant to store the *percentage* (e.g., 5 for 5%), use TaxTb.Text.
                    // If it's meant to store the *calculated tax amount*, you MUST change its DB type to DECIMAL(18,2) or FLOAT
                    // I'm assuming it stores the percentage here.
                    cmd.Parameters.AddWithValue("@Tax", Convert.ToDouble(TaxTb.Text)); // Store the percentage itself as double in DB

                    cmd.Parameters.AddWithValue("@Total", Math.Round(calculatedTotal, 2));    // Store calculated total, rounded to 2 decimal places
                    // IMPORTANT: If your DB column "Total" is INT, you need to change it to DECIMAL(18,2) or FLOAT
                    // If you MUST store as INT (losing precision), uncomment the line below:
                    // cmd.Parameters.AddWithValue("@Total", Convert.ToInt32(Math.Round(calculatedTotal)));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowBills();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving bill: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- MODIFIED METHOD: EditBtn_Click ---
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Please select a Bill to Update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CIdCb.SelectedValue == null || CIdCb.SelectedValue == DBNull.Value || string.IsNullOrWhiteSpace(ConsTb.Text) || string.IsNullOrWhiteSpace(RateTb.Text) || string.IsNullOrWhiteSpace(TaxTb.Text) || string.IsNullOrWhiteSpace(ConsumerAgent))
            {
                MessageBox.Show("Missing Information! Please fill all fields or select a valid Consumer ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the calculated values from the robust calculation method
            var (baseAmount, calculatedTax, calculatedTotal) = GetCalculatedBillValues();

            // Validate that calculations were successful and not due to bad input
            if (calculatedTotal == 0.0 && (string.IsNullOrWhiteSpace(ConsTb.Text) || string.IsNullOrWhiteSpace(RateTb.Text) || string.IsNullOrWhiteSpace(TaxTb.Text)))
            {
                MessageBox.Show("Calculation error due to invalid input. Please check Consumption, Rate, and Tax fields.", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    string Period = BPeriod.Value.ToString("MM/yyyy");

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE BillTbl SET CId=@CId, Agent=@Agent, BPeriod=@BPeriod, Consuption=@Consuption, Rate=@Rate, Tax=@Tax, Total=@Total WHERE BNum=@Key", Con);
                    cmd.Parameters.AddWithValue("@CId", Convert.ToInt32(CIdCb.SelectedValue));
                    cmd.Parameters.AddWithValue("@Agent", ConsumerAgent);
                    cmd.Parameters.AddWithValue("@BPeriod", Period);
                    cmd.Parameters.AddWithValue("@Consuption", Convert.ToInt32(ConsTb.Text));
                    cmd.Parameters.AddWithValue("@Rate", Convert.ToInt32(RateTb.Text));

                    // Same considerations for @Tax and @Total as in SaveBtn_Click
                    cmd.Parameters.AddWithValue("@Tax", Convert.ToDouble(TaxTb.Text)); // Store the percentage itself as double

                    cmd.Parameters.AddWithValue("@Total", Math.Round(calculatedTotal, 2)); // Store calculated total, rounded to 2 decimal places
                    // If you MUST store as INT (losing precision), uncomment the line below:
                    // cmd.Parameters.AddWithValue("@Total", Convert.ToInt32(Math.Round(calculatedTotal)));
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowBills();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating bill: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Please select a Bill to Delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM BillTbl WHERE BNum=@Key", Con);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowBills();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting bill: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Consumers consumers = new Consumers();
            consumers.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Agents agents = new Agents();
            agents.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e) //logout
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?", // Message to display
                "Confirm Logout",                    // Title of the dialog box
                MessageBoxButtons.YesNo,             // Show Yes and No buttons
                MessageBoxIcon.Question);            // Show a question icon

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // User confirmed logout, proceed to show login form and hide current form
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            // If result is DialogResult.No, do nothing (stay on the current form)
        }

        // --- MODIFIED METHOD: PrintPdfBtn_Click ---
        private void PrintPdfBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CIdCb.SelectedValue == null || CIdCb.SelectedValue == DBNull.Value ||
                    string.IsNullOrWhiteSpace(ConsTb.Text) ||
                    string.IsNullOrWhiteSpace(RateTb.Text) ||
                    string.IsNullOrWhiteSpace(TaxTb.Text))
                {
                    MessageBox.Show("Select a bill record first or ensure all fields are filled before printing.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the calculated values from the robust calculation method
                var (baseAmount, calculatedTaxAmount, calculatedTotalAmount) = GetCalculatedBillValues();
                double taxPercentageInput = Convert.ToDouble(TaxTb.Text); // Get the raw percentage input for display

                // Validate that calculations were successful
                if (calculatedTotalAmount == 0.0 && (baseAmount == 0.0 || calculatedTaxAmount == 0.0))
                {
                    MessageBox.Show("PDF cannot be generated due to invalid calculation results. Please check input values.", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveDialog.Title = "Save Water Bill";
                saveDialog.FileName = $"WaterBill_{CIdCb.SelectedValue}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"; // More precise filename

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                string pdfPath = saveDialog.FileName;

                Document doc = new Document(PageSize.A4, 45, 45, 45, 45);

                PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream(pdfPath, System.IO.FileMode.Create));

                doc.Open();

                // ----------------------------------------------------
                //           🔥 WATERMARK HERE 🔥
                // ----------------------------------------------------
                PdfContentByte watermark = writer.DirectContentUnder;
                BaseFont wmFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

                watermark.SaveState();

                PdfGState gState = new PdfGState();
                gState.FillOpacity = 0.15f;    // light watermark
                watermark.SetGState(gState);

                watermark.BeginText();
                watermark.SetFontAndSize(wmFont, 80);
                watermark.SetColorFill(BaseColor.LIGHT_GRAY);

                float pageWidth = doc.PageSize.Width;
                float pageHeight = doc.PageSize.Height;

                watermark.ShowTextAligned(
                    Element.ALIGN_CENTER,
                    "WDC * WDC",
                    pageWidth / 2,
                    pageHeight / 2,
                    45
                );

                watermark.EndText();
                watermark.RestoreState();
                // ----------------------------------------------------
                //            🔥 END OF WATERMARK 🔥
                // ----------------------------------------------------


                // ---------- THEME COLORS ----------
                BaseColor WaterBlue = new BaseColor(0, 122, 204);
                BaseColor LightBlue = new BaseColor(230, 245, 255);

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                Font normalFont = new Font(bf, 11);
                Font boldFont = new Font(bf, 13, 1);
                Font titleFont = new Font(bf, 18, 1);
                Font footerFont = new Font(bf, 10);

                // ---------- HEADER ----------
                PdfPTable titleTable = new PdfPTable(1);
                titleTable.WidthPercentage = 100;

                PdfPCell titleCell = new PdfPCell(new Phrase("WATER DISTRIBUTION CORPORATION\nWATER BILLING RECEIPT", titleFont))
                {
                    BackgroundColor = WaterBlue,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingTop = 20,
                    PaddingBottom = 20,
                    Border = Rectangle.NO_BORDER
                };

                titleTable.AddCell(titleCell);
                doc.Add(titleTable);
                doc.Add(new Paragraph("\n"));

                // ---------- CONSUMER INFO ----------
                doc.Add(new Paragraph("Consumer Information", boldFont));

                PdfPTable infoTable = new PdfPTable(2);
                infoTable.WidthPercentage = 100;

                void Row(string label, string val)
                {
                    PdfPCell c1 = new PdfPCell(new Phrase(label, normalFont));
                    PdfPCell c2 = new PdfPCell(new Phrase(val, normalFont));

                    c1.BackgroundColor = LightBlue;
                    c2.BackgroundColor = LightBlue;

                    c1.Border = Rectangle.NO_BORDER;
                    c2.Border = Rectangle.NO_BORDER;

                    c1.Padding = 6;
                    c2.Padding = 6;

                    infoTable.AddCell(c1);
                    infoTable.AddCell(c2);
                }

                Row("Consumer ID:", CIdCb.SelectedValue.ToString());
                Row("Billing Period:", BPeriod.Value.ToString("MMMM yyyy"));
                Row("Agent:", ConsumerAgent);

                doc.Add(infoTable);
                doc.Add(new Paragraph("\n"));

                // ---------- BILLING BREAKDOWN ----------
                doc.Add(new Paragraph("Billing Breakdown", boldFont));

                PdfPTable billTable = new PdfPTable(2);
                billTable.WidthPercentage = 100;

                void BillRow(string label, string val)
                {
                    PdfPCell c1 = new PdfPCell(new Phrase(label, normalFont));
                    PdfPCell c2 = new PdfPCell(new Phrase(val, normalFont));

                    c1.Border = Rectangle.NO_BORDER;
                    c2.Border = Rectangle.NO_BORDER;

                    c1.Padding = 6;
                    c2.Padding = 6;

                    billTable.AddCell(c1);
                    billTable.AddCell(c2);
                }

                BillRow("Water Consumption (DM3):", ConsTb.Text);
                BillRow("Rate per DM3:", RateTb.Text);
                // Display the raw percentage input
                BillRow("Tax (%):", taxPercentageInput.ToString("F2")); // Display 5.00 for 5%, 12.50 for 12.5%
                // Display the calculated tax and total amounts
                BillRow("Tax Amount:", calculatedTaxAmount.ToString("F2"));
                BillRow("Total Amount:", calculatedTotalAmount.ToString("F2"));

                doc.Add(billTable);

                // ---------- FOOTER ----------
                doc.Add(new Paragraph(
                    "\nThank you for using our water services!",
                    footerFont
                ));

                doc.Add(new Paragraph(
                    "Generated on: " + DateTime.Now.ToString("dd MMM yyyy hh:mm tt"),
                    footerFont
                ));

                doc.Close();

                MessageBox.Show("PDF Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating PDF: " + ex.Message, "PDF Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}