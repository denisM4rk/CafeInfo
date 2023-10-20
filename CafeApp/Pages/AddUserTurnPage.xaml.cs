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
    /// Логика взаимодействия для AddUserTurnPage.xaml
    /// </summary>
    public partial class AddUserTurnPage : Page
    {
        public AddUserTurnPage()
        {
            InitializeComponent();

            CmbTurns.SelectedValuePath = "Id";
            CmbTurns.DisplayMemberPath = "DateOf";
            CmbTurns.ItemsSource = DbConnect.entObj.Turns.ToList();

            CmbUser.SelectedValuePath = "Id";
            CmbUser.DisplayMemberPath = "FullName";
            CmbUser.ItemsSource = DbConnect.entObj.Users.ToList();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (CmbTurns.SelectedItem == null)
            {
                MessageBox.Show("Выберите смену",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbUser.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Users_Turns userTurnsObj = new Users_Turns()
                    {
                        Turn_Id = Convert.ToInt32(CmbTurns.SelectedIndex+1),
                        User_Id = Convert.ToInt32(CmbUser.SelectedIndex+1)
                    };

                    DbConnect.entObj.Users_Turns.Add(userTurnsObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Сотрудник добавлен на смену!",
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

        private void BtnAddTurn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new WorkingShiftPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new MainAdminPage());
        }
    }
}
