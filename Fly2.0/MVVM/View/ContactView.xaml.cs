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
    /// Логика взаимодействия для ContactView.xaml
    /// </summary>
    public partial class ContactView : UserControl
    {
        ApplicationContext db;
        public ContactView()
        {
            InitializeComponent();
            DataContext = new ContactViewModel();
        }

        private void SearchEntity(string s)
        {
            db = new ApplicationContext();
            try
            {
                var contacts = db.Contacts;
                List<Contact> p = new List<Contact>();
                foreach (Contact  contact in contacts)
                {
                    if (contact.PhoneNumber.StartsWith(s) || contact.Email.StartsWith(s) || contact.Id_Contact.ToString().StartsWith(s))
                    {
                        p.Add(contact);
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
