﻿using System.Reactive.Disposables;
using System.Windows;
using MyBooks.Client.ViewModels;
using ReactiveUI;
using Splat;

namespace MyBooks.Client.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<AppViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new AppViewModel(Locator.Current.GetService<IScreen>());

            this.WhenActivated(disposableRegistration =>
            {
                this.Bind(ViewModel, vm => vm.HostScreen.Router, v => v.viewHost.Router)
                    .DisposeWith(disposableRegistration);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnExit(object sender, RoutedEventArgs args)
        {
            Application.Current.Shutdown();
        }
    }
}
