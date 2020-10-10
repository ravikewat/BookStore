using Dnc.BookStore.Data;
using Dnc.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Dnc.BookStore.Repository
{
    public class LanguageRepository : ILanguageRepository

    {
        private BookStoreContext bookStoreContext = null;

        public LanguageRepository(BookStoreContext _bookStoreContext)
        {
            bookStoreContext = _bookStoreContext;
        }
        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await bookStoreContext.Languages.Select(item => new LanguageModel { Id = item.Id, Name = item.Name, GroupName=item.LanguageGroup.GroupName}).ToListAsync();    
        }

        public async Task<List<LanguageGroupModel>> GetLanguageGroups()
        {            
            return await bookStoreContext.LanguageGroups.Select(item => new LanguageGroupModel { Id = item.Id, GroupName = item.GroupName }).ToListAsync();

        }
    }
}
