﻿using System;
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
    public partial class ACER : Form
    {
        public ACER()
        {
            InitializeComponent();
        }
        int intimgnum = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox8.Image = imageList1.Images[intimgnum];
            if (intimgnum == imageList1.Images.Count - 1)
            {
                intimgnum = 0;
            }
            else
            {
                intimgnum++;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            ACER ac = new ACER();
            ac.Show();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            DELL ac = new DELL();
            ac.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            Form9 ac = new Form9();
            ac.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            Form8 ac = new Form8();
            ac.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            Form7 ac = new Form7();
            ac.Show();
        }

        private void ACER_Load(object sender, EventArgs e)
        {
           
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            
            button9.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Acer1 ac = new Acer1();
            ac.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Acer2 ac = new Acer2();
            ac.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Acer3 ac = new Acer3();
            ac.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Acer4 ac = new Acer4();
            ac.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 a = new Form2();
            a.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Hide();
            Form14 a = new Form14();
            a.Show();
        }
    }
}
