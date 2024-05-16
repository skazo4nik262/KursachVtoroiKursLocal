using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        
        internal IEnumerable<Zakaz> GetAllZakaz(string sql)
        {
            var result = new List<Zakaz>();
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return result;
            using (var mc = new MySqlCommand(sql, connect))
            using (var reader = mc.ExecuteReader())
            {
                Zakaz zakaz = new Zakaz();
                int id;
                while (reader.Read())
                {
                    id = reader.GetInt32("Tovar_ID");
                    if (zakaz.ID != id)
                    {
                        zakaz = new Zakaz();
                        result.Add(zakaz);
                        zakaz.ID = id;
                        zakaz.Name = reader.GetString("Name");
                        zakaz.Postavhik = reader.GetInt32("Postavhik");
                        zakaz.Amount = reader.GetInt32("Amount");
                    }
                }
            }
            return result;
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
                        product.Price = reader.GetDecimal("Price");
                        product.Size = reader.GetDouble("Size");
                        product.Breakable = reader.GetBoolean("Breakable");
                        product.Postavhik = reader.GetInt32("Postavhik");
                        product.Amount = reader.GetInt32("Amount");
                    }

                }
            }
            return result;
        }
        internal void AddProduct(Product product)
        {
            try
            {
                var connect = MySqlDB.Instance.GetConnection();
                if (connect == null)
                    return;

                int id = MySqlDB.Instance.GetAutoID("izdelia");

                string sql = "INSERT INTO izdelia VALUES (0, @Name, @Description, @Price, @Size, @Breakable, @Postavhik, @Amount)";
                using (var mc = new MySqlCommand(sql, connect))
                {
                    mc.Parameters.Add(new MySqlParameter("Name", product.Name));
                    mc.Parameters.Add(new MySqlParameter("Description", product.Description));
                    mc.Parameters.Add(new MySqlParameter("Price", product.Price));
                    mc.Parameters.Add(new MySqlParameter("Size", product.Size));
                    mc.Parameters.Add(new MySqlParameter("Breakable", product.Breakable));
                    mc.Parameters.Add(new MySqlParameter("Postavhik", product.Postavhik));
                    mc.Parameters.Add(new MySqlParameter("Amount", product.Amount));
                    mc.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n\n" + "Введеного поставщика не существует");
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
            try
            {
                var connect = MySqlDB.Instance.GetConnection();
                if (connect == null)
                    return;



                string sql = "UPDATE izdelia SET Name = @Name, Description = @Description, Price = @Price, Size = @Size, Breakable = @Breakable, Postavhik = @Postavhik, Amount = @Amount WHERE Tovar_ID = " + product.ID;
                using (var mc = new MySqlCommand(sql, connect))
                {
                    mc.Parameters.Add(new MySqlParameter("Name", product.Name));
                    mc.Parameters.Add(new MySqlParameter("Description", product.Description));
                    mc.Parameters.Add(new MySqlParameter("Price", product.Price));
                    mc.Parameters.Add(new MySqlParameter("Size", product.Size));
                    mc.Parameters.Add(new MySqlParameter("Breakable", product.Breakable));
                    mc.Parameters.Add(new MySqlParameter("Postavhik", product.Postavhik));
                    mc.Parameters.Add(new MySqlParameter("Amount", product.Amount));
                    mc.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n\n" + "Введеного поставщика не существует");
            }
        }
        internal IEnumerable<Product> Search(string searchText)
        {
            string sql = "SELECT Tovar_ID, Name, Description, Price, Amount, Size, Breakable, Postavhik FROM izdelia WHERE";
            sql += " Name LIKE '%" + searchText + "%'";
            sql += " OR Description LIKE '%" + searchText + "%'";

            return GetAllProducts(sql);
        }
    }
}
