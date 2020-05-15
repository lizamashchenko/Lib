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
        static Library Lib;
        public Form2(Library lib)
        {
            InitializeComponent();
            Lib = lib;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string usName = textBox1.Text;
            Library.User us = new Library.User(usName);
            string bkName = textBox2.Text;
            string bkAuthor = textBox3.Text;
            string bkTheme = textBox4.Text;
            Library.Book bk = new Library.Book(bkName, bkAuthor, bkTheme, true);
            if (Lib.users.Contains(us) && Lib.books.ContainsKey(bk))
            {
                us.myBooks.Remove(bk);
                Lib.books.Remove(bk);
                Lib.books.Add(bk, true);
                Hide();
                MessageBox.Show("Book have been succesfully returned");
            }
            else if (!Lib.users.Contains(us))
                label4.Visible = true;
            else if (!Lib.books.ContainsKey(bk))
                label3.Visible = true;
        }
    }
}
