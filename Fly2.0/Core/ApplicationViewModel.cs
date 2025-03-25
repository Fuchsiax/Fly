using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Fly2._0.MVVM.Model;
using System.Data.Entity;
using Fly2._0.MVVM.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Migrations;

namespace Fly2._0.Core
{
    class ApplicationViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            // PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name))
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


    }
}
