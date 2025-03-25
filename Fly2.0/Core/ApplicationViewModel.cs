using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fly2_0.Core
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {        
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
