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
            XmlNodeList Product = document.GetElementsByTagName("Product"); //Parent Node
            XmlNodeList Address = document.GetElementsByTagName("Address"); //Child of product
            XmlNodeList geoCoordinate = document.GetElementsByTagName("GeoCoordinate"); //Child of address
            XmlNodeList municipality = document.GetElementsByTagName("Municipality"); //Child of address
            XmlNodeList category = document.GetElementsByTagName("Category"); //Child of product
            XmlNodeList contact = document.GetElementsByTagName("ContactInformation"); //Child of product
            XmlNodeList link = document.GetElementsByTagName("Link"); //Child of contact
            XmlNodeList descriptions = document.GetElementsByTagName("Descriptions"); //Child of product
            XmlNodeList description = document.GetElementsByTagName("Description"); //Child of descriptions
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
                foreach (XmlNode contactNode in contact)
                {
                    temp.Email = contactNode["Email"].InnerText;
                    temp.Tlf = contactNode["Phone"].InnerText;
                    foreach (XmlNode linkNode in link)
                    {
                        temp.Url = linkNode["Url"].InnerText;
                    }
                }
                foreach (XmlNode descriptionsNode in descriptions)
                {
                    
                    foreach (XmlNode descriptionNode in description)
                    {
                        temp.Describtion = descriptionNode["Text"].InnerText;
                    }
                }
                DB.InsertActor(temp);
                DB.InsertCategory(temp);
                temp.Id = DB.SelectActorId(temp);
                DB.InsertProduct(temp);
            }
            
        }
    }
}




