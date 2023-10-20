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
    /// Логика взаимодействия для AddWorkingShiftPage.xaml
    /// </summary>
    public partial class AddWorkingShiftPage : Page
    {
        public AddWorkingShiftPage()
        {
            InitializeComponent();
        }

        private void BtnAddShift_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Turns.Count(x => x.DateOf == TurnDatePicker.SelectedDate) > 0)
            {
                MessageBox.Show("Такая смена уже есть!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    Turns turnsObj = new Turns()
                    {
                        DateOf = Convert.ToDateTime(TurnDatePicker.SelectedDate),
                        NumberOf = Convert.ToInt32(TxbCount.Text)
                    };

                    DbConnect.entObj.Turns.Add(turnsObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Новая смена добавлена!",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.Navigate(new WorkingShiftPage());
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
