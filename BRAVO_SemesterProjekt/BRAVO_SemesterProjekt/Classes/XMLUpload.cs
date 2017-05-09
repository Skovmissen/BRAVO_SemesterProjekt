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
        public static XmlNamespaceManager NameSpace(TempData temp, XmlDocument doc)
        {
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("BravoXML", "http://schemas.datacontract.org/2004/07/GuideDenmark.External.Data.Model");

            return ns;
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

            DataTable dtProduct = DB.CheckForDoubleProduct(temp);

            if (dtProduct.Rows.Count > 0)
            {
                DB.UpdateProduct(temp);
            }
            else
            {                
                DB.InsertXMLProduct(temp);
            }

        }
        public static async void Uploadxml(TempData temp, Wait wait)
        {
            double count = 0;
            temp.Counter = 0;          
            WaitStart(wait);
            XmlDocument doc = LoadDoc(temp);
            XmlNamespaceManager ns = NameSpace(temp, doc);

            XmlNodeList productNode = doc.DocumentElement.SelectNodes("/BravoXML:ArrayOfProduct/BravoXML:Product", ns);
            temp.NodeCount = productNode.Count;
                
            DB.OpenDb();
            foreach (XmlNode item in productNode)
            {
                XmlNode name = item["Name"];
                XmlNode xmlId = item["Id"];
                XmlNode addressLine1 = item.SelectSingleNode(@".//BravoXML:AddressLine1", ns);
                XmlNode url = item.SelectSingleNode(@".//BravoXML:ContactInformation/BravoXML:Link/BravoXML:Url", ns);
                XmlNode tlf = item.SelectSingleNode(@".//BravoXML:ContactInformation/BravoXML:Phone", ns);
                XmlNode latitude = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:GeoCoordinate/BravoXML:Latitude", ns);
                XmlNode longitude = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:GeoCoordinate/BravoXML:Longitude", ns);
                XmlNode region = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:Municipality/BravoXML:Name", ns);
                XmlNode description = item.SelectSingleNode(@".//BravoXML:Descriptions/BravoXML:Description/BravoXML:Text", ns);
                XmlNode category = item.SelectSingleNode(@".//BravoXML:Category/BravoXML:Name", ns);
                XmlNode email = item.SelectSingleNode(@".//BravoXML:ContactInformation/BravoXML:Email", ns);
                XmlNode city = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:City", ns);
                XmlNode zip = item.SelectSingleNode(@".//BravoXML:Address/BravoXML:PostalCode", ns);
                CheckForNull(name, xmlId, addressLine1, url, tlf, latitude, longitude, region, description, category, email, city, zip, temp);
                temp.ProductName = temp.Name;
                temp.Street = addressLine1.InnerText;

                InsertInDb(temp);
                count++;
                double result = ((count / temp.NodeCount) * 100);
                temp.Counter = result;
                await PutTaskDelay();
                
            }



            DB.CloseDb();
            WaitEnd(wait);
            MessageBox.Show("Upload Complete");
            
        }
        private static async Task PutTaskDelay()
        {
            await Task.Delay(10);
        }
        private static void CheckForNull(XmlNode name, XmlNode xmlId, XmlNode addressLine1, XmlNode url, XmlNode tlf, XmlNode latitude, XmlNode longitude, XmlNode region, XmlNode description, XmlNode category, XmlNode email, XmlNode city, XmlNode zip, TempData temp)
        {
            if (name == null)
            {
                temp.Name = "Intet Navn";
            }
            else
            {
                temp.Name = name.InnerText;
            }

            if (xmlId == null)
            {
                temp.XmlId = 0;
            }
            else
            {
                temp.XmlId = Convert.ToInt32(xmlId.InnerText);
            }
            if (url == null)
            {
                temp.Url = "Ingen URL";
            }
            else
            {
                temp.Url = url.InnerText;
            }
            if (latitude == null)
            {
                temp.Latitude = 00.00;
            }
            else
            {
                temp.Latitude = Convert.ToDouble(latitude.InnerText);
            }
            if (longitude == null)
            {
                temp.Longtitude = 00.00;
            }
            else
            {
                temp.Longtitude = Convert.ToDouble(longitude.InnerText);
            }
            if (region == null)
            {
                temp.Region = "Ingen Kommune";
            }
            else
            {
                temp.Region = region.InnerText;
            }
            if (description == null)
            {
                temp.Describtion = "Ingen beskrivelse";
            }
            else
            {
                temp.Describtion = description.InnerText;
            }
            if (category == null)
            {
                temp.Category = "Ingen Category";
            }
            else
            {
                temp.Category = category.InnerText;
            }
            if (email == null)
            {
                temp.Email = "Ingen Email";
            }
            else
            {
                temp.Email = email.InnerText;
            }
            if (city == null)
            {
                temp.City = "Ingen By";
            }
            else
            {
                temp.City = city.InnerText;
            }
            if (zip == null)
            {
                temp.Zipcode = "Ingen postnummer";
            }
            else
            {
                temp.Zipcode = zip.InnerText;
            }
            if (tlf == null)
            {
                temp.Tlf = "ingen tlf nummer";
            }
            else
            {
                temp.Tlf = tlf.InnerText;
            }
        }
    }


}

