using BooksAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Infrastructure.Data.Contexts
{
    public class BooksContext : DbContext
    {
        public BooksContext()
        {
        }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}