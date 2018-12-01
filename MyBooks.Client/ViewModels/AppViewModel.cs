using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Timers;
using DynamicData.Binding;
using MyBooks.Client.Services;
using ReactiveUI;
using Refit;

namespace MyBooks.Client.ViewModels
{
    public class AppViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<IEnumerable<BookDetailsViewModel>> _results;
        public IEnumerable<BookDetailsViewModel> Results { get; }

        private readonly ObservableAsPropertyHelper<bool> _isAvailable;
        public bool IsAvailable => _isAvailable.Value;

        public int Temp { get; set; }

        public AppViewModel()
        {
            _isAvailable = this
                .WhenAnyValue(x => x.Results)
                .Select(results => results != null)
                .ToProperty(this, x => x.IsAvailable);

            // TODO: Modify this
            _results = this
                .WhenAnyValue(x => x.Temp)
                .Do(x => Debug.WriteLine($"New random number: {x}"))
                .SelectMany(GetBooks)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.Results);

            var timer = new Timer(2000);
            var random = new Random();
            timer.Elapsed += (sender, args) => Temp = random.Next(1, 10);
            timer.Start();
        }

        private async Task<IEnumerable<BookDetailsViewModel>> GetBooks(int randomNumber)
        {
            var myBooksApiService = RestService.For<IMyBookApiService>("http://localhost:5000");
            var books = await myBooksApiService.GetBooksAsync();
            return books.Select(b => new BookDetailsViewModel(b));
        }
    }
}