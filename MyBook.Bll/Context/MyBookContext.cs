using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBook.Bll.Entities;

namespace MyBook.Bll.Context
{
    public class MyBookContext : DbContext
    {
        public MyBookContext(DbContextOptions<MyBookContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Edition>()
                .Property(e => e.Format)
                .HasConversion<string>()
                .HasDefaultValue(Format.Paperback);

            modelBuilder
                .Entity<Book>()
                .Property(b => b.Genre)
                .HasConversion<string>()
                .HasDefaultValue(Genre.Fantasy);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}