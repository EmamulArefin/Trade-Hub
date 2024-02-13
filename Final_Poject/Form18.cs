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


namespace Final_Poject
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True");
        SqlCommand cmd;


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 product = new Form4();
            product.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 home = new Form2();
            home.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form14 Account = new Form14();
            Account.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 ContactUS = new Form15();
            ContactUS.Show();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            bind_data();
        }
        private void bind_data()
        {
            conn.Open();
            cmd = new SqlCommand("Select * from AddToCartTable", conn);
            SqlDataAdapter ab = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            ab.Fill(dt);
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
            pic1 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;

        }
    }
}
