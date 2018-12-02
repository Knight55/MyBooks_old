﻿using System.Reactive.Disposables;
using System.Windows.Media.Imaging;
using MyBooks.Client.ViewModels;
using ReactiveUI;

namespace MyBooks.Client.WPF.Views
{
    /// <summary>
    /// Interaction logic for BookDetailsView.xaml
    /// </summary>
    public partial class BookDetailsView : ReactiveUserControl<BookDetailsViewModel>
    {
        public BookDetailsView()
        {
            InitializeComponent();

            this.WhenActivated(disposableRegistration =>
            {
                this.OneWayBind(ViewModel, vm => vm.Title, v => v.titleRun.Text)
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel, vm => vm.Genre, v => v.genreRun.Text)
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel, vm => vm.CoverUrl, v => v.coverImage.Source,
                        url => url == null ? null : new BitmapImage(url))
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel, vm => vm.Summary, v => v.summaryTextBox.Text)
                    .DisposeWith(disposableRegistration);

                this.BindCommand(ViewModel, vm => vm.GoBack, v => v.backButton)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
