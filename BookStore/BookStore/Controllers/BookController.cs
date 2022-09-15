using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository  _bookRepository= null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await  _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-store/{id}", Name = "getAllBook")]
        public async Task<ViewResult> GetBook(int id)
        {
            
            var data = await _bookRepository.GetBook(id);
            return View(data);
        }

        public ViewResult SearchBook(string bookName, string authorName)
        {
            var data = _bookRepository.SearchBook(bookName, authorName);
            return View();
        }

        public ViewResult AddNewBook( bool isSuccess = false, int bookId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(Book book)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            //ViewBag.isSuccess = false;
            //ViewBag.BookId = 0;

            return View();
        }

    }
}
