using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiplomaWPF
{
    internal class Db
    {
        private string connectionString =
            "Server=localhost;Port=3306;Database=wpf_shop;Uid=root;Pwd=root;";

        public void TestConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            conn.Close();
        }
        public List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand mySqlCommand = 
              new MySqlCommand ("SELECT * FROM products", connection);
            
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read()) 
            {
                string name = reader["name"].ToString();
                string image = reader["image"].ToString();
                int id = Convert.ToInt32(reader["id"]);
                decimal price = Convert.ToDecimal(reader["price"]);
                Product product = new Product();
                product.Name = name;
                product.Image = image;
                product.Price = price;
                product.Id = id;
                products.Add(product);
            }
            reader.Close();
            connection.Close();
            return products;
        }

    }
}
