using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dnc.BookStore.Controllers
{
    public class HomeController : Controller
    {        
        public ViewResult Index()
        {
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
