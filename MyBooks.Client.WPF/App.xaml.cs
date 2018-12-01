using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using MyBooks.Client.Services;
using ReactiveUI;
using Refit;
using Splat;

namespace MyBooks.Client.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // A helper method that will register all classes that derive off IViewFor
            // into our dependency injection container. ReactiveUI uses Splat for it's
            // dependency injection by default, but you can override this if you like.
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
        }
    }
}
