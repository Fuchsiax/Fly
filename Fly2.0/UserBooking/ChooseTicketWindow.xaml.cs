using Fly2._0.Core;
using Fly2._0.MVVM.ViewModel;
using System.Windows;

namespace Fly2._0.UserBooking
{
    /// <summary>
    /// Логика взаимодействия для ChooseTicketWindow.xaml
    /// </summary>
    public partial class ChooseTicketWindow : Window
    {
        ApplicationContext db;
        public ChooseTicketWindow()
        {
            InitializeComponent();
            this.DataContext = new SearchViewModel();
        }     

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
