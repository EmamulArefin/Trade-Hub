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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
           
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;

            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button2.BackColor = myRGB;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button7.BackColor = myRGB;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.Transparent;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button3.BackColor = myRGB;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 ab = new Form7();
            ab.Show();
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button8.BackColor = myRGB;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Transparent;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            Property ab = new Property();
            ab.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Hide();
            car1 ab = new car1();
            ab.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            EC1 ab = new EC1();
            ab.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form14 ab = new Form14();
            ab.Show();
        }
    }
}
