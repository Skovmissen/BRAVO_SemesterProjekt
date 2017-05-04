using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace BRAVO_SemesterProjekt
{
    class XMLUpload
    {
        public static void WaitStart(Wait wait)
        {
            
            wait.Show();
        }
        public static void WaitEnd(Wait wait)
        {

            wait.Close();
        }
        public static XmlDocument LoadDoc(TempData temp)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(temp.Url);

            return doc;
        }
        public static void InsertInDb(TempData temp)
        {
            DataTable dtActor = DB.CheckForDoubleActor(temp);
            if (dtActor.Rows.Count == 0)
            {
                DB.InsertActor(temp);
            }

            DataTable dtCategory = DB.CheckForDoubleCategory(temp);

            if (dtCategory.Rows.Count == 0)
            {
                DB.InsertCategory(temp);
            }

            //temp.Id = DB.SelectActorId(temp);
            DB.InsertProduct(temp);
        }
        public static void Uploadxml(TempData temp, Wait wait)
        {

            WaitStart(wait);
            XmlDocument doc = LoadDoc(temp);

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("BravoXML", "http://schemas.datacontract.org/2004/07/GuideDenmark.External.Data.Model");
            XmlNodeList productNode = doc.DocumentElement.SelectNodes("/BravoXML:ArrayOfProduct/BravoXML:Product", ns);
            DB.OpenDb();
            foreach (XmlNode item in productNode)
            {
                XmlNode AddressLine1 = item.SelectSingleNode(@".//BravoXML:AddressLine1", ns);
                XmlNode URL = item.SelectSingleNode(@".//BravoXML:ContactInformation/BravoXML:Link/BravoXML:Url", ns);
                XmlNode Tlf = item.SelectSingleNode(@".//BravoXML:ContactInformation/BravoXML:Phone", ns);
                XmlNode Name = item.SelectSingleNode(@".//BravoXML:Name", ns);
                XmlNode Latitude = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:GeoCoordinate/BravoXML:Latitude", ns);
                XmlNode Longitude = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:GeoCoordinate/BravoXML:Longitude", ns);
                XmlNode Region = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:Municipality/BravoXML:Name", ns);
                XmlNode Description = item.SelectSingleNode(@".//BravoXML:Descriptions/BravoXML:Description/BravoXML:Text", ns);
                XmlNode Category = item.SelectSingleNode(@".//BravoXML:Category/BravoXML:Name", ns);
                XmlNode Email = item.SelectSingleNode(@".//BravoXML:ContactInformation/BravoXML:Email", ns);
                XmlNode City = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:City", ns);
                XmlNode Zip = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:PostalCode", ns);

                temp.Name = item["Name"].InnerText;
                temp.Street = AddressLine1.InnerText;

                if (URL == null)
                {
                    temp.Url = "Ingen URL";
                }
                else
                {
                    temp.Url = URL.InnerText;
                }
                if (Latitude == null)
                {
                    temp.Latitude = 00.00;
                }
                else
                {
                    temp.Latitude = Convert.ToDouble(Latitude.InnerText);
                }
                if (Longitude == null)
                {
                    temp.Longtitude = 00.00;
                }
                else
                {
                    temp.Longtitude = Convert.ToDouble(Longitude.InnerText);
                }
                if (Region == null)
                {
                    temp.Region = "Ingen Kommune";
                }
                else
                {
                    temp.Region = Region.InnerText;
                }
                if (Description == null)
                {
                    temp.Describtion = "Ingen beskrivelse";
                }
                else
                {
                    temp.Describtion = Description.InnerText;
                }
                if (Category == null)
                {
                    temp.Category = "Ingen Category";
                }
                else
                {
                    temp.Category = Category.InnerText;
                }
                if (Email == null)
                {
                    temp.Email = "Ingen Email";
                }
                else
                {
                    temp.Email = Email.InnerText;
                }
                if (City == null)
                {
                    temp.City = "Ingen By";
                }
                else
                {
                    temp.City = City.InnerText;
                }
                if (Zip == null)
                {
                    temp.Zipcode = "Ingen postnummer";
                }
                else
                {
                    temp.Zipcode = Zip.InnerText;
                }
                if (Tlf == null)
                {
                    temp.Tlf = "ingen tlf nummer";
                }
                else
                {
                    temp.Tlf = Tlf.InnerText;
                }



                temp.ProductName = temp.Name;


                InsertInDb(temp);
              
            }
           
            DB.CloseDb();
            WaitEnd(wait);
            MessageBox.Show("Upload Complete");
        }
    }


}

