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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = DbConnect.entObj.Users.FirstOrDefault(x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь не найден.",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
                else if(userObj.Status=="Уволен")
                {
                    MessageBox.Show("Вход запрещен. Вы уволены!",
                                   "Уведомление",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Warning);
                }
                else
                {
                    switch (userObj.Role_Id)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, администратор -" + userObj.FullName,
                                            "Уведомление",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Information);

                            FrameApp.frmObj.Navigate(new MainAdminPage());

                            break;

                        case 2:
                            MessageBox.Show("Здравствуйте, повар -" + userObj.FullName,
                                            "Уведомление",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Information);

                            FrameApp.frmObj.Navigate(new CookPage());

                            break;

                        case 3:
                            MessageBox.Show("Здравствуйте, официант -" + userObj.FullName,
                                            "Уведомление",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Information);

                            FrameApp.frmObj.Navigate(new WaiterPage());

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбой в работе приложения: " + ex.Message.ToString(),
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }
    }
}
