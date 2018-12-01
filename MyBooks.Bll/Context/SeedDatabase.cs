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
                var book_wayofkings = new Book
                {
                    Title = "The Way Of Kings",
                    CoverImagePath = "wayofkings.jpg",
                    Summary = @"Roshar is a world of stone and storms. Uncanny tempests of incredible power sweep across the rocky terrain so frequently that they have shaped ecology and civilization alike. Animals hide in shells, trees pull in branches, and grass retracts into the soilless ground. Cities are built only where the topography offers shelter.

It has been centuries since the fall of the ten consecrated orders known as the Knights Radiant,
                    but their Shardblades and Shardplate remain: mystical swords and suits of armor that transform ordinary men into near-invincible warriors.Men trade kingdoms for Shardblades.Wars were fought for them, and won by them.


One such war rages on a ruined landscape called the Shattered Plains.There, Kaladin, who traded his medical apprenticeship for a spear to protect his little brother, has been reduced to slavery.In a war that makes no sense, where ten armies fight separately against a single foe, he struggles to save his men and to fathom the leaders who consider them expendable.


Brightlord Dalinar Kholin commands one of those other armies.Like his brother, the late king, he is fascinated by an ancient text called The Way of Kings.Troubled by over - powering visions of ancient times and the Knights Radiant, he has begun to doubt his own sanity.


Across the ocean, an untried young woman named Shallan seeks to train under an eminent scholar and notorious heretic, Dalinar's niece, Jasnah. Though she genuinely loves learning, Shallan's motives are less than pure.As she plans a daring theft, her research for Jasnah hints at secrets of the Knights Radiant and the true cause of the war.


The result of over ten years of planning, writing, and world - building, The Way of Kings is but the opening movement of the Stormlight Archive, a bold masterpiece in the making.


Speak again the ancient oaths:


Life before death.
Strength before weakness.
Journey before Destination.

and return to men the Shards they once bore.

The Knights Radiant must stand again.",
                    Genre = Genre.Fantasy
                };
                var book_redrising = new Book
                {
                    Title = "Red Rising",
                    CoverImagePath = "redrising.jpg",
                    Genre = Genre.ScienceFiction
                };
                var book_theeyeoftheworld = new Book
                {
                    Title = "The Eye of the World",
                    CoverImagePath = "theeyeoftheworld.jpg",
                    Genre = Genre.Fantasy
                };
                var book_thefinalempire = new Book
                {
                    Title = "The Final Empire",
                    CoverImagePath = "thefinalempire.jpg",
                    Genre = Genre.Fantasy
                };
                var book_thepillarsoftheearth = new Book
                {
                    Title = "The Pillars of the Earth",
                    CoverImagePath = "pillarsoftheearth.jpg",
                    Genre = Genre.Historical
                };

                var author_brandonsanderson = new Author
                {
                    Name = "Brandon Sanderson"
                };
                var author_piercebrown = new Author
                {
                    Name = "Pierce Brown"
                };
                var author_robertjordan = new Author
                {
                    Name = "Robert Jordan"
                };
                var author_kenfollett = new Author
                {
                    Name = "Ken Follett"
                };

                var bookAuthor_wok_bs = new BookAuthor
                {
                    Book = book_wayofkings,
                    Author = author_brandonsanderson
                };
                var bookAuthor_rr_pb = new BookAuthor
                {
                    Book = book_redrising,
                    Author = author_piercebrown
                };
                var bookAuthor_teotw_rj = new BookAuthor
                {
                    Book = book_theeyeoftheworld,
                    Author = author_robertjordan
                };
                var bookAuthor_tfe_bs = new BookAuthor
                {
                    Book = book_thefinalempire,
                    Author = author_brandonsanderson
                };
                var bookAuthor_tpote_kf = new BookAuthor
                {
                    Book = book_thepillarsoftheearth,
                    Author = author_kenfollett
                };

                var publisher = new Publisher
                {
                    Name = "Tor Books"
                };

                var edition = new Edition
                {
                    Book = book_wayofkings,
                    Publisher = publisher,
                    Format = Format.Hardcover,
                    IsbnNumber = "0765326353",
                    PublishDate = new DateTime(2010, 8, 31),
                    NumberOfPages = 1007
                };

                var rating_wok = new Rating
                {
                    Book = book_wayofkings,
                    Value = 4
                };
                var rating_teotw = new Rating
                {
                    Book = book_theeyeoftheworld,
                    Value = 5
                };

                book_wayofkings.BookAuthors.Add(bookAuthor_wok_bs);
                book_redrising.BookAuthors.Add(bookAuthor_rr_pb);
                book_theeyeoftheworld.BookAuthors.Add(bookAuthor_teotw_rj);
                book_thefinalempire.BookAuthors.Add(bookAuthor_tfe_bs);
                book_thepillarsoftheearth.BookAuthors.Add(bookAuthor_tpote_kf);

                context.Books.Add(book_wayofkings);
                context.Books.Add(book_redrising);
                context.Books.Add(book_theeyeoftheworld);
                context.Books.Add(book_thefinalempire);
                context.Books.Add(book_thepillarsoftheearth);

                context.Authors.Add(author_brandonsanderson);
                context.Authors.Add(author_piercebrown);
                context.Authors.Add(author_robertjordan);
                context.Authors.Add(author_kenfollett);

                context.Ratings.Add(rating_wok);
                context.Ratings.Add(rating_teotw);
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