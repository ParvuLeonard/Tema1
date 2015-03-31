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
    public partial class FormReadUser : Form
    {
        UserService userService;
        public FormReadUser(UserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                MessageBox.Show("Trebuie completat campul");
            else
            {
                String rez = userService.getUser(textBox1.Text);
                if (rez.Equals(""))
                    MessageBox.Show("Userul cautat nu exista in baza de date");
                else
                    MessageBox.Show(rez);
            }
        }
    }
}
