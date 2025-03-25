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
    /// Логика взаимодействия для TicketTypeView.xaml
    /// </summary>
    public partial class TicketTypeView : UserControl
    {
        private ApplicationContext db;
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
                        ticketType.IdTicketType.ToString().StartsWith(s) || ticketType.Description.ToString().StartsWith(s) || ticketType.Bagath.ToString().StartsWith(s))
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
