using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

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
            LoadData();
            comboBox1.DataSource = lib.authors;
            comboBox2.DataSource = lib.themes;
        }
        static Library lib;

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
            bool avail = checkBox1.Checked;
            foreach (Library.Book bk in lib.GetBooks(ath, th, avail))
            {
                listBox1.Items.Add(bk);
            }
            listBox1.Visible = true;
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string ath = textBox2.Text;
            string th = textBox4.Text;
            Library.Book bk = new Library.Book(name, ath, th, true);
            bk.inLib = true;
            if (!lib.themes.Contains(th))
                lib.themes.Add(th);
            if (!lib.authors.Contains(ath))
                lib.authors.Add(ath);
            if (!lib.books.ContainsKey(bk))
                lib.books.Add(bk, true);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            Library.User us = new Library.User(name);
            if (!lib.users.Contains(us))
                lib.users.Add(us);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(lib);
            form.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(lib);
            form.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            List<Library.Book> myBooks = null;
            if(textBox3.Text!=null)
            {
                string name = textBox3.Text;
                foreach (Library.User us in lib.users)
                {
                    if (us.Name == name)
                    {
                        myBooks = us.myBooks;
                        return;
                    }
                }
            }
            foreach (Library.Book bk in myBooks)
                listBox2.Items.Add(bk.Name);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }
        public void SaveData()
        {
            XmlSerializer usSer = new XmlSerializer(typeof(List<Library.User>));
            XmlSerializer bkSer = new XmlSerializer(typeof(Dictionary<Library.Book, bool>));
            using (FileStream fs = new FileStream("../users.xml", FileMode.OpenOrCreate))
                usSer.Serialize(fs, lib.users);
            using (FileStream fs2 = new FileStream("../books.xml", FileMode.OpenOrCreate))
                bkSer.Serialize(fs2, lib.books);
        }
        public void LoadData()
        {
            List<Library.User> users;
            Dictionary<Library.Book, bool> books;
            XmlSerializer usSer = new XmlSerializer(typeof(List<Library.User>));
            XmlSerializer bkSer = new XmlSerializer(typeof(Dictionary<Library.Book, bool>));
            using (FileStream fs = new FileStream("../users.xml", FileMode.OpenOrCreate))
               users = (List<Library.User>)usSer.Deserialize(fs);
            using (FileStream fs2 = new FileStream("../books.xml", FileMode.OpenOrCreate))
                books = (Dictionary<Library.Book, bool>)bkSer.Deserialize(fs2);
            lib.users = users;
            lib.books = books;
        }
    }
}
