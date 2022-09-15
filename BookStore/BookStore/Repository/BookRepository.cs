using BookStore.Data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public int AddNewBook(Book book)
        {
            var newBook = new Books()
            {
                Author = book.Author,
                CreatedOn = DateTime.UtcNow,
                Description = book.Description,
                Title = book.Title,
                TotalPages = book.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();

            return newBook.Id;

        }

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
                new Book(){Id = 1, Title="MVC", Author="Nazim", Description="This is the description for MVC Book", Category="Framework", Language="English", TotalPages=135},
                new Book(){Id = 2, Title="C#", Author="Md Uddin", Description="This is the description for C# Book", Category="Programming", Language="Bangla", TotalPages=138},
                new Book(){Id = 3, Title="JAVA", Author="Akash", Description="This is the description for JAVA Book", Category="Programming", Language="English", TotalPages=142},
                new Book(){Id = 4, Title="Angular", Author="Nazim", Description="This is the description for Angular Book", Category="Framework", Language="English", TotalPages=146},
                new Book(){Id = 5, Title="JavaScript", Author="Md Nazim", Description="This is the description for JavaScript Book", Category="Programming", Language="English", TotalPages=149},
                new Book(){Id = 6, Title="Azure DevOps", Author="Md Emon", Description="This is the description for Azure DevOps Book", Category="DevOps", Language="English", TotalPages=189},
            };
        }
    }
}
