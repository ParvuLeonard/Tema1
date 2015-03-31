using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Article
    {
        private String title;
        private String description;
        private String photo;

        public Article(String title, String description, String photo)
        {
            this.title = title;
            this.description = description;
            this.photo = photo;
        }

        public String getTitle()
        {
            return title;
        }

        public String getDescription()
        {
            return description;
        }

        public String getPhoto()
        {
            return photo;
        }
    }
}
