using System;
using System.Linq;
using MyBooks.Bll.Entities;

namespace MyBooks.Bll.Context
{
    public static class SeedDatabase
    {
        public static void Seed(this MyBookContext context)
        {
            if (!context.Books.Any() && !context.Authors.Any())
            {
                var book = new Book
                {
                    Title = "The Way Of Kings",
                    Genre = Genre.Fantasy
                };
                var author = new Author
                {
                    Name = "Brandon Sanderson"
                };
                var writing = new Writing
                {
                    Book = book,
                    Author = author
                };
                var publisher = new Publisher
                {
                    Name = "Tor Books"
                };
                var edition = new Edition
                {
                    Book = book,
                    Publisher = publisher,
                    Format = Format.Hardcover,
                    IsbnNumber = "0765326353",
                    PublishDate = new DateTime(2010, 8, 31),
                    NumberOfPages = 1007
                };

                book.Writings.Add(writing);
                author.Writings.Add(writing);

                context.Books.Add(book);
                context.Authors.Add(author);
                context.Editions.Add(edition);
                context.Publishers.Add(publisher);

                context.SaveChanges();
            }
        }

        public static void RemoveAll(this MyBookContext context)
        {
            context.RemoveRange(context.Books);
            context.RemoveRange(context.Authors);
            context.RemoveRange(context.Editions);
            context.RemoveRange(context.Publishers);

            context.SaveChanges();
        }
    }
}