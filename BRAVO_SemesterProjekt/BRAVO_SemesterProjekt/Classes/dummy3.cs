using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace BRAVO_SemesterProjekt
{
    class dummy3
    {
        

        public void Reader()
        {
            XmlDocument document = new XmlDocument();
            TempData temp = new TempData();
            XmlNodeList Product = document.GetElementsByTagName("Product");
            XmlNodeList Address = document.GetElementsByTagName("Address"); //Child of product
                XmlNodeList geoCoordinate = document.GetElementsByTagName("GeoCoordinate"); //Child of address
                XmlNodeList municipality = document.GetElementsByTagName("Municipality"); //Child of address
            XmlNodeList category = document.GetElementsByTagName("Category"); //Child of product

            document.Load(@"D:\OneDrive - IT Center Nord\GitHub Reposeitory\BRAVO_SemesterProjekt\BRAVO_SemesterProjekt\BRAVO_SemesterProjekt\skive_xml.xml");
            
            foreach (XmlNode node in Product)
            {
                temp.Name = node["Name"].InnerText;

                
                foreach (XmlNode addressNode in Address)
                {
                    temp.Street = addressNode["AddressLine1"].InnerText;
                    temp.Zipcode = addressNode["PostalCode"].InnerText;
                    temp.City = addressNode["City"].InnerText;

                    

                    foreach (XmlNode geoNode in geoCoordinate)
                    {
                        temp.Longtitude = Convert.ToDouble(geoNode["Longtitude"].InnerText);
                        temp.Latitude = Convert.ToDouble(geoNode["Latitude"].InnerText);
                    }

                    

                    foreach (XmlNode municipalityNode in municipality)
                    {
                        temp.Region = municipalityNode["Name"].InnerText;                       
                    }
                }

                foreach (XmlNode categoryNode in category)
                {
                    temp.Category = categoryNode["Name"].InnerText;
                }
            }
            
        }
    }
}




