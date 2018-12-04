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
using MyBooks.Client.ViewModels;
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
        public static AppBootStrapper BootStrapper;

        public App()
        {
            BootStrapper = new AppBootStrapper();
        }
    }
}
