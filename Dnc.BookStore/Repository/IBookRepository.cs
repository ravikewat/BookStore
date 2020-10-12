using Dnc.BookStore.Data;
using Dnc.BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.BookStore.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetBooks();

        Task<List<BookModel>> GetTopBooks(int count);

        Task<BookModel> GetBook(int Id);

        List<BookModel> SearchBooks(string Title);

        Task<int> AddBook(Books book);
    }
}
