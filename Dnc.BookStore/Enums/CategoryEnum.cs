using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.BookStore.Enums
{
    public enum CategoryEnum
    {
        [Display(Name ="Programming Technlogies")]
        Technoloiges,
        Fiction,
        Action,
        Romance
    }
}
