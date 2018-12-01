using System.Reactive.Disposables;
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
                        view => view.titleTextBlock.Text)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
