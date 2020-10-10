using Microsoft.EntityFrameworkCore;

namespace Dnc.BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

        public DbSet<Languages> Languages { get; set; }

        public DbSet<BookLanguage> BookLanguages { get; set; }

        public DbSet<LanguageGroup> LanguageGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLanguage>().HasKey(sc => new { sc.BookId, sc.LanguageId });
        }
    }
}
