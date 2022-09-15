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
                LanguageId= book.LanguageId,
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
                        LanguageId = book.LanguageId,
                        Language = book.Language.Name
                    });
                }
            }
            return books;
        }
        public async Task<Book> GetBook(int id)
        {
            //var book = await _context.Books.FindAsync(id);
            return await _context.Books.Where(x => x.Id == id)
               .Select(book => new Book()
               {
                   Author = book.Author,
                   Category = book.Category,
                   Title = book.Title,
                   Description = book.Description,
                   TotalPages = book.TotalPages,
                   Id = book.Id,
                   LanguageId = book.LanguageId,
                   Language = book.Language.Name
               }).FirstOrDefaultAsync();
             
        }
        public List<Book> SearchBook(string bookName, string authorName)
        {
            return null;
        }

        
    }
}
