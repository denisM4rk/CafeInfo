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
    /// Логика взаимодействия для ChangeOrderStatusPage.xaml
    /// </summary>
    public partial class ChangeOrderStatusPage : Page
    {
        public ChangeOrderStatusPage()
        {
            InitializeComponent();

            CmbOrder.SelectedValuePath = "Id";
            CmbOrder.DisplayMemberPath = "Id";
            CmbOrder.ItemsSource = DbConnect.entObj.Orders.ToList();
        }

        private void BtnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            if (CmbOrder.SelectedItem == null)
            {
                MessageBox.Show("Выберите заказ",
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
            else
            {
                try
                {
                    int num = Convert.ToInt32(CmbOrder.SelectedIndex + 2);
                    var editRow = DbConnect.entObj.Orders.Where(w => w.Id == num).FirstOrDefault();
                    editRow.Status = CmbStatus.Text;

                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Статус изменен",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new CookPage());
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
