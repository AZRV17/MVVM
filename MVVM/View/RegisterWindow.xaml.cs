using System.Windows;
using System.Windows.Input;
using MVVM.ViewModel;

namespace MVVM.View
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as RegisterViewModel;
            if (viewModel != null && viewModel.RegisterCommand.CanExecute(null))
            {
                viewModel.RegisterCommand.Execute(null);
            }
        }
    }
}