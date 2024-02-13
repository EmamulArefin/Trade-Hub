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
    public partial class ForgetPass_Panel : Form
    {
        public ForgetPass_Panel()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True");
        SqlCommand cmd;

        private string GenarateOTP()
        {
            var bytes = new byte[4]; // 4 bytes for an integer
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            var otpValue = BitConverter.ToInt32(bytes, 0);
            return Math.Abs(otpValue % 1000000).ToString("D6");
        }


        private void SendMail(string otp, string mail)
        {
            // string otp = GenarateOTP();
            // string mail = textBox1.Text;
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("tradehubdot@gmail.com", "mffe gjxl vuur bloj"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress(mail));
                mailMessage.From = new MailAddress("tradehubdot@gmail.com");
                mailMessage.Subject = "Your OTP";
                mailMessage.Body = $"Your OTP is {otp}";
                smtpClient.Send(mailMessage);

                MessageBox.Show("Mail Successfully sent", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Facing problem at mail body", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string auto = GenarateOTP();
            string toEmailAddress;

            try
            {
                File.WriteAllText(@"D:\University\6th Semester\C# Project\Final_Poject\Text_File\V_store.txt", auto);
                // MessageBox.Show("Stored Succcessfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                //  MessageBox.Show("Facing problem to store V_Code", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            if (textBox1.Text != null)
            {
                try
                {
                    conn.Open();
                    string userName = textBox1.Text;
                    cmd = new SqlCommand("SELECT Email FROM User_Info WHERE User_Name = @User_Name", conn);
                    cmd.Parameters.AddWithValue("@User_Name", userName);
                    toEmailAddress = cmd.ExecuteScalar() as string;
                    conn.Close();
                    SendMail(auto, toEmailAddress);

                    File.WriteAllText(@"D:\University\6th Semester\C# Project\Final_Poject\Text_File\User_Name.txt", userName);

                }
                catch (Exception)
                {
                    MessageBox.Show("Facing problem to send mail", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }

                this.Hide();
                Form5 a = new Form5();
                a.Show();
            }
            else
            {
                MessageBox.Show("Username invalid or not registered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Color myrg = Color.FromArgb(68, 133, 201);
            button1.BackColor = myrg;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void ForgetPass_Panel_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
        }
    }
}
