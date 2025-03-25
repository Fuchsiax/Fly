using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fly2._0.MVVM.Model
{
    [Table("Administrators")]
    public class Administrator : INotifyPropertyChanged
    {

        [Key]
        public int Id_Administrator { get; set; }

        private string name, surname, password;
        private string numberEmployee;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string NumberEmployee
        {
            get { return numberEmployee; }
            set
            {
                numberEmployee = value;
                OnPropertyChanged("NumberEmployee");
            }
        }        

        public Administrator() { }       
        public Administrator(string name, string surname, string password, string numberEmployee) 
        {
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.numberEmployee = numberEmployee;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
