using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp17
{
    class ApplicationView : INotifyPropertyChanged
    {
        private Bus selectedBus;
        public ObservableCollection<Bus> Buses { get; set; }

        public ApplicationView()
        {
            Buses = new ObservableCollection<Bus>
            {
                new Bus{Name="Subway",Plate="99 HC 552"},
                new Bus{Name="Subway",Plate="99 HC 553"},
                new Bus{Name="Subway",Plate="99 HC 554"}
            };
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Bus bus = new Bus();
                      Buses.Insert(0, bus);
                      selectedBus = bus;
                  }));
            }
        }

        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Bus phone = obj as Bus;
                      if (phone != null)
                      {
                          Buses.Remove(phone);
                      }
                  },
                 (obj) => Buses.Count > 0));
            }
        }


        public Bus SelectedBus
        {
            get { return selectedBus; }
            set
            {
                selectedBus = value;
                OnPropertyChanged("SelectedBus");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
