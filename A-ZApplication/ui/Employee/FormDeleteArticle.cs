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
    public partial class FormDeleteArticle : Form
    {
        ArticleService articleService;
        public FormDeleteArticle(ArticleService articleService)
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
                bool check = articleService.deleteArticle(textBox1.Text);
                if (check)
                    MessageBox.Show("Operatiunea s'a executat cu succes");
                else
                    MessageBox.Show("Articolul cautat nu se afla in baza de date");
            }
        }
    }
}
