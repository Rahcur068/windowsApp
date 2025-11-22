using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterBillingManagement
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e) // Assuming this is your "Back" link/label
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void SaveBtn_Click_1(object sender, EventArgs e) // This is your "Enter" button's click event
        {
            // Check if the password textbox is empty
            if (string.IsNullOrWhiteSpace(PasswordTb.Text))
            {
                MessageBox.Show("Enter The Admin Password!!!", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Check if the entered password matches the hardcoded admin password
            else if (PasswordTb.Text == "Password") // <<< MAKE SURE TO REPLACE "Password" WITH YOUR ACTUAL ADMIN PASSWORD
            {
                // If password is correct, show "Welcome Admin" message
                MessageBox.Show("Welcome Admin!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open the Dashboard form
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide(); // Hide the Admin Login form
            }
            // If the password is not empty but incorrect
            else
            {
                // Show "Invalid Admin Password!" message for incorrect password
                MessageBox.Show("Invalid Admin Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTb.Clear(); // Clear the password field after a failed attempt
                PasswordTb.Focus(); // Set focus back to the password field
            }
        }
    }
}