using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using DynamicData.Binding;
using MyBooks.Client.Models;
using MyBooks.Client.Services;
using ReactiveUI;
using Refit;

namespace MyBooks.Client.ViewModels
{
    public class AppViewModel : ReactiveObject
    {
        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
        }

        private readonly ObservableAsPropertyHelper<IEnumerable<Book>> _results;
        public IEnumerable<Book> Results => _results.Value;

        private readonly ObservableAsPropertyHelper<bool> _isAvailable;
        public bool IsAvailable => _isAvailable.Value;

        public AppViewModel()
        {
            // TODO: Modify this
            _results = this
                .WhenAnyValue(x => x.SearchTerm)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Select(term => term?.Trim())
                .DistinctUntilChanged()
                .SelectMany(GetBooks)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.Results);

            _isAvailable = this
                .WhenAnyValue(x => x.Results)
                .Select(results => results != null)
                .ToProperty(this, x => x.IsAvailable);
        }

        private async Task<IEnumerable<Book>> GetBooks(string searchTerm, CancellationToken token)
        {
            var myBooksApiService = RestService.For<IMyBookApiService>("http://localhost:5000");

            List<Book> books;
            if (string.IsNullOrEmpty(searchTerm))
            {
                books = await myBooksApiService.GetBooksAsync().ConfigureAwait(false);
            }
            else
            {
                books = await myBooksApiService.SearchBooksAsync(searchTerm).ConfigureAwait(false);
            }
            return books;
        }
    }
}