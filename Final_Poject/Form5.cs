using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Final_Poject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Color myrg = Color.FromArgb(68, 133, 201);
            button1.BackColor = myrg;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            string read = File.ReadAllText(@"D:\University\6th Semester\C# Project\Final_Poject\Text_File\V_store.txt");
            try
            {
                if (code == read)
                {
                    MessageBox.Show("Verified");
                    Hide();
                    Form6 a = new Form6();
                    a.Show();
                }

                else
                {
                    MessageBox.Show("Enter Correct Verification Code");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            ForgetPass_Panel ab = new ForgetPass_Panel();
            ab.Show();
        }
    }
}
