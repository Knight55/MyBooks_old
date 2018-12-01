using System.Reactive.Disposables;
using MyBooks.Client.ViewModels;
using ReactiveUI;

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
            ViewModel = new AppViewModel();

            // We create our bindings here. These are the code behind bindings which allow 
            // type safety. The bindings will only become active when the Window is being shown.
            // We register our subscription in our disposableRegistration, this will cause 
            // the binding subscription to become inactive when the Window is closed.
            // The disposableRegistration is a CompositeDisposable which is a container of 
            // other Disposables. We use the DisposeWith() extension method which simply adds 
            // the subscription disposable to the CompositeDisposable.
            this.WhenActivated(disposableRegistration =>
            {
                this.OneWayBind(ViewModel,
                        viewModel => viewModel.Results,
                        view => view.bookListBox.ItemsSource)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
