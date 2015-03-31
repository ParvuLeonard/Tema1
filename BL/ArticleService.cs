using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using DAL;
using Entities;

namespace BL
{
    public class ArticleService
    {
        ArticlesDAL articlesDAL;
        public ArticleService()
        {
            articlesDAL = new ArticlesDAL();
        }

        public void inserArticle(String title, String description, String photo, String employeeName)
        {
            Article article = new Article(title, description, photo);
            articlesDAL.insertArticle(article, employeeName);
        }

        public String getArticle(String title)
        {
            return articlesDAL.getArticle(title);
        }

        public bool updateArticle(String title, String description, String photo)
        {
            return articlesDAL.updateArticle(title, description, photo);
        }

        public bool deleteArticle(String title)
        {
            return articlesDAL.deleteArticle(title);
        }
    }
}
