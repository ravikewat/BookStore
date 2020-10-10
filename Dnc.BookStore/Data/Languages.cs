using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.BookStore.Data
{
    public class Languages
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public ICollection<BookLanguage> BookLanguage { get; set; }
        public LanguageGroup LanguageGroup { get; set; }
    }
}
