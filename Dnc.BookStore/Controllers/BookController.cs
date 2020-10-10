using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Dnc.BookStore.Data;
using Dnc.BookStore.Model;
using Dnc.BookStore.Models;
using Dnc.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace Dnc.BookStore.Controllers
{
    public class BookController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        private IBookRepository bookRepository = null;
        private ILanguageRepository languageRepository = null;
        public BookController(IBookRepository _bookRepository, ILanguageRepository _languageRepository)
        {
            bookRepository = _bookRepository;
            languageRepository = _languageRepository;
        }

        public async Task<IActionResult> GetBooks()
        {
            var books = await bookRepository.GetBooks();
            return View(books);
        }

        public async Task<IActionResult> GetBook(int Id)
        {
            var book = await bookRepository.GetBook(Id);
            Title = "Book Detail - " + book.Title;
            dynamic data = new ExpandoObject();
            data.bookDetail = book;
            var books = await bookRepository.GetBooks();
            data.similarBooks = books.Take(3);
            return View(data);
        }

        public async Task<IActionResult> AddBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            //ViewBag.Languages = new SelectList(await languageRepository.GetLanguages(), "Id", "Name");
            ViewBag.Languages = await GetLanguages();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel book)
        {
            //ViewBag.Languages = new SelectList(await languageRepository.GetLanguages(), "Id", "Name");
            ViewBag.Languages = await GetLanguages();
            if (ModelState.IsValid)
            {
                Books bookToAdd = new Books
                {
                    Title = book.Title,
                    Description = book.Description,
                    Pages = book.Pages.HasValue ? book.Pages.Value : 0,
                    Author = book.Author,
                    Category = book.Category,
                    //Languages = book.Languages,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                };

                var bookLanguage = new List<BookLanguage>();
                foreach (var bookLang in book.MultiLanguage)
                {
                    bookLanguage.Add(new BookLanguage { BookId = book.Id, LanguageId = Convert.ToInt32(bookLang) });
                }

                bookToAdd.BookLanguage = bookLanguage;

                await bookRepository.AddBook(bookToAdd);

                if (bookToAdd.Id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = bookToAdd.Id });
                }
            }
            ModelState.AddModelError("", "Plese provide all required details to add new Book");
            return View(book);
        }

        private async Task<List<SelectListItem>> GetLanguages()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            var langGrpModelList = await languageRepository.GetLanguageGroups();

            var langGrpList = new List<SelectListGroup>();
            foreach (var item in langGrpModelList)
            {
                langGrpList.Add(new SelectListGroup() { Name = item.GroupName });
            }

            var langList = await languageRepository.GetLanguages();
            foreach (var item in langList)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Group = langGrpList.SingleOrDefault(g => g.Name == item.GroupName)
                });
            }
            return selectListItems;
        }
    }
}
