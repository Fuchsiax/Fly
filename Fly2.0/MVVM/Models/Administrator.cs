using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Fly2_0.MVVM.Model
{
    [Table("Administrators")]
    public class Administrator : INotifyPropertyChanged
    {
        [Key]
        public int IdAdministrator { get; set; }

        private string name, surname, password;
        private string numberEmployee;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string NumberEmployee
        {
            get { return numberEmployee; }
            set
            {
                numberEmployee = value;
                OnPropertyChanged(nameof(NumberEmployee));
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
