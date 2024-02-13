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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True");
        SqlCommand cmd;


        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Color myrg = Color.FromArgb(68, 133, 201);
            button1.BackColor = myrg;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string new_P = textBox1.Text;
            string data = File.ReadAllText(@"D:\University\6th Semester\C# Project\Final_Poject\Text_File\User_Name.txt");
            try
            {
                conn.Open();
                cmd = new SqlCommand("UPDATE User_Info SET [Password] = '" + new_P + "' WHERE [User_Name] = '" + data + "';", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Hide();
                Form1 a = new Form1();
                a.Show();
                MessageBox.Show("Password has been changed succcessfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Password not changed", "Warnin", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
