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
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public string CustomProperty { get; set; }
        [ViewData]
        public Book Book { get; set; }
        public ViewResult Index()
        {
            CustomProperty = "Custom Data";
            Title = "Home Page From Cotroller";
            Book = new Book() { Id = 1, Title ="Nazim"};


            return View();
        }
        public ViewResult AboutUs()
        {
            Title = "About Page From Cotroller";
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }

    }
}
