using CafeApp.AppFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CafeApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterNewUserPage.xaml
    /// </summary>
    public partial class RegisterNewUserPage : Page
    {
        public RegisterNewUserPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (CmbRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbLogin.Text == null)
            {
                MessageBox.Show("Введите логин",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbName.Text == null)
            {
                MessageBox.Show("Введите имя",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbPassword.Text == null)
            {
                MessageBox.Show("Введите пароль",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Users usersObj = new Users()
                    {
                        FullName = TxbName.Text,
                        Login = TxbLogin.Text,
                        Password = TxbPassword.Text,
                        Status = CmbStatus.Text,
                        Role_Id = CmbRole.SelectedIndex+1
                    };

                    DbConnect.entObj.Users.Add(usersObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Новый сотрудник добавлен!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new MainAdminPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                                    "Критический сбой работы приложения",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }
            }
        }
    }
}
