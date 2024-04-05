using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace DalsheBogaNet.Mvvm.Model
{
    class ProductZapolnenie
    {
        static ProductZapolnenie instance;
        public static ProductZapolnenie Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductZapolnenie();
                return instance;
            }
        }
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return products;

            string sql = "SELECT * FROM izdelia";
            using (var mc = new MySqlCommand(sql, connect))
            using(var reader = mc.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product
                    {
                        Name = reader.GetString("Name"),
                        Description = reader.GetString("Description"),
                        Price = reader.GetInt32("Price"),
                        Amount = reader.GetInt32("Amount"),
                        Size = reader.GetString("Size"),
                        Breakable = reader.GetBoolean("Breakable")
                    };
                }
            }
            return products;
        }
    }
}
