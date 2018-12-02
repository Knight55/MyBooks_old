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

            this.WhenActivated(disposableRegistration =>
            {
                this.Bind(ViewModel, vm => vm.Router, v => v.viewHost.Router)
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}
