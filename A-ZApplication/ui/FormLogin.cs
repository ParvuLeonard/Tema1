using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using Entities;

namespace A_ZApplication
{
    public partial class FormLogin : Form
    {
        UserService userService;
        Users user;
        public FormLogin()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = userService.login(textBox1.Text, textBox2.Text);

            if (user == null)
            {
                MessageBox.Show("Obiect null");
            }
            else
            {
                if (user.getRole().Equals("admin"))
                {
                    FormAdmin formAdmin = new FormAdmin();
                    formAdmin.Show();
                }
                else
                {
                    FormEmployee formUser = new FormEmployee(textBox1.Text);
                    formUser.Show();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String password = userService.resetPassword(textBox1.Text);
            MessageBox.Show(password);
        }
    }
}
