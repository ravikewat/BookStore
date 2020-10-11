using Dnc.BookStore.Data;
using Dnc.BookStore.Model;
using Dnc.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.BookStore.Repository
{
    public class BookRepository : IBookRepository
    {

        private BookStoreContext bookStoreContext = null;

        public BookRepository(BookStoreContext _bookStoreContext)
        {
            bookStoreContext = _bookStoreContext;
        }

        public async Task<List<BookModel>> GetBooks()
        {
            List<BookModel> allbookModels = new List<BookModel>();
            var books = await bookStoreContext.Books.Include(b => b.BookLanguage).ToListAsync();
            if (books?.Any() == true)
            {

                foreach (var item in books)
                {
                    allbookModels.Add(new BookModel { Author = item.Author, Category = item.Category, Description = item.Description, Id = item.Id, Pages = item.Pages, Title = item.Title, MultiLanguage = item.BookLanguage.Select(s => s.LanguageId.ToString()).ToList(), BookCoverUrl = item.BookCoverUrl, BookPdfUrl= item.BookPdfUrl });
                }
            }
            return allbookModels;
        }

        private void GetBookLanguages(ICollection<BookLanguage> bookLanguages)
        {
            var data = (from users in bookLanguages
                        select users.LanguageId).ToList();
        }

        public async Task<BookModel> GetBook(int Id)
        {
            var item = await bookStoreContext.Books.Include(bgl=>bgl.bookGallery).Include(b => b.BookLanguage).ThenInclude(bl=> bl.Language).FirstOrDefaultAsync(b => b.Id == Id);
            
            return new BookModel { Author = item.Author, Category = item.Category, Description = item.Description, Id = item.Id, Pages = item.Pages, Title = item.Title, MultiLanguage = item.BookLanguage.Select(s => s.LanguageId.ToString()).ToList(), MultiLanguageText = string.Join(", ", item.BookLanguage.Select(s => s.Language.Name)), BookCoverUrl = item.BookCoverUrl, BookPdfUrl= item.BookPdfUrl, BookGalleries = (from bgl in item.bookGallery select new BookGalleryModel { Name = bgl.Name, Url = bgl.Url }).ToList() };
        }

        public List<BookModel> SearchBooks(string Title)
        {
            return null;
        }

        public async Task<int> AddBook(Books book)
        {
            await bookStoreContext.Books.AddAsync(book);
            await bookStoreContext.SaveChangesAsync();
            return book.Id;
        }
    }
}
