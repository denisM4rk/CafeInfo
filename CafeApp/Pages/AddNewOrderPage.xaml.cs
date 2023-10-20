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
    /// Логика взаимодействия для AddNewOrderPage.xaml
    /// </summary>
    public partial class AddNewOrderPage : Page
    {
        public AddNewOrderPage()
        {
            InitializeComponent();

            CmbEmployee.SelectedValuePath = "Id";
            CmbEmployee.DisplayMemberPath = "User_Id";
            CmbEmployee.ItemsSource = DbConnect.entObj.Users_Turns.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new WaiterPage());
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CmbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите работника",
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
            else if (TxbCount.Text == null)
            {
                MessageBox.Show("Введите количество людей",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (TxbTable.Text == null)
            {
                MessageBox.Show("Введите номер столика",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Orders ordersObj = new Orders()
                    {
                        Status = CmbStatus.Text,
                        DinnerTable = Convert.ToInt32(TxbTable.Text),
                        CountOfClients = Convert.ToInt32(TxbCount.Text),
                        User_Turn_Id = Convert.ToInt32(CmbEmployee.SelectedIndex+1)
                    };

                    DbConnect.entObj.Orders.Add(ordersObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Заказ добавлен",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new AddOrderDishesPage());
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
