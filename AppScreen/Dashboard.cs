using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterBillingManagement
{
    public partial class Dashboard : Form
    {
        // Use a single connection string variable
        private readonly string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\codew\OneDrive\Documents\WaterBillingDb.mdf;Integrated Security=True;Encrypt=False;Connect Timeout=30";

        public Dashboard()
        {
            InitializeComponent();
            // Call methods to display initial counts and sums when the form loads
            DisplayDashboardData();
        }

        // Centralized method to refresh all dashboard data
        private void DisplayDashboardData()
        {
            CountAgents();
            CountConsumers();
            SumAllBills(); // Renamed from SumBills to clarify it's total bills
            SumBillsByMonth(); // Call to display bills for the initially selected month
        }

        private void CountAgents()
        {
            using (SqlConnection Con = new SqlConnection(connectionString)) // Use 'using' statement
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM AgentTbl", Con);
                    // Use ExecuteScalar for single value retrieval, it's more efficient
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Assuming AgNumLbl is the label for Agents count
                        AgNumLbl.Text = result.ToString() + " Agents";
                    }
                    else
                    {
                        AgNumLbl.Text = "0 Agents";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error counting agents: " + ex.Message);
                    AgNumLbl.Text = "Error"; // Indicate an error on the UI
                }
            }
        }

        private void CountConsumers()
        {
            using (SqlConnection Con = new SqlConnection(connectionString)) // Use 'using' statement
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ConsumerTbl", Con);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Assuming ConsNumLbl is the label for Consumers count
                        ConsLbl.Text = result.ToString() + " Consumers";
                    }
                    else
                    {
                        ConsLbl.Text = "0 Consumers";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error counting consumers: " + ex.Message);
                    ConsLbl.Text = "Error"; // Indicate an error on the UI
                }
            }
        }

        private void SumAllBills() // Renamed for clarity
        {
            using (SqlConnection Con = new SqlConnection(connectionString)) // Use 'using' statement
            {
                try
                {
                    Con.Open();
                    // Corrected function name SUM(Total)
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(Total), 0) FROM BillTbl", Con);
                    object result = cmd.ExecuteScalar();

                    // ISNULL will return 0 if SUM is NULL, so direct conversion is safer
                    // Assuming BillsTotalLbl is the label for total bills
                    BillLbl.Text = "Rs " + Convert.ToDouble(result).ToString("N2"); // Format as currency
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error summing all bills: " + ex.Message);
                    BillLbl.Text = "Rs 0.00 (Error)"; // Indicate an error on the UI
                }
            }
        }

        private void SumBillsByMonth() // Refactored for BPeriod_ValueChanged and initial load
        {
            // Format the date from the BPeriod DateTimePicker to match "MM/yyyy"
            // This needs to match the format used when inserting into the BillTbl
            string billPeriodFormatted = BPeriod.Value.ToString("MM/yyyy");

            using (SqlConnection Con = new SqlConnection(connectionString)) // Use 'using' statement
            {
                try
                {
                    Con.Open();
                    // Corrected SUM function and used parameterized query for safety
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(Total), 0) FROM BillTbl WHERE BPeriod = @BPeriod", Con);
                    cmd.Parameters.AddWithValue("@BPeriod", billPeriodFormatted); // Pass the formatted string as parameter

                    object result = cmd.ExecuteScalar();

                    // Assuming BillMonthLbl is the label for bills by month
                    BillMonthLbl.Text = "Rs " + Convert.ToDouble(result).ToString("N2"); // Format as currency
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error summing bills by month: " + ex.Message);
                    BillMonthLbl.Text = "Rs 0.00 (Error)"; // Indicate an error on the UI
                }
            }
        }

        // Event handler for when the BPeriod DateTimePicker value changes
        private void BPeriod_ValueChanged(object sender, EventArgs e)
        {
            SumBillsByMonth(); // Recalculate and display bills for the new month
        }

        // Your other event handlers (if any)
        private void ConsLbl_Click(object sender, EventArgs e)
        {
            // You can add logic here if you want something to happen when this label is clicked
        }

        private void label3_Click(object sender, EventArgs e)//go to Billing page
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)//go to agents page
        {
            Agents obj = new Agents();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)//Go to consumer page
        {
            Consumers obj = new Consumers();    
            obj.Show();
            this.Hide();
        }
    }
}