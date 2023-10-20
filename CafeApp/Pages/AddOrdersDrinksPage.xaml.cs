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
    /// Логика взаимодействия для AddOrdersDrinksPage.xaml
    /// </summary>
    public partial class AddOrdersDrinksPage : Page
    {
        public AddOrdersDrinksPage()
        {
            InitializeComponent();

            CmbDrinks.SelectedValuePath = "Id";
            CmbDrinks.DisplayMemberPath = "Name";
            CmbDrinks.ItemsSource = DbConnect.entObj.Drinks.ToList();

            CmbOrder.SelectedValuePath = "Id";
            CmbOrder.DisplayMemberPath = "Id";
            CmbOrder.ItemsSource = DbConnect.entObj.Orders.ToList();
        }

        private void BtnAddDrink_Click(object sender, RoutedEventArgs e)
        {
            if (CmbDrinks.SelectedItem == null)
            {
                MessageBox.Show("Выберите напиток",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else if (CmbOrder.SelectedItem == null)
            {
                MessageBox.Show("Выберите заказ",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Orders_Drinks orderDrinksObj = new Orders_Drinks()
                    {
                        Order_Id = Convert.ToInt32(CmbOrder.SelectedIndex + 1),
                        Drink_Id = Convert.ToInt32(CmbDrinks.SelectedIndex + 1),
                        Count_Of = Convert.ToInt32(TxbCountOf.Text)
                    };

                    DbConnect.entObj.Orders_Drinks.Add(orderDrinksObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Напиток добавлен к заказу!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
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
            FrameApp.frmObj.Navigate(new WaiterPage());
        }
    }
}
