using FastAccess.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastAccess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            _viewModel.HotKey.HotKeyPressed += ViewModel_HotKeyPressed;
        }

        private void ViewModel_HotKeyPressed() { 
            Application.Current.Dispatcher.Invoke(() => 
            { 
                Show(); 
                WindowState = WindowState.Normal;
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                Activate(); 
            }); 
        }

        protected override void OnStateChanged(EventArgs e) { 
            base.OnStateChanged(e); 
            if (WindowState == WindowState.Minimized) { 
                Hide(); 
            } 
        }
    }
}