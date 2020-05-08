using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
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
    }
}
