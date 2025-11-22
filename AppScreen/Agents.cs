using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WaterBillingManagement
{
    public partial class Agents : Form
    {
        private readonly string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\codew\OneDrive\Documents\WaterBillingDb.mdf;Integrated Security=True;Encrypt=False;Connect Timeout=30";
        int Key = 0; // Stores selected consumer's ID (CId)

        public Agents()
        {
            InitializeComponent();
            PopulateAgentsGridView();

            // Ensure proper selection behavior
            AgentsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AgentsDGV.MultiSelect = false;
        }
                
        // ============================================================
        //  LOAD AGENTS INTO GRID
        // ============================================================
        private void PopulateAgentsGridView()
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    string query = "SELECT AgNum, AgName, AgPhone, AgAdd, AgPass FROM AgentTbl";
                    SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    AgentsDGV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading agents: " + ex.Message);
                }
            }
        }

        // ============================================================
        //  CLEAR INPUT FIELDS
        // ============================================================ 
        private void ClearAgentFields()
        {
            AgNameTb.Text = "";
            AgPhoneTb.Text = "";
            AgAddTb.Text = "";
            AgPassTb.Text = "";
            Key = 0;
        }

        // ============================================================
        //  FILL TEXTBOXES WHEN A ROW IS CLICKED
        // ============================================================
        


        // ============================================================
        //  SAVE NEW AGENT
        // ============================================================
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (AgNameTb.Text == "" || AgPhoneTb.Text == "" ||
                AgAddTb.Text == "" || AgPassTb.Text == "")
            {
                MessageBox.Show("Missing input fields");
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO AgentTbl (AgName, AgPhone, AgAdd, AgPass) VALUES (@N, @P, @A, @PW)",
                        Con);

                    cmd.Parameters.AddWithValue("@N", AgNameTb.Text);
                    cmd.Parameters.AddWithValue("@P", AgPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@A", AgAddTb.Text);
                    cmd.Parameters.AddWithValue("@PW", AgPassTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Added Successfully!");

                    ClearAgentFields();
                    PopulateAgentsGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving: " + ex.Message);
                }
            }
        }

        // ============================================================
        //  UPDATE AGENT
        // ============================================================
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select an agent first.");
                return;
            }

            if (AgNameTb.Text == "" || AgPhoneTb.Text == "" ||
                AgAddTb.Text == "" || AgPassTb.Text == "")
            {
                MessageBox.Show("Missing updated fields");
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE AgentTbl SET AgName=@N, AgPhone=@P, AgAdd=@A, AgPass=@PW WHERE AgNum=@K",
                        Con);

                    cmd.Parameters.AddWithValue("@N", AgNameTb.Text);
                    cmd.Parameters.AddWithValue("@P", AgPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@A", AgAddTb.Text);
                    cmd.Parameters.AddWithValue("@PW", AgPassTb.Text);
                    cmd.Parameters.AddWithValue("@K", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Updated Successfully!");

                    ClearAgentFields();
                    PopulateAgentsGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating: " + ex.Message);
                }
            }
        }

        // ============================================================
        //  DELETE AGENT
        // ============================================================
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select an agent first.");
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM AgentTbl WHERE AgNum=@K",
                        Con);

                    cmd.Parameters.AddWithValue("@K", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Deleted Successfully!");

                    ClearAgentFields();
                    PopulateAgentsGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message);
                }
            }
        }

        private void AgentsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (AgentsDGV.SelectedRows.Count > 0)
            {
                AgNameTb.Text = AgentsDGV.SelectedRows[0].Cells[1].Value.ToString();
                AgPhoneTb.Text = AgentsDGV.SelectedRows[0].Cells[2].Value.ToString();
                AgAddTb.Text = AgentsDGV.SelectedRows[0].Cells[3].Value.ToString();
                AgPassTb.Text = AgentsDGV.SelectedRows[0].Cells[4].Value.ToString();

                // Store the primary key
                Key = Convert.ToInt32(AgentsDGV.SelectedRows[0].Cells[0].Value);
            }
        }

        private void Agents_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Consumers consumers = new Consumers();
            consumers.Show();
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
