using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;

namespace A_ZApplication
{
    public partial class FormAdmin : Form
    {
        UserService userService;
        public FormAdmin()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCreateUser formCreateUser = new FormCreateUser(userService);
            formCreateUser.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReadUser formReadUser = new FormReadUser(userService);
            formReadUser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUpdateUser formUpdateUser = new FormUpdateUser(userService);
            formUpdateUser.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDeleteUser formDeleteUser = new FormDeleteUser(userService);
            formDeleteUser.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
