using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
    public class ArticlesDAL
    {
        private String connectionString;
        MySqlConnection conn = null;

        public ArticlesDAL()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "AZMarket");
            conn = new MySqlConnection(connectionString);
        }

        public void insertArticle(Article article, String employeeName)
        {
            String sql = "INSERT INTO articles (Title,Description,Photo) VALUES('" + article.getTitle() + "','" + article.getDescription() + 
            "','" + article.getPhoto() + "')";
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

            Users u = null;
            sql = "SELECT * FROM users WHERE user='" + employeeName + "'";
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
                    int newArticleNr = u.getNrArticles() + 1;
                    conn.Close();
                    conn.Open();
                    sql = "UPDATE users SET NrArticles = '" + newArticleNr + "' WHERE user = '" + u.getUser() + "'";
                    cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader2 = cmd.ExecuteReader();
                    reader2.Read();
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
        }

        public String getArticle(String title)
        {
            Article article = null;
            String sql = "SELECT * FROM articles WHERE title='" + title + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    article = new Article(reader["Title"].ToString(), reader["Description"].ToString(), reader["Photo"].ToString());
                    conn.Close();
                    return "The article has the following details: \n Name:" + article.getTitle() + "\n Description:" + article.getDescription() + "\n Photo:" + article.getPhoto();
                }
                else
                {
                    article = null;
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

        public bool updateArticle(String title, String description, String photo)
        {
            String sql = "UPDATE articles SET description = '" + description + "', photo = '" + photo + "' WHERE title = '" + title + "'";
            try 
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();
                if (getArticle(title).Equals("")) 
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

        public bool deleteArticle(String title)
        {
            String sql = "DELETE FROM articles WHERE Title = '" + title + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();
                if (getArticle(title).Equals("")) 
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
