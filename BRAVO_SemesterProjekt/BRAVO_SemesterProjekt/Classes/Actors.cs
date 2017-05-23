using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BRAVO_SemesterProjekt
{
    public class Actors : INotifyPropertyChanged
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
        private string oldName;

        public string OldName
        {
            get { return oldName; }
            set { oldName = value;
                NotifyPropertyChanged();
            }
        }

        private string tlf;

        public string Tlf
        {
            get { return tlf; }
            set { tlf = value;
                NotifyPropertyChanged();
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value;
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
