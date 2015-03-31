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
    public partial class FormUpdateUser : Form
    {
        UserService userService;
        public FormUpdateUser(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                MessageBox.Show("Trebuie completate toate campurile");
            else
            {
                bool check = userService.updateUser(textBox1.Text, textBox2.Text);
                if (check)
                    MessageBox.Show("Rolul user'ului " + textBox1.Text + " a fost actualizat cu succes");
                else
                    MessageBox.Show("User'ul nu se afla in baza de date");
            }
        }
    }
}
