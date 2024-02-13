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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button4.BackColor = myRGB;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button2.BackColor = myRGB;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button3.BackColor = myRGB;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form14 UserAccount = new Form14();
            UserAccount.Show();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 ac = new Form4();
            ac.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        int intimgnum = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[intimgnum];
            if (intimgnum == imageList1.Images.Count - 1)
            {
                intimgnum = 0;
            }
            else
            {
                intimgnum++;
            }
        }
        int iintimgnum = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox3.Image = imageList2.Images[intimgnum];
            if (intimgnum == imageList1.Images.Count - 1)
            {
                iintimgnum = 0;
            }
            else
            {
                iintimgnum++;
            }
        }
    }
}
