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
    public partial class FormDeleteUser : Form
    {
        UserService userService;
        public FormDeleteUser(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals(""))
                MessageBox.Show("Trebuie completat campul");
            else
            {
                bool check = userService.deleteUser(textBox1.Text);
                if (check)
                    MessageBox.Show("Operatia a fost executata cu succes");
                else
                    MessageBox.Show("User'ul nu se afla in baza de date");
            }
        }
    }
}
