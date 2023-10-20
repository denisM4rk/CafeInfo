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
    /// Логика взаимодействия для WorkingShiftPage.xaml
    /// </summary>
    public partial class WorkingShiftPage : Page
    {
        public WorkingShiftPage()
        {
            InitializeComponent();

            var query =
            from turns in DbConnect.entObj.Turns
            where turns.Id >= 1
            orderby turns.DateOf
            select new { turns.Id, turns.DateOf, turns.NumberOf };

            WorkingShiftGrid.ItemsSource = query.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddUserTurnPage());
        }

        private void BtnAddTurn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddWorkingShiftPage());
        }
    }
}
