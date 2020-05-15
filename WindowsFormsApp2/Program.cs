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

    }


    [Serializable]
    public class Library
    {
        public Dictionary<Book, bool> books;
        public List<User> users;
        public List<string> authors, themes;
        public Library(List<User> us, Dictionary<Book, bool> bk )
        {
            users = us;
            books = bk;
        }
        public class User
        {
            public string Name;
            public List<Book> myBooks;
            public User(string name)
            {
                Name = name;
            }
        }
        public class Book
        {
            public string Name, Author, Theme;
            public bool inLib;
            public Book(string name, string author, string theme, bool avail)
            {
                Name = name;
                Author = author;
                Theme = theme;
                inLib = avail;
            }
            public void Write()
            {
                Console.WriteLine("Name:" + Name);
                Console.Write(". Author:" + Author);
                Console.Write(". Theme:" + Theme);
            }
        }
        public void AddBook(Book bk)
        {
            if (!books.ContainsKey(bk))
                books.Add(bk, true);
            else
            {
                Console.WriteLine("This book is already in stock");
                return;
            }
            if (!authors.Contains(bk.Author))
                authors.Add(bk.Author);
            if (!themes.Contains(bk.Theme))
                themes.Add(bk.Theme);
        }
        public void AddUser(User us)
        {
            if (!users.Contains(us))
                users.Add(us);
            else
                Console.WriteLine("Such user already exists");
        }
        public void Return(Book bk)
        {
            if (!books.ContainsKey(bk))
                Console.WriteLine("We dont own such book");
            else
            {
                books.Remove(bk);
                books.Add(bk, true);
            }
        }
        public void Borrow(Book bk, User us)
        {
            bool inStock;
            books.TryGetValue(bk, out inStock);
            if (!books.ContainsKey(bk))
                Console.WriteLine("we dont own such book");
            else if (!inStock)
            {
                Console.WriteLine("Book will be back in stock soon");
            }
            else
            {
                books.Remove(bk);
                books.Add(bk, false);
                us.myBooks.Add(bk);
                Console.WriteLine("Book has been succesfully added to list of your books");
            }
        }
        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            foreach (KeyValuePair<Book, bool> bk in books)
            {
                Book x = bk.Key;
                list.Add(x);
            }
            return list;
        }
        public List<Book> GetBooks(string ath, string th, bool avail)
        {
            List<Book> list = new List<Book>();
            if (ath == "0" && th == "0" && !avail)
                GetAllBooks();
            else
                foreach (KeyValuePair<Book, bool> x in books)
                {
                    Book bk = x.Key;
                    bool inStock = x.Value;
                    if (bk.Author == ath || ath == "0" && bk.Theme == th || th == "0" && inStock == avail)
                        list.Add(bk);
                }
            return list;
        }
        public void ShowMyBooks(User us)
        {
            foreach (Book bk in us.myBooks)
            {
                bk.Write();
            }
        }
    }
}
