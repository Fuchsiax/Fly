using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using Fly2_0.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.MVVM.View
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
                foreach (Address address in addresses)
                {
                    if (address.Country.StartsWith(s) || address.City.StartsWith(s) || address.PostAddress.StartsWith(s) ||
                    address.Adress.StartsWith(s) || address.IdAddress.ToString().StartsWith(s))
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
