using Dnc.BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.BookStore.Repository
{
    public class BookRepository
    {
        private static List<BookModel> bookModels = new List<BookModel>
        {
            new BookModel {Id = 1, Title="Asp.Net", Author="Author 1", Description="Asp.net book awesome to learn, In this video, we will design and develop a fully functional product details page. This product page will be responsive and dynamic. We will display images slideshow (bootstrap carousel) along with details of product (book).", Category="Technical", Language="English", Pages=101},
            new BookModel {Id = 2, Title="C#", Author="Author 2", Description="C# book awesome to learn, In this video, we will design and develop a fully functional product details page. This product page will be responsive and dynamic. We will display images slideshow (bootstrap carousel) along with details of product (book).", Category="Technical", Language="English", Pages=101},
            new BookModel {Id = 3, Title="MVC", Author="Author 3", Description="MVC book awesome to learn, In this video, we will design and develop a fully functional product details page. This product page will be responsive and dynamic. We will display images slideshow (bootstrap carousel) along with details of product (book).", Category="Technical", Language="English", Pages=101},
            new BookModel {Id = 4, Title="SQL", Author="Author 4", Description="SQL book awesome to learn, In this video, we will design and develop a fully functional product details page. This product page will be responsive and dynamic. We will display images slideshow (bootstrap carousel) along with details of product (book).", Category="Technical", Language="English", Pages=101},
            new BookModel {Id = 5, Title="Angular", Author="Author 5", Description="Angular book awesome to learn, In this video, we will design and develop a fully functional product details page. This product page will be responsive and dynamic. We will display images slideshow (bootstrap carousel) along with details of product (book).", Category="Technical", Language="English", Pages=101},
        };
        public List<BookModel> GetBooks()
        {
            return bookModels;
        }

        public BookModel GetBook(int Id)
        {
            return bookModels.Find(b=> b.Id == Id);
        }

        public List<BookModel> SearchBooks(string Title)
        {
            return bookModels.FindAll(b => b.Title.Contains(Title)); ;
        }
    }
}
