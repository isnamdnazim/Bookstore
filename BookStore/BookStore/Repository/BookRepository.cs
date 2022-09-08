using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<Book> GetAllBooks()
        {
            return DataSource();
        }
        public Book GetBook(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Book> SearchBook(string bookName, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(bookName) || x.Author.Contains(authorName)).ToList();
        }

        private List <Book> DataSource()
        {
            return new List<Book>()
            {
                new Book(){Id = 1, Title="MVC", Author="Nazim", Description="This is the description for MVC Book"},
                new Book(){Id = 2, Title="C#", Author="Md Uddin", Description="This is the description for C# Book"},
                new Book(){Id = 3, Title="JAVA", Author="Akash", Description="This is the description for JAVA Book"},
                new Book(){Id = 4, Title="Angular", Author="Nazim", Description="This is the description for Angular Book"},
                new Book(){Id = 5, Title="JavaScript", Author="Md Nazim", Description="This is the description for JavaScript Book"},
                new Book(){Id = 5, Title="Azure DevOps", Author="Md Emon", Description="This is the description for Azure DevOps Book"},
            };
        }
    }
}
