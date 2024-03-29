﻿using System;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Final_Poject
{
    public partial class Acer4 : Form
    {
        public Acer4()
        {
            InitializeComponent();
        }

        private void Acer4_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button6.BackColor = myRGB;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button1.BackColor = myRGB;
        }

        private void button3_MouseEnter_1(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button3.BackColor = myRGB;
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
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Transparent;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
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

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            ACER ac = new ACER();
            ac.Show();
        }


        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int ProductPrice { get; set; }
            public int ProductQuantity { get; set; }
            public byte[] ProductImage { get; set; }
        }

        // Event handler for adding a product to the cart
        private void button3_Click(object sender, EventArgs e)
        {
            // Fetch the product details from ProductsDatabase
            int productIdToAdd = 24; // Replace this with the actual product ID you want to add to the cart

            Product productToAdd = GetProductDetails(productIdToAdd);

            if (productToAdd != null)
            {
                // Insert the product into the ShoppingCartDatabase
                InsertProductIntoCart(productToAdd);
                // Display success or perform further actions
            }
            else
            {
                // Product not found or other error handling
            }
        }

        // Method to get product details from ProductsDatabase
        private Product GetProductDetails(int productId)
        {
            string productConnectionString = "Data Source=DESKTOP-TB6HHOS;Initial Catalog=AK;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(productConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT ProductID, ProductName, ProductPrice, ProductImage FROM AK12 WHERE ProductID = @ProductId";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                ProductPrice = reader.GetInt32(2),
                                ProductImage = (byte[])reader["ProductImage"]
                            };
                            return product;
                        }
                    }
                }
            }
            return null;
        }

        // Method to insert product into ShoppingCartDatabase
        private void InsertProductIntoCart(Product product)
        {
            string cartConnectionString = "Data Source=DESKTOP-TB6HHOS;Initial Catalog=AK;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(cartConnectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO AddToCartTable (ProductName,ProductPrice, ProductQuantity) VALUES (@ProductName,@ProductPrice, @ProductQuantity)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", product.ProductID);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                    command.Parameters.AddWithValue("@ProductQuantity", 1);
                    /*DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
                    pic1 = (DataGridViewImageColumn)dataGridView1.Columns[7];
                    pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;*/
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Document pdoc = new Document(PageSize.NOTE);
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\Acer Helios 16PH.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form14 a = new Form14();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 a = new Form2();
            a.Show();
        }
    }
}
