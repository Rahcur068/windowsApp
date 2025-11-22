using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WaterBillingManagement
{
    public partial class Consumers : Form
    {
        private readonly string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\codew\OneDrive\Documents\WaterBillingDb.mdf;Integrated Security=True;Encrypt=False;Connect Timeout=30";
        int Key = 0; // Stores selected consumer's ID (CId)

        public Consumers()
        {
            InitializeComponent();
            PopulateConsumersGridView(); // Load data into grid when the form starts
        }

        // --- Helper Methods ---

        private void ClearConsumerFields()
        {
            CNameTb.Text = "";
            CAddTb.Text = "";
            CPhoneTb.Text = "";
            CCatTb.SelectedIndex = -1; // <--- Corrected: Clear ComboBox selection
            CCatTb.Text = ""; // <--- Corrected: Also clear text if user typed
            CJDate.Value = DateTime.Now; // Reset to current date
            CRate.Text = ""; // <--- CORRECTED: CRateTb
            Key = 0; // Reset Key

            // Clear selection in the DataGridView
            if (ConsumerDGV.SelectedRows.Count > 0)
            {
                ConsumerDGV.ClearSelection();
            }
        }

        private void PopulateConsumersGridView()
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    string query = "SELECT CId, CName, CAddress, CPhone, CCategory, CjDate, CRate FROM ConsumerTbl";
                    SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ConsumerDGV.DataSource = dt;

                    ConsumerDGV.ClearSelection();
                    if (ConsumerDGV.Rows.Count > 0)
                    {
                        ConsumerDGV.Rows[0].Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading consumers: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Event Handlers ---

        // Save (Add) Button Click Event
       

        // Edit (Update) Button Click Event
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0) // No consumer selected for edit
            {
                MessageBox.Show("Select a consumer to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Input validation
            if (string.IsNullOrWhiteSpace(CNameTb.Text) ||
                string.IsNullOrWhiteSpace(CAddTb.Text) ||
                string.IsNullOrWhiteSpace(CPhoneTb.Text) ||
                string.IsNullOrWhiteSpace(CRate.Text) || // <--- CORRECTED: CRateTb
                CCatTb.SelectedIndex == -1) // <--- Corrected: Check ComboBox selection
            {
                MessageBox.Show("Missing updated input fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Rate is a number
            if (!int.TryParse(CRate.Text, out int rateValue)) // <--- CORRECTED: CRateTb
            {
                MessageBox.Show("Rate must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE ConsumerTbl SET CName=@CN, CAddress=@CA, CPhone=@CP, CCategory=@CCat, CjDate=@CJD, CRate=@CR WHERE CId=@CKey", Con);

                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CCat", CCatTb.SelectedItem.ToString()); // <--- Corrected: Get value from ComboBox
                    cmd.Parameters.AddWithValue("@CJD", CJDate.Value.Date);
                    cmd.Parameters.AddWithValue("@CR", rateValue); // <--- CORRECTED: CRateTb
                    cmd.Parameters.AddWithValue("@CKey", Key);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Consumer Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearConsumerFields();
                    PopulateConsumersGridView(); // Refresh grid immediately
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("An error occurred during update: " + Ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Delete Button Click Event
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0) // No consumer selected for delete
            {
                MessageBox.Show("Select a consumer to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM ConsumerTbl WHERE CId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Consumer Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearConsumerFields();
                    PopulateConsumersGridView(); // Refresh grid immediately
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("An error occurred during delete: " + Ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- DataGridView CellContentClick Event Handler ---
        private void ConsumerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < ConsumerDGV.Rows.Count)
            {
                ConsumerDGV.ClearSelection();
                ConsumerDGV.Rows[e.RowIndex].Selected = true;

                DataGridViewRow row = ConsumerDGV.Rows[e.RowIndex];

                if (row.Cells["CId"].Value != DBNull.Value && row.Cells["CId"].Value != null)
                {
                    Key = Convert.ToInt32(row.Cells["CId"].Value);

                    CNameTb.Text = row.Cells["CName"].Value?.ToString() ?? string.Empty;
                    CAddTb.Text = row.Cells["CAddress"].Value?.ToString() ?? string.Empty;
                    CPhoneTb.Text = row.Cells["CPhone"].Value?.ToString() ?? string.Empty;

                    // <--- Corrected: Populate ComboBox selection
                    string categoryValue = row.Cells["CCategory"].Value?.ToString() ?? string.Empty;
                    int index = CCatTb.FindStringExact(categoryValue);
                    if (index != -1)
                    {
                        CCatTb.SelectedIndex = index;
                    }
                    else
                    {
                        CCatTb.Text = categoryValue; // Fallback if category not in dropdown list
                    }

                    if (row.Cells["CjDate"].Value != DBNull.Value && row.Cells["CjDate"].Value != null)
                    {
                        CJDate.Value = Convert.ToDateTime(row.Cells["CjDate"].Value);
                    }
                    else
                    {
                        CJDate.Value = DateTime.Now;
                    }

                    CRate.Text = row.Cells["CRate"].Value?.ToString() ?? string.Empty; // <--- CORRECTED: CRateTb
                }
                else
                {
                    ClearConsumerFields();
                }
            }
            else
            {
                ClearConsumerFields();
            }
        }

        // --- NEW: CCatCb SelectedIndexChanged Event Handler ---
       

        // Unused event handlers (can be deleted if no specific logic is needed there)
        private void label6_Click(object sender, EventArgs e) { }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) { }
        private void Consumers_Load(object sender, EventArgs e) { } // Keep if you need for future form load logic

        private void CCatTb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (CCatTb.SelectedItem != null)
            {
                string selectedCategory = CCatTb.SelectedItem.ToString();

                switch (selectedCategory)
                {
                    case "Family":
                        CRate.Text = "70";
                        break;
                    case "Commercial":
                        CRate.Text = "95";
                        break;
                    case "Business":
                        CRate.Text = "120";
                        break;
                    default:
                        CRate.Text = ""; // Clear the rate if no matching category is found
                        break;
                }
            }
            else
            {
                CRate.Text = ""; // Clear the rate if nothing is selected
            }
        }

        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(CNameTb.Text) ||
                string.IsNullOrWhiteSpace(CAddTb.Text) ||
                string.IsNullOrWhiteSpace(CPhoneTb.Text) ||
                string.IsNullOrWhiteSpace(CRate.Text) || // <--- CORRECTED: CRateTb
                CCatTb.SelectedIndex == -1) // <--- Corrected: Check ComboBox selection
            {
                MessageBox.Show("Missing the input fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution if validation fails
            }

            // Validate Rate is a number
            if (!int.TryParse(CRate.Text, out int rateValue)) // <--- CORRECTED: CRateTb
            {
                MessageBox.Show("Rate must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO ConsumerTbl(CName, CAddress, CPhone, CCategory, CjDate, CRate) " +
                        "VALUES(@CN, @CA, @CP, @CCat, @CJD, @CR)", Con);

                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CCat", CCatTb.SelectedItem.ToString()); // <--- Corrected: Get value from ComboBox
                    cmd.Parameters.AddWithValue("@CJD", CJDate.Value.Date);
                    cmd.Parameters.AddWithValue("@CR", rateValue);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Consumer Added Successfully 👍", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearConsumerFields();
                    PopulateConsumersGridView(); // Refresh grid immediately
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("An error occurred during save: " + Ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Agents agents = new Agents();
            agents.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();  
            dashboard.Show();
            this.Hide();
        }
    }
}