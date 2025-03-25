using Fly2._0.MVVM.Model;
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
    /// Логика взаимодействия для ChooseTicketTypeView.xaml
    /// </summary>
    public partial class ChooseTicketTypeView : UserControl
    {
        public ChooseTicketTypeView()
        {
            InitializeComponent();
        }       
        
        public ChooseTicketTypeView(Flight flight)
        {
            InitializeComponent();
        }
    }
}
