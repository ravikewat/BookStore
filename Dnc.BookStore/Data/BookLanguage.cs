using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.BookStore.Data
{
    public class BookLanguage
    {
        public int BookId { get; set; }
        public int LanguageId { get; set; }
        public Books Book { get; set; }
        public Languages Language { get; set; }

    }
}
