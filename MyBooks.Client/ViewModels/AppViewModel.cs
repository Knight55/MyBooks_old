using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
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
    public class AppViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        public AppViewModel()
        {
            Router = new RoutingState();
            Router.Navigate.Execute(new BookSearchViewModel(this));
        }
    }
}