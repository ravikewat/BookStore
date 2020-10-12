using Dnc.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dnc.BookStore.Components
{
    public class TopBookViewComponent : ViewComponent
    {
        private IBookRepository bookRepository = null;
        public TopBookViewComponent(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var books =await bookRepository.GetTopBooks(count);
            return View(books);
        }
    }
}
