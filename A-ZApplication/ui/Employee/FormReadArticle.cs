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
    public partial class FormReadArticle : Form
    {
        ArticleService articleService;
        public FormReadArticle(ArticleService articleService)
        {
            InitializeComponent();
            this.articleService = articleService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                MessageBox.Show("Trebuie completat campul");
            else
            {
                String rez = articleService.getArticle(textBox1.Text);
                if (rez.Equals(""))
                    MessageBox.Show("Articolul cautat nu se gaseste in baza de date");
                else
                    MessageBox.Show(rez);
            }
        }
    }
}
