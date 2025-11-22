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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Consumers obj = new Consumers();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show(); 
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Agents agents = new Agents();
            agents.Show();  
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();    
            obj.Show();
            this.Hide();
        }
    }
}
