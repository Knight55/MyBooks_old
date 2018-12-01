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

        public string Title => _book.Title;
    }
}