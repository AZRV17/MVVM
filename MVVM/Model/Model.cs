using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.Model
{
    internal class Model
    {
        // Модель пользователя
        public class User
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

        // Модель управления профилем
        public class ProfileManager
        {
            public User CurrentUser { get; set; }

            public bool IsLoggedIn => CurrentUser != null;

            public bool RegisterUser(User user)
            {
                // Проверка на существование пользователя
                if (IsUserExists(user.Login))
                    return false;

                // Регистрация нового пользователя
                // Сохранение данных в JSON файл
                SaveUserToJson(user);

                MessageBox.Show("Заебись");

                return true;
            }

            public bool Login(string username, string password)
            {
                // Проверка на существование пользователя и правильность пароля
                User user = GetUserByUsername(username);
                
                if (user != null && user.Password == password)
                {
                    CurrentUser = user;
                    return true;
                }

                return false;
            }

            public void ChangePassword(string newPassword)
            {
                if (CurrentUser != null)
                {
                    // Изменение пароля текущего пользователя
                    CurrentUser.Password = newPassword;

                    // Обновление данных в JSON файле
                    UpdateUserInJson(CurrentUser);
                }
                else
                {
                    MessageBox.Show("Ошибка при изменении пароля");
                }
            }

            private bool IsUserExists(string username)
            {
                // Проверка на существование пользователя в JSON файле
                string filePath = "C:/Users/alexa/OneDrive/Рабочий стол/Практическая/MVVM/MVVM/users.json";

                if (File.Exists(filePath))
                {
                    MessageBox.Show("file exist");
                    string jsonData = File.ReadAllText(filePath);
                    var users = JsonConvert.DeserializeObject<List<User>>(jsonData);
                    MessageBox.Show(users[0].Login);

                    return users.Any(user => user.Login == username);
                }

                return false;
            }

            private User GetUserByUsername(string username)
            {
                // Получение пользователя из JSON файла по его имени пользователя
                string filePath = "C:/Users/alexa/OneDrive/Рабочий стол/Практическая/MVVM/MVVM/users.json";

                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    var users = JsonConvert.DeserializeObject<List<User>>(jsonData);

                    return users.FirstOrDefault(user => user.Login == username);
                }
              
                return null;
            }

            private void SaveUserToJson(User user)
            {
                // Сохранение пользователя в JSON файл
                string filePath = "C:/Users/alexa/OneDrive/Рабочий стол/Практическая/MVVM/MVVM/users.json";

                List<User> users = new List<User>();

                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    users = JsonConvert.DeserializeObject<List<User>>(jsonData);
                }

                users.Add(user);

                string updatedJsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(filePath, updatedJsonData);
            }

            private void UpdateUserInJson(User user)
            {
                // Обновление данных пользователя в JSON файле
                string filePath = "C:/Users/alexa/OneDrive/Рабочий стол/Практическая/MVVM/MVVM/users.json";

                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    var users = JsonConvert.DeserializeObject<List<User>>(jsonData);

                    User existingUser = users.FirstOrDefault(u => u.Login == user.Login);
                    if (existingUser != null)
                    {
                        existingUser.Password = user.Password;

                        string updatedJsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
                        File.WriteAllText(filePath, updatedJsonData);
                    }
                }
            }
        }

    }
}
