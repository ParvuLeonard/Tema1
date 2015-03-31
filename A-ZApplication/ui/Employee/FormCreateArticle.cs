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
    public partial class FormCreateArticle : Form
    {
        ArticleService articleService;
        String employeeName;
        public FormCreateArticle(ArticleService articleService, String employeeName)
        {
            InitializeComponent();
            this.employeeName = employeeName;
            this.articleService = articleService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                MessageBox.Show("Trebuie completate toate campurile");
            else
            {
                articleService.inserArticle(textBox1.Text, textBox2.Text, textBox3.Text, employeeName);
                MessageBox.Show("Operatia a fost efectuata cu succes");
            }
        }
    }
}
