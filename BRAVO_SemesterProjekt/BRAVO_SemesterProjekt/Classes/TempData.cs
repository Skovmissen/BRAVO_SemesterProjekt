using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BRAVO_SemesterProjekt
{
    class TempData : INotifyPropertyChanged
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
            set { category = value;
                NotifyPropertyChanged();
            }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value;
                NotifyPropertyChanged();
            }
        }

        private string describtion;

        public string Describtion
        {
            get { return describtion; }
            set { describtion = value;
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
        private DateTime? endTime;

        public DateTime? EndTime
        {
            get { return endTime; }
            set { endTime = value;
                NotifyPropertyChanged();
            }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
                NotifyPropertyChanged();
            }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value;
                NotifyPropertyChanged();
            }
        }
        private double longtitude;

        public double Longtitude
        {
            get { return longtitude; }
            set { longtitude = value;
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
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value;
                NotifyPropertyChanged();
            }
        }
        private int xmlId;

        public int XmlId
        {
            get { return xmlId; }
            set { xmlId = value; }
        }

        private string region;

        public string Region
        {
            get { return region; }
            set { region = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime? startTime;

        public DateTime? StartTime
        {
            get { return startTime; }
            set { startTime = value;
                NotifyPropertyChanged();
            }
        }
        private string street;

        public string Street
        {
            get { return street; }
            set { street = value;
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
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value;
                NotifyPropertyChanged();
            }
        }
        private string zipcode;

        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value;
                NotifyPropertyChanged();
            }
        }
        private string search;

        public string Search
        {
            get { return search; }
            set { search = value; }
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
