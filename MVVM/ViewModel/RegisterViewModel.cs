using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MVVM.ViewModel.Helpers;

namespace MVVM.ViewModel
{
    internal class RegisterViewModel : BindingHelper
    {
        private string username;
        private string password;
        private string email;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            // Создание нового пользователя
            Model.Model.User newUser = new Model.Model.User
            {
                Login = Username,
                Password = Password
            };

            // Регистрация пользователя через ProfileManager
            Model.Model.ProfileManager profileManager = new Model.Model.ProfileManager();
            bool isRegistered = profileManager.RegisterUser(newUser);

            if (isRegistered)
            {
                // Пользователь успешно зарегистрирован, выполните дополнительные действия
            }
            else
            {
                // Возникла ошибка при регистрации пользователя, выполните дополнительные действия
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}