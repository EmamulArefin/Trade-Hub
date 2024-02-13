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

namespace Final_Poject
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 HomePage = new Form2();
           HomePage.Show();



        }

        private void Form14_Load(object sender, EventArgs e)
        {
            string read = File.ReadAllText(@"D:\University\6th Semester\C# Project\Final_Poject\Text_File\Store_User.txt");
            string sql = "SELECT * FROM User_Info WHERE User_Name = @User_Name";

            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@User_Name",read);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            label2.Text = reader["User_Name"].ToString();
                            label7.Text = reader["Gender"].ToString();
                            label8.Text = reader["Phone_Number"].ToString();
                            label10.Text = reader["Email"].ToString();
                           // string imagePath = reader["UserPicture"].ToString();
                            byte[] imageBytes = (byte[])reader["User_Image"];
                            
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {

                        }

                    

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 HomePage = new Form2();
            HomePage.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 Catagory = new Form4();
            Catagory.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Form14 UserAccount = new Form14();
            UserAccount.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            Form15 ContactUs = new Form15();
            ContactUs.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            Form18 AddToCart = new Form18();
            AddToCart.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            ForgetPass_Panel a = new ForgetPass_Panel();
            a.Show();
        }

       
    }
}
