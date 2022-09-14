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
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data =  _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-store/{id}", Name = "getAllBook")]
        public ViewResult GetBook(int id)
        {
            
            var data =  _bookRepository.GetBook(id);
            return View(data);
        }

        public ViewResult SearchBook(string bookName, string authorName)
        {
            var data = _bookRepository.SearchBook(bookName, authorName);
            return View();
        }

    }
}
