using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DalsheBogaNet.Mvvm.Model
{
    public class UserZapolnenie
    {
        User user;
        static UserZapolnenie instance;
        public static UserZapolnenie Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserZapolnenie();
                return instance;
            }
        }

        public bool Vhod { get; set; } = false;

        internal User GetUserData(string login, string password)
        {
            password = GetHash(password);
            string sql = "SELECT u.User_ID, u.Login, u.Role_ID, r.Role_Name, u.Password FROM Users u, Roles r WHERE u.Login = @login AND u.Password = @password and r.Role_ID = u.Role_ID";
            var result = new User();
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return result;
            using (var mc = new MySqlCommand(sql, connect))
            {
                mc.Parameters.Add(new MySqlParameter("login", login));
                mc.Parameters.Add(new MySqlParameter("password", password));
                using (var reader = mc.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.ID = reader.GetInt32("User_ID");
                        result.Login = reader.GetString("Login");
                        result.Password = reader.GetString("Password");
                        result.IDRole = reader.GetInt32("Role_ID");
                        result.Role = reader.GetString("Role_Name");
                        Vhod = true;
                    }
                }
                return result;
            }
        }



        private static string GetHash(string password)
        {
            var bytes = Encoding.ASCII.GetBytes(password);
            StringBuilder result2 = new StringBuilder();
            using (var md5 = MD5.Create())
            using (var ms = new MemoryStream(bytes))
            {
                var hash = md5.ComputeHash(ms);
                foreach (var b in hash)
                    result2.Append(b.ToString("x2"));
            }
            password = result2.ToString();
            return password;
        }

        internal IEnumerable<User> GetAllUserData()
        {
            string sql2 = "SELECT u.User_ID, u.Login, u.Role_ID, r.Role_Name FROM Users u, Roles r where u.Role_ID = r.Role_ID";
            var result = new List<User>();
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return result;
            using (var mc = new MySqlCommand(sql2, connect))
            using (var reader = mc.ExecuteReader())
            {
                User user = new User();
                int id;
                while (reader.Read())
                {
                    id = reader.GetInt32("User_ID");
                    if (user.ID != id)
                    {
                        user = new User();
                        result.Add(user);
                        user.ID = id;
                        user.Login = reader.GetString("Login");
                        user.Role = reader.GetString("Role");
                        user.IDRole = reader.GetInt32("Role_ID");
                    }
                }
            }
            return result;
        }

        internal IEnumerable<Role> GetAllRoles()
        {
            string sql2 = "SELECT * FROM Roles r";
            var result = new List<Role>();
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return result;
            using (var mc = new MySqlCommand(sql2, connect))
            using (var reader = mc.ExecuteReader())
            {
                while (reader.Read())
                {
                    Role role = new Role();

                    role.Title = reader.GetString("Role_Name");
                    role.ID = reader.GetInt32("Role_ID");
                    result.Add(role);
                }
            }
            return result;
        }

        internal void Regist(string login, string password, int role)
        {
            int id = MySqlDB.Instance.GetAutoID("Usesrs");
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return;
            string sql3 = "INSERT INTO Users VALUES (0, @login, @password, @role)";
            using (var mc = new MySqlCommand(sql3, connect))
            {
                mc.Parameters.Add(new MySqlParameter("login", login));
                mc.Parameters.Add(new MySqlParameter("password", GetHash(password)));
                mc.Parameters.Add(new MySqlParameter("role", role));
                mc.ExecuteNonQuery();
                MessageBox.Show(GetHash(password));
            }
        }
    }
}





