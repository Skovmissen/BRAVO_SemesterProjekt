using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BRAVO_SemesterProjekt
{
    public class ComboProducts : INotifyPropertyChanged
    {
        private bool activate;

        public bool Activate
        {
            get { return activate; }
            set
            {
                activate = value;
                NotifyPropertyChanged();
            }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value;
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
