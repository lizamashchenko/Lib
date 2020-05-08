using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        List<string> users;
        List<string> books;
        public Form2(List<string> users, List<string> books)
        {
            InitializeComponent();
            this.users = users;
            this.books = books;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string UsName = textBox1.Text;
            string BkName = textBox2.Text;
            
        }
    }
}
