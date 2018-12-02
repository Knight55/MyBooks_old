using System;
using System.Diagnostics;
using System.Reactive;
using MyBooks.Client.Models;
using ReactiveUI;

namespace MyBooks.Client.ViewModels
{
    public class BookDetailsViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "bookDetails";
        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, Unit> GoBack { get; }

        private readonly Book _book;
        public Uri CoverUrl => new Uri(_book.CoverUrl);
        public string Title => _book.Title;
        public string Summary => _book.Summary ?? "No summary";
        public string Genre => _book.Genre;

        public BookDetailsViewModel(IScreen hostScreen, Book book)
        {
            HostScreen = hostScreen;
            _book = book;
            GoBack = ReactiveCommand.Create(() =>
            {
                HostScreen.Router.NavigateBack.Execute();
            });
        }
    }
}