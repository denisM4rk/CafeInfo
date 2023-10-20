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
    /// Логика взаимодействия для CookPage.xaml
    /// </summary>
    public partial class CookPage : Page
    {
        public CookPage()
        {
            InitializeComponent();
        }

        private void BtnOrderCatalog_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new OrderCatalogPage());
        }

        private void BtnChangeOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ChangeOrderStatusPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AuthorizationPage());
        }
    }
}
