using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using DAL;
using Entities;

namespace BL
{
    public class UserService
    {
        UsersDAL usersDAL;
        public UserService()
        {
            usersDAL = new UsersDAL();
        }

        private string getMd5Hash(string input)
        {

            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public Users login(String user, String password)
        {
            String hash = getMd5Hash(password);

            return usersDAL.getUser(user, hash);
        }

        public String getNewPassword()
        {
            Random rand = new Random();
            double result = rand.NextDouble();
            result *= 1000;
            result = (int)result;
            return result.ToString();
        }

        public void insertUser(String user, String password, String role, int nrArticles)
        {
            Users employee = new Users(user, getMd5Hash(password), role, nrArticles);
            usersDAL.insertUser(employee);
        }

        public String getUser(String user)
        {
            return usersDAL.getUser(user);
        }

        public String resetPassword(String user)
        {
            String newPassword = getNewPassword();
            bool check = usersDAL.resetPassword(user, getMd5Hash(newPassword));
            if (check)
                return newPassword;
            else
                return "User'ul nu se afla in baza de date";
        }

        public bool updateUser(String user, String role)
        {
            return usersDAL.updateUser(user, role);
        }

        public bool deleteUser(String user)
        {
            return usersDAL.deleteUser(user);
        }
    }
}
