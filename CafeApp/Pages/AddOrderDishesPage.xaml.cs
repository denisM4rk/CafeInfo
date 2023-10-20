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
    /// Логика взаимодействия для AddOrderDishesPage.xaml
    /// </summary>
    public partial class AddOrderDishesPage : Page
    {
        public AddOrderDishesPage()
        {
            InitializeComponent();

            CmbDishes.SelectedValuePath = "Id";
            CmbDishes.DisplayMemberPath = "Name";
            CmbDishes.ItemsSource = DbConnect.entObj.Dishes.ToList();

            CmbOrder.SelectedValuePath = "Id"; 
            CmbOrder.DisplayMemberPath = "Id";
            CmbOrder.ItemsSource = DbConnect.entObj.Orders.ToList();
        }

        private void BtnAddDishes_Click(object sender, RoutedEventArgs e)
        {
            if (CmbDishes.SelectedItem == null)
            {
                MessageBox.Show("Выберите блюдо",
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
                    Orders_Dishes orderDishesObj = new Orders_Dishes()
                    {
                        Order_Id = Convert.ToInt32(CmbOrder.SelectedIndex + 1),
                        Dish_Id = Convert.ToInt32(CmbDishes.SelectedIndex + 1),
                        CountOf = Convert.ToInt32(TxbCountOf.Text)
                    };

                    DbConnect.entObj.Orders_Dishes.Add(orderDishesObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Блюдо добавлено к заказу!",
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

        private void BtnAddDrinks_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddOrdersDrinksPage());
        }
    }
}
