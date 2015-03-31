using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
    public class UsersDAL
    {
        private String connectionString;
        MySqlConnection conn = null;

        public UsersDAL()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "AZMarket");
            conn = new MySqlConnection(connectionString);
        }


        public Users getUser(String username, String password)
        {
            Users u = null;
            String sql = "SELECT * FROM users WHERE user='" + username + "' AND password='" + password + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    int nrArticles = Int32.Parse(reader["NrArticles"].ToString());
                    u = new Users(reader["User"].ToString(), reader["Password"].ToString(), reader["Role"].ToString(), nrArticles);
                }
                else
                {
                    u = null;
                }
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return null;
            }
            return u;
        }

        public bool resetPassword(String user, String password)
        {
            String sql = "UPDATE users SET password = '" + password + "' WHERE user = '" + user + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();
                if (getUser(user).Equals(""))
                {
                    return false;
                }
                return true;
            }
            catch (MySqlException e)
            {

                Console.WriteLine(e.Message);
                conn.Close();
            }
            return false;
        }

        public void insertUser(Users user)
        {
            String sql = "INSERT INTO users (User,Password,Role,NrArticles) VALUES('" + user.getUser() + "','" + user.getPassword() + 
            "','" + user.getRole() + "','" + user.getNrArticles() + "')";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();
            }
            catch (MySqlException e)
            {

                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public String getUser(String user)
        {
            Users u = null;
            String sql = "SELECT * FROM users WHERE user='" + user + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    int nrArticles = Int32.Parse(reader["NrArticles"].ToString());
                    u = new Users(reader["User"].ToString(), reader["Password"].ToString(), reader["Role"].ToString(), nrArticles);
                    conn.Close();
                    return "The user has the following details: \n Name:" + u.getUser() + "\n Role:" + u.getRole() + "\n Nr. of Articles:" + u.getNrArticles();
                }
                else
                {
                    u = null;
                }
                conn.Close();
            }
            catch (MySqlException e)
            {

                Console.WriteLine(e.Message);
                conn.Close();
            }
            return "";
        }

        public bool updateUser(String user, String role)
        {
            String sql = "UPDATE users SET role = '" + role + "' WHERE user = '" + user + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();
                if(getUser(user).Equals(""))
                {
                    return false;
                }
                return true;
            }
            catch (MySqlException e)
            {

                Console.WriteLine(e.Message);
                conn.Close();
            }
            return false;
        }

        public bool deleteUser(String user)
        {
            String sql = "DELETE FROM users WHERE User = '" + user + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();
                if (getUser(user).Equals(""))
                {
                    return false;
                }
                return true;
            }
            catch (MySqlException e)
            {

                Console.WriteLine(e.Message);
                conn.Close();
            }
            return false;
        }
    }
}
