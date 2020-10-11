using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string Category { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<BookLanguage> BookLanguage { get; set; }
        public string BookCoverUrl { get; set; }
        public string BookPdfUrl { get; set; }
        public ICollection<BookGallery> bookGallery { get; set; }
    }
}
