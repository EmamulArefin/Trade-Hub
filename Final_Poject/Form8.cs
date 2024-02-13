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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 ac = new Form4();
            ac.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            Form9 ac = new Form9();
            ac.Show();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            DELL ac = new DELL();
            ac.Show();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            ACER ac = new ACER();
            ac.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            HP1 ac = new HP1();
            ac.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            HP2 ac = new HP2();
            ac.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            HP3cs ac = new HP3cs();
            ac.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            HP4 ac = new HP4();
            ac.Show();
        }
    }
}
