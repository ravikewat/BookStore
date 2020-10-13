using Dnc.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dnc.BookStore.Controllers
{
    [Route("{controller}/{action}/{id?}")]
    public class HomeController : Controller
    {
        IOptions<BookAlert> _bookAlertConfig = null;
        public HomeController(IOptions<BookAlert> bookAlertConfig)
        {
            _bookAlertConfig = bookAlertConfig;
        }

        [ViewData]
        public string Title { get; set; }
        [Route("~/")]
        public ViewResult Index()
        {

            dynamic data = new System.Dynamic.ExpandoObject();
            data.Title = "Guest User";
            Title = "Home";
            ViewBag.Data = data;

            

            return View();
        }

        [Route("~/about-us")]
        public ViewResult AboutUs()
        {
            return View();
        }

        [Route("~/contact-us")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
