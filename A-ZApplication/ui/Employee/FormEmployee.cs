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
    public partial class FormEmployee : Form
    {
        ArticleService articleService;
        String employeeName;
        public FormEmployee(String employeeName)
        {
            InitializeComponent();
            this.employeeName = employeeName;
            articleService = new ArticleService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCreateArticle formCreateArticle = new FormCreateArticle(articleService, employeeName);
            formCreateArticle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReadArticle formReadArticle = new FormReadArticle(articleService);
            formReadArticle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUpdateArticle formUpdateArticle = new FormUpdateArticle(articleService);
            formUpdateArticle.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDeleteArticle formDeleteArticle = new FormDeleteArticle(articleService);
            formDeleteArticle.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
