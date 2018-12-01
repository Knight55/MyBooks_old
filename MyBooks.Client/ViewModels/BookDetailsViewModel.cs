using System;
using MyBooks.Client.Models;
using ReactiveUI;

namespace MyBooks.Client.ViewModels
{
    public class BookDetailsViewModel : ReactiveObject
    {
        private readonly Book _book;

        public BookDetailsViewModel(Book book)
        {
            _book = book;
        }

        public Uri CoverUrl => new Uri(_book.CoverUrl);
        public string Title => _book.Title;
        public string Summary => _book.Summary;
        public string Genre => _book.Genre;
    }
}