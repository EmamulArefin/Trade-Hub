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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        byte[] big;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg";

            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
               pictureBox1.Image = Image.FromFile(fileOpen.FileName);
            }
            fileOpen.Dispose();

        }
    }
}
