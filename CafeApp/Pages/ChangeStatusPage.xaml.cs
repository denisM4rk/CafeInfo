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
    /// Логика взаимодействия для ChangeStatusPage.xaml
    /// </summary>
    public partial class ChangeStatusPage : Page
    {
        public ChangeStatusPage()
        {
            InitializeComponent();

            CmbEmployee.SelectedValuePath = "Id";
            CmbEmployee.DisplayMemberPath = "FullName";
            CmbEmployee.ItemsSource = DbConnect.entObj.Users.ToList();
        }

        private void BtnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            if (CmbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника",
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
                    int num = Convert.ToInt32(CmbEmployee.SelectedIndex + 1);
                    var editRow = DbConnect.entObj.Users.Where(w => w.Id == num).FirstOrDefault();
                    editRow.Status = CmbStatus.Text;

                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Статус изменен",
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
