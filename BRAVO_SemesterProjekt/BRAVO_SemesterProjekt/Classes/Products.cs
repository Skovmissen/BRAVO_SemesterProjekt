using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BRAVO_SemesterProjekt
{
    public class Products : Actors, INotifyPropertyChanged
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

        private string category;

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                NotifyPropertyChanged();
            }
        }
        private string city;

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                NotifyPropertyChanged();
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
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

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                NotifyPropertyChanged();
            }
        }
        private double longtitude;

        public double Longtitude
        {
            get { return longtitude; }
            set
            {
                longtitude = value;
                NotifyPropertyChanged();
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value;
                NotifyPropertyChanged();
            }
        }


        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }


        private int xmlId; // XML_Id bliver brugt til at tjekke på dublikanter i xml dokumentet, så hvis der er en dublikant, bliver data overskrevet.

        public int XmlId
        {
            get { return xmlId; }
            set { xmlId = value; }
        }

        private string region;

        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                NotifyPropertyChanged();
            }
        }

        private string street;

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                NotifyPropertyChanged();
            }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                NotifyPropertyChanged();
            }
        }

        private string zipcode;

        public string Zipcode
        {
            get { return zipcode; }
            set
            {
                zipcode = value;
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

