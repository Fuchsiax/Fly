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

namespace Fly2._0.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ChangeView.xaml
    /// </summary>
    public partial class ChangeView : UserControl
    {
        public ChangeView()
        {
            InitializeComponent();
        }

        private void Таблицы_DropDownClosed(object sender, EventArgs e)
        {
            if (Таблицы.Items.Contains("Выберите таблицу"))
                Таблицы.Items.Remove("Выберите таблицу");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Таблицы.Items.Contains("Выберите таблицу"))
            {
                Таблицы.Items.Add("Выберите таблицу");
            }
            Таблицы.Text = "Выберите таблицу";
        }
    }
}
