using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для TicketTypeView.xaml
    /// </summary>
    public partial class TicketTypeView : UserControl
    {
        ApplicationContext db;
        public TicketTypeView()
        {
            InitializeComponent();
            this.DataContext = new TicketTypeViewModel();
        }

        private void SearchEntity(string s)
        {
            db = new ApplicationContext();
            try
            {
                var ticketTypes = db.TicketTypes;
                List<TicketType> p = new List<TicketType>();
                foreach (TicketType ticketType in ticketTypes)
                {
                    if (ticketType.Сoefficient.ToString().StartsWith(s) || ticketType.Name.StartsWith(s) || 
                        ticketType.Id_TicketType.ToString().StartsWith(s)|| ticketType.Description.ToString().StartsWith(s)|| ticketType.Bagath.ToString().StartsWith(s))
                    {
                        p.Add(ticketType);
                    }
                }
                Grid.ItemsSource = p;
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
