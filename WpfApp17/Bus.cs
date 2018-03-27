using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp17
{
    class Bus : INotifyPropertyChanged
    {

        private string name;

        public string Name
        {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged(name);
            }
        }

        private string plate;

        public string Plate
        {
            get { return plate; }
            set {
                plate = value;
                OnPropertyChanged(plate);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
