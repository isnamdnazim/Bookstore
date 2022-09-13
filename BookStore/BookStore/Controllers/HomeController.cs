using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController: Controller 
    {
        public ViewResult Index()
        {
            ViewData["property1"] = "Nazim";

            ViewData["property2"] = new Book() {Author= "Nazim", Id= 1 };

            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }

    }
}
