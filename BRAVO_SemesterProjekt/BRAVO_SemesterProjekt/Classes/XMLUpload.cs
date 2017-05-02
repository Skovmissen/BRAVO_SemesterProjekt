using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BRAVO_SemesterProjekt
{
    class XMLUpload
    {
        private static string xmlUrl = @"C:\Users\Skovmose\OneDrive - IT Center Nord\Skole\2. semester eksamen\BRAVO_SemesterProjekt\BRAVO_SemesterProjekt\BRAVO_SemesterProjekt\skive_xml.xml";
        public static void ParseByXDocument()
        {

            TempData products = new TempData();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlUrl);
            
            XmlNode AddressNode = doc.SelectSingleNode("/ArrayOfProduct");
            products.Street = AddressNode.SelectSingleNode("AddressLine1").InnerText;
            products.City = AddressNode.SelectSingleNode("City").InnerText;

            XmlNode GeoNode = doc.SelectSingleNode("/Product/Address/GeoCoordinate");
            products.Latitude = Convert.ToDouble(GeoNode.SelectSingleNode("Latitude").InnerText);
            products.Longtitude = Convert.ToDouble(GeoNode.SelectSingleNode("Longtitude").InnerText);

            
        }
    }
}
