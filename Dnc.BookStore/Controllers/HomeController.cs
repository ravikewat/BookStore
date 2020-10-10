using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dnc.BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        public ViewResult Index()
        {
            dynamic data = new System.Dynamic.ExpandoObject();
            data.Title = "Guest User";
            Title = "Home";
            ViewBag.Data = data;

            

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
