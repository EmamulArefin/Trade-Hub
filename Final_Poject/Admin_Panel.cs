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
    public partial class Admin_Panel : Form
    {
        public Admin_Panel()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button1.BackColor = myRGB;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }



        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True");
        SqlCommand cmd;

        private void load_data()
        {
            dataGridView1.Columns.Clear();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select count(*) from User_Info", conn);
                string val = cmd.ExecuteScalar() as string;
                conn.Close();
                int valu = Convert.ToInt32(val);
                cmd = new SqlCommand("Select User_Id,First_Name,Last_Name,Email,Phone_Number,Gender,User_Name,User_Image from User_Info", conn);
                SqlDataAdapter ab = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                ab.Fill(dt);
                dataGridView1.RowTemplate.Height = 24;
                dataGridView1.DataSource = dt;
                DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
                pic1 = (DataGridViewImageColumn)dataGridView1.Columns[7];
                pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;


                dataGridView1.AllowUserToAddRows = false;
                DataGridViewButtonColumn btc = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(8, btc);
                btc.HeaderText = "Ban a User";
                btc.Width = 80;
                btc.Text = "Banned";
                btc.UseColumnTextForButtonValue = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Facing error in Form 2 Load", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 8)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string userName = row.Cells["User_Name"].Value.ToString();
                string userEmail = row.Cells["Email"].Value.ToString(); // Replace "Email" with the actual column name for email
                string userPhoneNumber = row.Cells["Phone_Number"].Value.ToString();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Banned_Info (Username,Email,Phone_Number)values(@Username,@Email,@Phone_Number)", conn);
                    cmd.Parameters.AddWithValue("@Username", userName);
                    cmd.Parameters.AddWithValue("@Email", userEmail);
                    cmd.Parameters.AddWithValue("@Phone_Number", userPhoneNumber);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("faild to store ban info");
                }


                cmd = new SqlCommand("DELETE FROM User_Info WHERE User_Id=@User_Id", conn);
                cmd.Parameters.AddWithValue("User_Id", row.Cells["User_Id"].Value);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                load_data();
            }
        }

        private void Admin_Panel_Load(object sender, EventArgs e)
        {
            load_data();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 ab = new Form1();
            ab.Show();
        }
    }
}
