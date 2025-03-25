using Fly2_0.Core;
using Fly2_0.MVVM.ViewModel;
using System.Windows;

namespace Fly2_0.UserBooking
{
    /// <summary>
    /// Логика взаимодействия для ChooseTicketWindow.xaml
    /// </summary>
    public partial class ChooseTicketWindow : Window
    {
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
