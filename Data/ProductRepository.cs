using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DiplomaWPF
{
    internal class ProductRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;


        
        public List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();


                using (MySqlCommand mySqlCommand = new MySqlCommand("SELECT id, name, image, price, description FROM products", connection))
                {


                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            string image = reader["image"].ToString();
                            int id = Convert.ToInt32(reader["id"]);
                            decimal price = Convert.ToDecimal(reader["price"]);
                            string description = reader["description"].ToString();
                            Product product = new Product();
                            product.Name = name;
                            product.Image = image;
                            product.Price = price;
                            product.Id = id;
                            product.Description = description;
                            products.Add(product);
                        }
                        return products;
                    }

                }
            }

        }
    }
}
