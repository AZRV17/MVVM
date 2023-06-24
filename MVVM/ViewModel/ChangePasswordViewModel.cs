using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MVVM.ViewModel.Helpers;

namespace MVVM.ViewModel
{
    internal class ChangePasswordViewModel : BindingHelper
    {
        private string newPassword;

        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        public ICommand ChangePasswordCommand { get; }

        public ChangePasswordViewModel()
        {
            ChangePasswordCommand = new RelayCommand(ChangePassword);
        }

        private void ChangePassword()
        {
            // Изменение пароля пользователя
            Model.Model.ProfileManager profileManager = new Model.Model.ProfileManager();
            profileManager.ChangePassword(NewPassword);

            // Пароль успешно изменен, выполните дополнительные действия
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}