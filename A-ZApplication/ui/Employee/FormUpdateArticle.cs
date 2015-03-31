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
    public partial class FormUpdateArticle : Form
    {
        ArticleService articleService;

        public FormUpdateArticle(ArticleService articleService)
        {
            InitializeComponent();
            this.articleService = articleService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                MessageBox.Show("Trebuie completate toate campurile");
            else
            {
                bool check = articleService.updateArticle(textBox1.Text, textBox2.Text, textBox3.Text);
                if (check)
                    MessageBox.Show("Operatiunea s'a efectuat cu succes");
                else
                    MessageBox.Show("Articolul cautat nu se afla in baza de date");
            }
        }
        
    }
}
