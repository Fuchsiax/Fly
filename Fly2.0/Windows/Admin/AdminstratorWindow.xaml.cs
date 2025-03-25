using System.Windows;

namespace Fly2_0.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminstratorWindow.xaml
    /// </summary>
    public partial class AdminstratorWindow : Window
    {
        public AdminstratorWindow()
        {
            InitializeComponent();
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
