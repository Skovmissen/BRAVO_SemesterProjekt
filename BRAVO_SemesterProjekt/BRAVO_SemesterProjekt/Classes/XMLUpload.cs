using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public static XmlDocument LoadDoc(TempData temp, Wait wait)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(temp.Path);
            }
            catch (ArgumentNullException)
            {

                MessageBox.Show("Du har ikke valgt nogen fil");
                WaitEnd(wait);
            }
            catch (FileNotFoundException)
            {

                MessageBox.Show("Du har ikke valgt nogen fil");
                WaitEnd(wait);
            }
            catch (Exception)
            {

                throw;
            }


            return doc;
        }
        public static XmlNamespaceManager NameSpace(TempData temp, XmlDocument doc)
        {
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("BravoXML", "http://schemas.datacontract.org/2004/07/GuideDenmark.External.Data.Model");

            return ns;
        }
        public static void InsertInDb(Actors actor, Products product)
        {
            DataTable dtActor = DB.CheckForDoubleActor(actor);
            if (dtActor.Rows.Count == 0)
            {
                DB.InsertActor(actor);
            }

            DataTable dtCategory = DB.CheckForDoubleCategory(product);

            if (dtCategory.Rows.Count == 0)
            {
                DB.InsertCategory(product);
            }

            DataTable dtProduct = DB.CheckForDoubleProduct(product);

            if (dtProduct.Rows.Count > 0)
            {
                DB.UpdateProduct(product, actor);
            }
            else
            {
                DB.InsertXMLProduct(product, actor);
            }

        }
        public static async void Uploadxml(TempData temp, Wait wait, Actors actor, Products product)
        {
            if (temp.Path == null)
            {
                MessageBox.Show("Ingen fil valgt");
            }
            else
            {


                double count = 0;
                temp.Counter = 0;
                WaitStart(wait);
                XmlDocument doc = LoadDoc(temp, wait);
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
                    CheckForNull(name, xmlId, addressLine1, url, tlf, latitude, longitude, region, description, category, email, city, zip, temp, actor, product);
                    product.Name = actor.Name;
                    product.Street = addressLine1.InnerText;

                    InsertInDb(actor, product);
                    count++;
                    double result = ((count / temp.NodeCount) * 100);
                    temp.Counter = result;
                    if (wait.Cancel == true)
                    {
                        temp.Path = null;
                        break;



                    }
                    await PutTaskDelay();

                }



                DB.CloseDb();
                WaitEnd(wait);
                if (wait.Cancel == true)
                {
                    MessageBox.Show("Upload afbrudt");
                }
                else
                {
                    MessageBox.Show("Upload Complete");
                }

            }

        }
        private static async Task PutTaskDelay()
        {
            await Task.Delay(10);
        }
        private static void CheckForNull(XmlNode name, XmlNode xmlId, XmlNode addressLine1, XmlNode url, XmlNode tlf, XmlNode latitude, XmlNode longitude, XmlNode region, XmlNode description, XmlNode category, XmlNode email, XmlNode city, XmlNode zip, TempData temp, Actors actor, Products products)
        {
            if (name == null)
            {
                actor.Name = "Intet Navn";
            }
            else
            {
                actor.Name = name.InnerText;
            }

            if (xmlId == null)
            {
                products.XmlId = 0;
            }
            else
            {
                products.XmlId = Convert.ToInt32(xmlId.InnerText);
            }
            if (url == null)
            {
                products.Url = "Ingen URL";
            }
            else
            {
                products.Url = url.InnerText;
            }
            if (latitude == null)
            {
                products.Latitude = 00.00;
            }
            else
            {
                products.Latitude = Convert.ToDouble(latitude.InnerText);
            }
            if (longitude == null)
            {
                products.Longtitude = 00.00;
            }
            else
            {
                products.Longtitude = Convert.ToDouble(longitude.InnerText);
            }
            if (region == null)
            {
                products.Region = "Ingen Kommune";
            }
            else
            {
                products.Region = region.InnerText;
            }
            if (description == null)
            {
                products.Description = "Ingen beskrivelse";
            }
            else
            {
                products.Description = description.InnerText;
            }
            if (category == null)
            {
                products.Category = "Ingen Category";
            }
            else
            {
                products.Category = category.InnerText;
            }
            if (email == null)
            {
                actor.Email = "Ingen Email";
            }
            else
            {
                actor.Email = email.InnerText;
            }
            if (city == null)
            {
                products.City = "Ingen By";
            }
            else
            {
                products.City = city.InnerText;
            }
            if (zip == null)
            {
                products.Zipcode = "Ingen postnummer";
            }
            else
            {
                products.Zipcode = zip.InnerText;
            }
            if (tlf == null)
            {
                actor.Tlf = "ingen tlf nummer";
            }
            else
            {
                actor.Tlf = tlf.InnerText;
            }
        }
    }


}

