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
    public partial class FormCreateUser : Form
    {
        private UserService userService;
        public FormCreateUser(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                MessageBox.Show("Trebuie completate toate campurile");
            else
            {
                userService.insertUser(textBox1.Text, textBox2.Text, textBox3.Text, 0);
                MessageBox.Show("Userul a fost inserat cu succes");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
