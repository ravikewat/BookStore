using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dnc.BookStore.Model;
using Dnc.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dnc.BookStore.Controllers
{
    public class BookController : Controller
    {
        private BookRepository bookRepository = null;
        public BookController()
        {
            bookRepository = new BookRepository();
        }

        public IActionResult GetBooks()
        {
            var books= bookRepository.GetBooks();
            return View(books);
        }

        public IActionResult GetBook(int Id)
        {
            var book= bookRepository.GetBook(Id);
            return View(book);
        }
    }
}
