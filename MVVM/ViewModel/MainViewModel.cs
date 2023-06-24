using MVVM.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static MVVM.Model.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace MVVM.ViewModel
{
    internal class MainViewModel : BindingHelper
    {
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
                App.login = username;
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

        public ICommand LoginCommand { get; }

        public MainViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            // Вход пользователя
            ProfileManager profileManager = new ProfileManager();
            bool isLoggedIn = profileManager.Login(Username, Password);

            if (isLoggedIn)
            {
                // Пользователь успешно вошел, выполните дополнительные действия
                MessageBox.Show("Ура");
            }
            else
            {
                // Возникла ошибка при входе пользователя, выполните дополнительные действия
                MessageBox.Show("Boolshit");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
