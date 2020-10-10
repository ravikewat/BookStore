using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.BookStore.Data
{
    public class LanguageGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<Languages> Languages {get; set;}
    }
}
