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
                new Book(){Id = 1, Title="MVC", Author="Nazim"},
                new Book(){Id = 2, Title="C#", Author="Nazim"},
                new Book(){Id = 3, Title="JAVA", Author="Nazim"},
                new Book(){Id = 4, Title="Angular", Author="Nazim"},
            };
        }
    }
}
