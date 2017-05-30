using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BRAVO_SemesterProjekt
{
    public class TempData : INotifyPropertyChanged
    {
        

        private string path; //Fil stien af xml dokumentet, der brugs til upload.

        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                NotifyPropertyChanged();
            }
        }


        private string search; // Søgnings property hvori man gemmer den midlertidige søge streng.

        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                NotifyPropertyChanged();

            }
        }
        private string chosenItem; //GridView item der er valgt, så vi kan se under emner, f.eks, man vælger en klynge og så kan man se alle aktører under den.

        public string ChosenItem
        {
            get { return chosenItem; }
            set
            {
                chosenItem = value;
                NotifyPropertyChanged();

            }
        }
        private double counter; // Counteren bliver brugt til at lave progressbaren, den tæller én op for hver element der bliver uploadet.

        public double Counter
        {
            get { return counter; }
            set
            {
                counter = value;
                NotifyPropertyChanged();
            }
        }
        private double nodeCount; // Nodecount er antallet af elementer i xml dokumentet der skal uploades så man kan lave en udregning sammen med counter for at få det i procent.

        public double NodeCount
        {
            get { return nodeCount; }
            set
            {
                nodeCount = value;
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
