using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
