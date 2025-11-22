using System;
using System.Data;
using System.Data.SqlClient; // Required for SQL client classes
using System.Windows.Forms;

namespace WaterBillingManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private readonly string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\codew\OneDrive\Documents\WaterBillingDb.mdf;Integrated Security=True;Encrypt=False;Connect Timeout=30";

        public static string User;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // If you intend for this picture box to do something, add logic here.
            // Otherwise, it can remain empty or be removed if unused.
        }

        private void SaveBtn_Click(object sender, EventArgs e) // Assuming this is your Login button
        {
            // Input validation: Check if username and password fields are empty
            if (string.IsNullOrWhiteSpace(UnameTb.Text) || string.IsNullOrWhiteSpace(PasswordTb.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution if fields are empty
            }

            using (SqlConnection Con = new SqlConnection(connectionString)) // Ensure connection is properly managed
            {
                try
                {
                    Con.Open();
                    // *** IMPORTANT: Use a parameterized query to prevent SQL Injection ***
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM AgentTbl WHERE AgName = @Username AND AgPass = @Password", Con);
                    cmd.Parameters.AddWithValue("@Username", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@Password", PasswordTb.Text); // Consider hashing passwords in a real app

                    // ExecuteScalar returns the first column of the first row (the count in this case)
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        User = UnameTb.Text;
                        // Open the main application form (e.g., Home or Main Dashboard)
                        // Assuming you want to open the Home form after login as per previous context
                        Main homeForm = new Main();
                        homeForm.Show();
                        this.Hide(); // Hide the login form
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username Or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Catch specific SQL exceptions or general exceptions for better error reporting
                    MessageBox.Show("An error occurred during login: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Optional: Add a button to clear fields
        private void ClearBtn_Click(object sender, EventArgs e) // Assuming you have a Clear button
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
        }

        // Optional: Add a link label or button for "Forgot Password" or "Register" if needed
        private void ForgotPasswordLbl_Click(object sender, EventArgs e) // Assuming you have a label/link
        {
            MessageBox.Show("Please contact your administrator to reset your password.", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin login = new AdminLogin();
            login.Show();
            this.Hide();
        }
    }
}