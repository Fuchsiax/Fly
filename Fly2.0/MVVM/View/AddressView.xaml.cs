using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.MVVM.ViewModel;
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
    /// Логика взаимодействия для AddressView.xaml
    /// </summary>
    public partial class AddressView : UserControl
    {
        ApplicationContext db;
        public AddressView()
        {
            InitializeComponent();
            DataContext = new AddressViewModel();
        }

        private void SearchEntity(string s)
        {
            db = new ApplicationContext();
            try
            {
                var addresses = db.Addresses;
                List<Address> p = new List<Address>();
                foreach (Address  address in addresses)
                {
                    if (address.Country.StartsWith(s) || address.City.StartsWith(s) || address.PostAddress.StartsWith(s) ||
                    address.Adress.StartsWith(s) || address.Id_Address.ToString().StartsWith(s) )
                    {
                        p.Add(address);
                    }
                }
                aircraftsGrid.ItemsSource = p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = Search.Text;
            SearchEntity(s);
        }
    }
}
