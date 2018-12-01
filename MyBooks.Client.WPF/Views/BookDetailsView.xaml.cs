using System.Reactive.Disposables;
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
                this.OneWayBind(ViewModel,
                        viewModel => viewModel.Title,
                        view => view.titleRun.Text)
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel,
                        viewModel => viewModel.Genre,
                        view => view.genreRun.Text)
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel,
                        viewModel => viewModel.CoverUrl,
                        view => view.coverImage.Source,
                        url => url == null ? null : new BitmapImage(url))
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
