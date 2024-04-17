using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace DalsheBogaNet.Mvvm.Model
{
    public class ProductZapolnenie
    {
        private ProductZapolnenie()
        {

        }

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

        internal IEnumerable<Product> GetAllProducts(string sql)
        {
            var result = new List<Product>();
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return result;
            using (var mc = new MySqlCommand(sql, connect))
            using (var reader = mc.ExecuteReader())
            {
                Product product = new Product();
                int id;
                while (reader.Read())
                {
                    id = reader.GetInt32("Tovar_ID");
                    if (product.ID != id)
                    {
                        product = new Product();
                        result.Add(product);
                        product.ID = id;
                        product.Name = reader.GetString("Name");
                        product.Description = reader.GetString("Description");
                        product.Price = reader.GetDouble("Price");
                        product.Amount = reader.GetInt32("Amount");
                        product.Size = reader.GetDouble("Size");
                        product.Breakable = reader.GetBoolean("Breakable");
                    }

                }
            }
            return result;
        }
        internal void AddProduct(Product product)
        {
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return;

            int id = MySqlDB.Instance.GetAutoID("izdelia");

            string sql = "INSERT INTO izdelia VALUES (0, @Name, @Description, @Price, @Amount, @Size, @Breakable)";
            using (var mc = new MySqlCommand(sql, connect))
            {
                mc.Parameters.Add(new MySqlParameter("Name", product.Name));
                mc.Parameters.Add(new MySqlParameter("Description", product.Description));
                mc.Parameters.Add(new MySqlParameter("Price", product.Price));
                mc.Parameters.Add(new MySqlParameter("Amount", product.Amount));
                mc.Parameters.Add(new MySqlParameter("Size", product.Size));
                mc.Parameters.Add(new MySqlParameter("Breakable", product.Breakable));
            }
        }
        internal void Remove(Product product)
        {
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return;
            string sql = "DELETE FROM izdelia WHERE Tovar_ID = '" + product.ID + "';";
            //sql += "DELETE FROM izdelia WHERE id = '" + product.ID + "';";

            using (var mc = new MySqlCommand(sql, connect))
                mc.ExecuteNonQuery();

        }
        internal void UpdateProduct(Product product)
        {
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null) return;

            string sql = "DELETE FROM izdelia WHERE Tovar_ID = '" + product.ID + "';";
            using (var mc = new MySqlCommand(sql, connect))
                mc.ExecuteNonQuery();

            sql = "";

            sql = "UPDATE izdelia SET Name = @Name, Description = @Description, Price = @Price, Amount = @Amount, Size = @Size, Breakable = @Breakable";
            using (var mc = new MySqlCommand(sql, connect))
            {
                mc.Parameters.Add(new MySqlParameter("Name", product.Name));
                mc.Parameters.Add(new MySqlParameter("Description", product.Description));
                mc.Parameters.Add(new MySqlParameter("Price", product.Price));
                mc.Parameters.Add(new MySqlParameter("Amount", product.Amount));
                mc.Parameters.Add(new MySqlParameter("Size", product.Size));
                mc.Parameters.Add(new MySqlParameter("Breakable", product.Breakable));
                mc.ExecuteNonQuery();
            }
        }
        internal IEnumerable<Product> Search(string searchText)
        {
            string sql = "SELECT Tovar_ID, Description, Price, Amount, Size, Breakable, Postavhik FROM izdelia";
            sql += " AND (Name LIKE '%" + searchText + "%'";
            sql += " OR p.Description LIKE '%" + searchText + "%')";

            return GetAllProducts(sql);
        }
    }
}
