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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Final_Poject
{
    public partial class EC2 : Form
    {
        public EC2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            EC1 ab = new EC1();
            ab.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            EC2 ab = new EC2();
            ab.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 ab = new Form4();
            ab.Show();
        }

        private void EC2_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            EC3 ab = new EC3();
            ab.Show();
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

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button4.BackColor = myRGB;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button1.BackColor = myRGB;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Transparent;
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

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button5.BackColor = myRGB;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Transparent;
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

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button6.BackColor = myRGB;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Transparent;
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
        private void button1_Click(object sender, EventArgs e)
        {
            // Fetch the product details from ProductsDatabase
            int productIdToAdd = 30; // Replace this with the actual product ID you want to add to the cart

            Product productToAdd = GetProductDetails1(productIdToAdd);

            if (productToAdd != null)
            {
                // Insert the product into the ShoppingCartDatabase
                InsertProductIntoCart1(productToAdd);
                MessageBox.Show("Insert the product into the ShoppingCartDatabase", "Cart Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Product not found or other error handling
            }
        }

        // Method to get product details from ProductsDatabase
        private Product GetProductDetails1(int productId)
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
        private void InsertProductIntoCart1(Product product)
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

       
        // Event handler for adding a product to the cart
        private void button6_Click(object sender, EventArgs e)
        {
            // Fetch the product details from ProductsDatabase
            int productIdToAdd = 31; // Replace this with the actual product ID you want to add to the cart

            Product productToAdd = GetProductDetails2(productIdToAdd);

            if (productToAdd != null)
            {
                // Insert the product into the ShoppingCartDatabase
                InsertProductIntoCart2(productToAdd);
                MessageBox.Show("Insert the product into the ShoppingCartDatabase", "Cart Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Product not found or other error handling
            }
        }

        // Method to get product details from ProductsDatabase
        private Product GetProductDetails2(int productId)
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
        private void InsertProductIntoCart2(Product product)
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

      

        // Event handler for adding a product to the cart
        private void button7_Click(object sender, EventArgs e)
        {
            // Fetch the product details from ProductsDatabase
            int productIdToAdd = 32; // Replace this with the actual product ID you want to add to the cart

            Product productToAdd = GetProductDetails3(productIdToAdd);

            if (productToAdd != null)
            {
                // Insert the product into the ShoppingCartDatabase
                InsertProductIntoCart3(productToAdd);
                MessageBox.Show("Insert the product into the ShoppingCartDatabase", "Cart Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Product not found or other error handling
            }
        }

        // Method to get product details from ProductsDatabase
        private Product GetProductDetails3(int productId)
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
        private void InsertProductIntoCart3(Product product)
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

       

        // Event handler for adding a product to the cart
        private void button8_Click(object sender, EventArgs e)
        {
            // Fetch the product details from ProductsDatabase
            int productIdToAdd = 55; // Replace this with the actual product ID you want to add to the cart

            Product productToAdd = GetProductDetails4(productIdToAdd);

            if (productToAdd != null)
            {
                // Insert the product into the ShoppingCartDatabase
                InsertProductIntoCart4(productToAdd);
                MessageBox.Show("Insert the product into the ShoppingCartDatabase", "Cart Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Product not found or other error handling
            }
        }

        // Method to get product details from ProductsDatabase
        private Product GetProductDetails4(int productId)
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
        private void InsertProductIntoCart4(Product product)
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
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\Front Load Washing.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Document pdoc = new Document(PageSize.NOTE);
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\Top Loading Washing Machine.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Document pdoc = new Document(PageSize.NOTE);
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\SINGER Top Loading Washing.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Document pdoc = new Document(PageSize.NOTE);
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\Front Load Washing Machine.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }
    }
}
