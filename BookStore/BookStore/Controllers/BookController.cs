using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var model = new Book()
            {
                //Language = "1"
            };
            //ViewBag.Language = new SelectList (new List<string>() {"Bangla", "English", "Arabic" });
            //ViewBag.Language = new SelectList (GetLanguage(),"Id","Text");
            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem() 
            //{ 
            //    Text = x.Text ,
            //    Value = x.Id.ToString()
            //}).ToList();

            //var group1 = new SelectListGroup() {Name = "Group 1" };
            //var group2 = new SelectListGroup() {Name = "Group 2" };
            //var group3 = new SelectListGroup() {Name = "Group 3" };

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Value="1",Text="English",Group=group1},    
            //    new SelectListItem(){Value="2",Text="Bangla",Group=group1},    
            //    new SelectListItem(){Value="3",Text="Arabic",Group= group1},    
            //    new SelectListItem(){Value="4",Text="Hindi",Group= group2},    
            //    new SelectListItem(){Value="5",Text="Urdu",Group=group2},    
            //    new SelectListItem(){Value="6",Text="Tamil",Group=group3},    
            //    new SelectListItem(){Value="7",Text="Franch",Group=group3},    
            //};
            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Value="1",Text="English"},
            //    new SelectListItem(){Value="2",Text="Bangla"},
            //    new SelectListItem(){Value="3",Text="Arabic"},
            //    new SelectListItem(){Value="4",Text="Hindi"},
            //    new SelectListItem(){Value="5",Text="Urdu"},
            //    new SelectListItem(){Value="6",Text="Tamil"},
            //    new SelectListItem(){Value="7",Text="Franch"},
            //};

            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
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
            //ViewBag.Language = new SelectList(new List<string>() { "Bangla", "English", "Arabic" });

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Value="1",Text="English"},
            //    new SelectListItem(){Value="2",Text="Bangla"},
            //    new SelectListItem(){Value="3",Text="Arabic"},
            //    new SelectListItem(){Value="4",Text="Hindi"},
            //    new SelectListItem(){Value="5",Text="Urdu"},
            //    new SelectListItem(){Value="6",Text="Tamil"},
            //    new SelectListItem(){Value="7",Text="Franch"},
            //};
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");



            //ModelState.AddModelError("","This is Custom Error");
            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){Id=1, Text="Bangla"},
                new LanguageModel(){Id=2, Text="English"},
                new LanguageModel(){Id=3, Text="Arabic"},
            };
        }


    }
}
