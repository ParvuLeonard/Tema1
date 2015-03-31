using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Users
    {
        private String user;
        private String password;
        private String role;
        private int nrArticles;

        public Users(String user, String password, String role, int nrArticles)
        {
            this.user = user;
            this.password = password;
            this.role = role;
            this.nrArticles = nrArticles;
        }

        public String getUser()
        {
            return user;
        }

        public String getPassword()
        {
            return password;
        }

        public String getRole()
        {
            return role;
        }

        public int getNrArticles()
        {
            return nrArticles;
        }
    }
}
