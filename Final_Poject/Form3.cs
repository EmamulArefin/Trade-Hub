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
    public partial class Form3 : Form
    {
        public Form3()
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
            button1.BackColor = Color.White;
        }

        private void Form3_Load(object sender, EventArgs e)
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
            Form1 ab = new Form1();
            ab.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.JpG;*.png;*.Gif)|*.JpG;*.png;*.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        string gender;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userName = textBox5.Text;
            string Email = textBox3.Text;
            string PhoneNumber = textBox4.Text;

            conn.Open();
            cmd = new SqlCommand("SELECT Username FROM Banned_Info where Username = @Username", conn);
            cmd.Parameters.AddWithValue("@Username", userName);
            string C_userName = cmd.ExecuteScalar() as string;

            cmd = new SqlCommand("SELECT Email FROM Banned_Info where Email = @Email", conn);
            cmd.Parameters.AddWithValue("@Email", Email);
            string C_Email = cmd.ExecuteScalar() as string;

            cmd = new SqlCommand("SELECT Phone_Number FROM Banned_Info Where Phone_Number = @Phone_Number", conn);
            cmd.Parameters.AddWithValue("@Phone_Number", PhoneNumber);
            string C_Phone = cmd.ExecuteScalar() as string;
            conn.Close();

            try
            {
                cmd = new SqlCommand("Insert Into User_Info(First_Name,Last_Name,Email,Phone_Number,Gender,User_Name,Password,User_Image)values(@First_Name,@Last_Name,@Email,@Phone_Number,@Gender,@User_Name,@Password,@User_Image)", conn);
                cmd.Parameters.AddWithValue("First_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("Last_Name", textBox2.Text);
                if (Email != C_Email)
                {
                    cmd.Parameters.AddWithValue("Email", Email);
                }
                else
                {
                    MessageBox.Show("The Email is already registered or Banned form Authority", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (PhoneNumber != C_Phone)
                {
                    cmd.Parameters.AddWithValue("Phone_Number", PhoneNumber);
                }
                else
                {
                    MessageBox.Show("The Number is already registered or Banned form Authority", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                cmd.Parameters.AddWithValue("Gender", gender);
                if (userName != C_userName)
                {
                    cmd.Parameters.AddWithValue("User_Name", userName);
                }
                else
                {
                    MessageBox.Show("The Username is already taken by another user", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                cmd.Parameters.AddWithValue("Password", textBox6.Text);
                MemoryStream mem = new MemoryStream();
                pictureBox2.Image.Save(mem, pictureBox2.Image.RawFormat);
                cmd.Parameters.AddWithValue("User_Image", mem.ToArray());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Sign Up successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("failed to sign up");
            }
        }
    }
}
