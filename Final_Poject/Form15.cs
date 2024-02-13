using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Poject
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 HomePage = new Form2();
            HomePage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 Catagory = new Form4();
            Catagory.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form14 UserAccount = new Form14();
            UserAccount.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form15 ContactUs = new Form15();
            ContactUs.Show();
        }
    }
}
