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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = authors;
            comboBox2.DataSource = themes;
        }
        static Dictionary<Book, bool> books;
        static List<User> users;
        static List<string> authors, themes;

        private void Button1_Click(object sender, EventArgs e)
        {
            string ath, th;
            if (comboBox1.SelectedItem != null)
            {
                ath = comboBox1.SelectedItem.ToString();
            }
            else
            {
                ath = "0";
            }
            if (comboBox1.SelectedItem != null)
            {
                th = comboBox2.SelectedItem.ToString();
            }
            else
            {
                th = "0";
            }

            foreach (var x in from KeyValuePair<Book, bool> x in books
                              where x.Value == checkBox1.Checked && x.Key.Author == ath && x.Key.Theme == th
                              select x)
                listBox1.Items.Add(x.Key.Name);

            listBox1.Visible = true;
        }
        class Book
        {
            public string Name, Author, Theme;
            public bool inLibrary;
            public Book(string name, string author, string theme)
            {
                Name = name;
                Author = author;
                Theme = theme;
            }
        }
        class User
        {
            public string Name;
            public List<Book> MyBooks;
            public User(string name)
            {
                Name = name;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string ath = textBox2.Text;
            string th = textBox4.Text;
            Book bk = new Book(name, ath, th);
            bk.inLibrary = true;
            if (!themes.Contains(th))
                themes.Add(th);
            if (!authors.Contains(ath))
                authors.Add(ath);
            if (!books.ContainsKey(bk))
                books.Add(bk, true);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            User us = new User(name);
            if (!users.Contains(us))
                users.Add(us);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(users, books);
            form.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            List<Book> myBooks = null;
            if(textBox3.Text!=null)
            {
                string name = textBox3.Text;
                foreach (User us in users)
                {
                    if (us.Name == name)
                    {
                        myBooks = us.MyBooks;
                        return;
                    }
                }
            }
            foreach (Book bk in myBooks)
                listBox2.Items.Add(bk.Name);
        }
    }
}
