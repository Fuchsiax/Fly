using System;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.MVVM.View
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
