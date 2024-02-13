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
    public partial class Asus4cs : Form
    {
        public Asus4cs()
        {
            InitializeComponent();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {

            Hide();
            Form9 ac = new Form9();
            ac.Show();
        }
        private void Asus4cs_Load(object sender, EventArgs e)
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
            int productIdToAdd = 15; // Replace this with the actual product ID you want to add to the cart

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


        private void button2_Click(object sender, EventArgs e)
        {
            Document pdoc = new Document(PageSize.NOTE);
            PdfWriter p = PdfWriter.GetInstance(pdoc, new FileStream("D:\\Vivobook E410.pdf", FileMode.Create));
            pdoc.Open();
            Paragraph p1 = new Paragraph("Name : ZELANI JIDAN \nMobail:01601288732 \nGmail : akzelani2001@gmail.com \nLocation :Boshundhara,Dhaka,Bangladesh   ");
            pdoc.Add(p1);
            pdoc.Close();
            MessageBox.Show("Seller information downloded");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 a = new Form2();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form14 a = new Form14();
            a.Show();
        }
    }
}
