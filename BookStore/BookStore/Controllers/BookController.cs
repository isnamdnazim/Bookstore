using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository  _bookRepository= null;
        private readonly LanguageRepository  _languageRepository= null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, 
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
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

        public async Task<ViewResult>  AddNewBook( bool isSuccess = false, int bookId = 0)
        {
            var model = new Book()
            {
                //Language = "1"
            };

            ViewBag.language = new SelectList( await _languageRepository.GetLanguages(),"Id","Name");

            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(Book book)
        {
            if (ModelState.IsValid)
            {
                if(book.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    folder += book.CoverPhoto.FileName+Guid.NewGuid().ToString();
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await book.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                int id = await _bookRepository.AddNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }

        


    }
}
