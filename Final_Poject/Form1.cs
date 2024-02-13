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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True");
        SqlCommand cmd;

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button1.BackColor = myRGB;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Color myrg = Color.FromArgb(68, 133, 201);
            button2.BackColor = myrg;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            conn.Open();

            // Check if the user exists
            cmd = new SqlCommand("SELECT Password FROM User_Info WHERE User_Name = @User_Name", conn);
            cmd.Parameters.AddWithValue("@User_Name", userName);
            string storedPassword = cmd.ExecuteScalar() as string;

            conn.Close();

            if (textBox1.Text == "Admin" && textBox2.Text == "Admin")
            {
                // Admin login
                 Hide();
                Admin_Panel ac = new Admin_Panel();
                ac.Show();
                MessageBox.Show("Admin Log In Successful","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (storedPassword != null && password.Equals(storedPassword))
            {
                // User login successful
                File.WriteAllText(@"D:\University\6th Semester\C# Project\Final_Poject\Text_File\Store_User.txt", userName);
                Hide();
                Form2 ac = new Form2();
                ac.Show();
                MessageBox.Show("User Log In Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Invalid username or password
                MessageBox.Show("Invalid Username and Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 ab = new Form3();
            ab.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            ForgetPass_Panel ab = new ForgetPass_Panel();
            ab.Show();
        }
    }
}
