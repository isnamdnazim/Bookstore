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
            ViewBag.Title = "Nazim";
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Nazim";
            ViewBag.Data = data;
            ViewBag.Type = new Book() { Id=5,Author = "This is Author" };
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
