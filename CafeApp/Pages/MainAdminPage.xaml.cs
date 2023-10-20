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
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        public MainAdminPage()
        {
            InitializeComponent();
        }

        private void BtnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new RegisterNewUserPage());
        }

        private void BtnWorkingShift_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddUserTurnPage());
        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new OrderPage());
        }

        private void BtnStatus_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ChangeStatusPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AuthorizationPage());
        }
    }
}
