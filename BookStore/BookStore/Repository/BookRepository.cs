using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AddNewBook(Book book)
        {
            var newBook = new Books()
            {
                Author = book.Author,
                CreatedOn = DateTime.UtcNow,
                Description = book.Description,
                Title = book.Title,
                Language= book.Language,
                TotalPages = book.TotalPages.HasValue ? book.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = new List<Book>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new Book() { 
                        Author = book.Author,
                        Category = book.Category,
                        Title = book.Title,
                        Description = book.Description,
                        TotalPages = book.TotalPages,
                        Id = book.Id,
                        Language = book.Language
                    });
                }
            }
            return books;
        }
        public async Task<Book> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
             //_context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
             if(book != null)
            {
                var bookDetails = new Book()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Title = book.Title,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    Id = book.Id,
                    Language = book.Language
                };
                return bookDetails;
            }
            return null;
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
