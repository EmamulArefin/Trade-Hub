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
    public partial class car1 : Form
    {
        public car1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            car1 ab = new car1();
            ab.Show();
        }

        private void car1_Load(object sender, EventArgs e)
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

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Color myRGB = Color.FromArgb(68, 133, 201);
            button4.BackColor = myRGB;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Transparent;
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            Car2 ab = new Car2();
            ab.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 ab = new Form4();
            ab.Show();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Hide();
            Car3 ab = new Car3();
            ab.Show();
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
            int productIdToAdd = 36; // Replace this with the actual product ID you want to add to the cart

            Product productToAdd = GetProductDetails(productIdToAdd);

            if (productToAdd != null)
            {
                // Insert the product into the ShoppingCartDatabase
                InsertProductIntoCart(productToAdd);
                MessageBox.Show("Insert the product into the ShoppingCartDatabase", "Cart Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Product not found or other error handling
            }
        }

        // Method to get product details from ProductsDatabase
        private Product GetProductDetails(int ProductId)
        {
            string productConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(productConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Product_Id, Product_Name, Product_Price,Product_Quantiy, Product_Image FROM Product_Info WHERE Product_ID = @Product_Id";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Product_Id", ProductId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader["Product_Name"].ToString(),
                                ProductPrice = reader.GetInt32(2),
                                ProductQuantity = reader.GetInt32(3),
                            };

                            // Check if the column contains data
                            if (!reader.IsDBNull(3))
                            {
                                // Read the bytes of the image
                                long bytesLength = reader.GetBytes(4, 0, null, 0, 0); // Get the length of the image
                                byte[] imageData = new byte[bytesLength]; // Create a byte array to hold the image data
                                reader.GetBytes(4, 0, imageData, 0, (int)bytesLength); // Read the image data into the byte array
                                product.ProductImage = imageData; // Assign the byte array to the Product's Image property
                            }

                            return product;
                        }
                    }
                }
            }
            return null;

        }





        private void InsertProductIntoCart(Product product)
        {
            string cartConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(cartConnectionString))
            {
                connection.Open();

                // Enable Identity Insert
                /*  string enableIdentityInsertQuery = "SET IDENTITY_INSERT AddToCartTable ON";
                  SqlCommand enableIdentityInsertCommand = new SqlCommand(enableIdentityInsertQuery, connection);
                  enableIdentityInsertCommand.ExecuteNonQuery();*/

                // Perform INSERT with explicit ProductID
                string insertQuery = "INSERT INTO AddToCartTable (Product_Name, Product_Price,Quantity,Product_Image) VALUES ( @Product_Name, @Product_Price, @Quantity,@Product_Image)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Product_Name", product.ProductName);
                    command.Parameters.AddWithValue("@Product_Price", product.ProductPrice);
                    command.Parameters.AddWithValue("@Quantity", 1); // Assuming adding 1 quantity to cart
                    command.Parameters.AddWithValue("@Product_Image", product.ProductImage);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


        // Event handler for adding a product to the cart
        private void button4_Click(object sender, EventArgs e)
        {
            // Fetch the product details from ProductsDatabase
            int productIdToAdd = 37; // Replace this with the actual product ID you want to add to the cart

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
        private Product GetProductDetails1(int ProductId)
        {
            string productConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(productConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Product_Id, Product_Name, Product_Price,Product_Quantiy, Product_Image FROM Product_Info WHERE Product_ID = @Product_Id";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Product_Id", ProductId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader["Product_Name"].ToString(),
                                ProductPrice = reader.GetInt32(2),
                                ProductQuantity = reader.GetInt32(3),
                            };

                            // Check if the column contains data
                            if (!reader.IsDBNull(3))
                            {
                                // Read the bytes of the image
                                long bytesLength = reader.GetBytes(4, 0, null, 0, 0); // Get the length of the image
                                byte[] imageData = new byte[bytesLength]; // Create a byte array to hold the image data
                                reader.GetBytes(4, 0, imageData, 0, (int)bytesLength); // Read the image data into the byte array
                                product.ProductImage = imageData; // Assign the byte array to the Product's Image property
                            }

                            return product;
                        }
                    }
                }
            }
            return null;

        }





        private void InsertProductIntoCart1(Product product)
        {
            string cartConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(cartConnectionString))
            {
                connection.Open();

                // Enable Identity Insert
                /*  string enableIdentityInsertQuery = "SET IDENTITY_INSERT AddToCartTable ON";
                  SqlCommand enableIdentityInsertCommand = new SqlCommand(enableIdentityInsertQuery, connection);
                  enableIdentityInsertCommand.ExecuteNonQuery();*/

                // Perform INSERT with explicit ProductID
                string insertQuery = "INSERT INTO AddToCartTable (Product_Name, Product_Price,Quantity,Product_Image) VALUES ( @Product_Name, @Product_Price, @Quantity,@Product_Image)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Product_Name", product.ProductName);
                    command.Parameters.AddWithValue("@Product_Price", product.ProductPrice);
                    command.Parameters.AddWithValue("@Quantity", 1); // Assuming adding 1 quantity to cart
                    command.Parameters.AddWithValue("@Product_Image", product.ProductImage);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }



        // Event handler for adding a product to the cart
        private void button6_Click(object sender, EventArgs e)
        {
            // Fetch the product details from ProductsDatabase
            int productIdToAdd = 38; // Replace this with the actual product ID you want to add to the cart

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
        private Product GetProductDetails2(int ProductId)
        {
            string productConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(productConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Product_Id, Product_Name, Product_Price,Product_Quantiy, Product_Image FROM Product_Info WHERE Product_ID = @Product_Id";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Product_Id", ProductId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader["Product_Name"].ToString(),
                                ProductPrice = reader.GetInt32(2),
                                ProductQuantity = reader.GetInt32(3),
                            };

                            // Check if the column contains data
                            if (!reader.IsDBNull(3))
                            {
                                // Read the bytes of the image
                                long bytesLength = reader.GetBytes(4, 0, null, 0, 0); // Get the length of the image
                                byte[] imageData = new byte[bytesLength]; // Create a byte array to hold the image data
                                reader.GetBytes(4, 0, imageData, 0, (int)bytesLength); // Read the image data into the byte array
                                product.ProductImage = imageData; // Assign the byte array to the Product's Image property
                            }

                            return product;
                        }
                    }
                }
            }
            return null;

        }





        private void InsertProductIntoCart2(Product product)
        {
            string cartConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=User_Info;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(cartConnectionString))
            {
                connection.Open();

                // Enable Identity Insert
                /*  string enableIdentityInsertQuery = "SET IDENTITY_INSERT AddToCartTable ON";
                  SqlCommand enableIdentityInsertCommand = new SqlCommand(enableIdentityInsertQuery, connection);
                  enableIdentityInsertCommand.ExecuteNonQuery();*/

                // Perform INSERT with explicit ProductID
                string insertQuery = "INSERT INTO AddToCartTable (Product_Name, Product_Price,Quantity,Product_Image) VALUES ( @Product_Name, @Product_Price, @Quantity,@Product_Image)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Product_Name", product.ProductName);
                    command.Parameters.AddWithValue("@Product_Price", product.ProductPrice);
                    command.Parameters.AddWithValue("@Quantity", 1); // Assuming adding 1 quantity to cart
                    command.Parameters.AddWithValue("@Product_Image", product.ProductImage);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Document pdoc = new Document(PageSize.NOTE);
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\Black Bmw M6.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document pdoc = new Document(PageSize.NOTE);
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\Black BMW X5.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Document pdoc = new Document(PageSize.NOTE);
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\Black BMW X3.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }
    }
}
