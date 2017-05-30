using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BRAVO_SemesterProjekt
{
    //Af Lasse
    public class Clusters : INotifyPropertyChanged
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
        private string actorName;

        public string ActorName
        {
            get { return actorName; }
            set
            {
                actorName = value;
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
        private string desciption;

        public string Description
        {
            get { return desciption; }
            set { desciption = value;
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
