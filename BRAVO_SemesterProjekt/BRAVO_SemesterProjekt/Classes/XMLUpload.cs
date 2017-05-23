using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Lavet af alle
    /// </summary>
    class XMLUpload
    {

        public static async void Uploadxml(TempData temp, Wait wait, Actors actor, Products product) //Finder alle de valgte elementer i XML dokumentet ved hjælp af XMLNodes, hvori vi bruger SelectSingleNode hvilket gør at vi kan definere den præcise placering i xml-dokumentet.
        {
                      
            if (temp.Path == null)
            {
                MessageBox.Show("Ingen fil valgt");
            }
            else
            {


                double count = 0;
                temp.Counter = 0;
                wait.WaitStart(); //Åbner loading vinduet.
                XmlDocument doc = LoadDoc(temp, wait);
                XmlNamespaceManager ns = NameSpace(temp, doc);

                XmlNodeList productNode = doc.DocumentElement.SelectNodes("/BravoXML:ArrayOfProduct/BravoXML:Product", ns); //Laver en liste af alle produkter i xml-dokumentet.
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
                    XmlNode price = item.SelectSingleNode(@".//BravoXML:PriceGroups/BravoXML:PriceGroup/BravoXML:PriceFrom", ns);
                    CheckForNull(name, xmlId, addressLine1, url, tlf, latitude, longitude, region, description, category, email, city, zip, temp, actor, product, price);
                    product.ProductName = actor.Name;
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
                wait.WaitEnd(); //Lukker loadings vinduet.
                
                if (wait.Cancel == true)
                {
                    MessageBox.Show("Upload afbrudt");
                }
                else
                {
                    MessageBox.Show("Upload Færdig");
                }

            }

        }
        public static XmlDocument LoadDoc(TempData temp, Wait wait) //LoadDoc bruges til at loade XML-Dokument stien ind i doc, så man kan arbejde med den.
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(temp.Path);
            }
            catch (ArgumentNullException)
            {

                MessageBox.Show("Du har ikke valgt nogen fil");
                wait.WaitEnd();
            }
            catch (FileNotFoundException)
            {

                MessageBox.Show("Du har ikke valgt nogen fil");
                wait.WaitEnd();
            }
            catch (Exception)
            {

                throw;
            }


            return doc;
        }
        public static XmlNamespaceManager NameSpace(TempData temp, XmlDocument doc) // Namespace bliver brugt til at definere det namespace der står i toppen af XML dokumentet xnsm:
        {
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("BravoXML", "http://schemas.datacontract.org/2004/07/GuideDenmark.External.Data.Model");

            return ns;
        }
        public static void InsertInDb(Actors actor, Products product) //indsætter de funde data fra xml dokumentet i databasen.
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
                DB.UpdateXMLProduct(product);
            }
            else
            {
                DB.InsertXMLProduct(product, actor);
            }

        }
        private static async Task PutTaskDelay() // Async bruges til at forsinke metoden så den har tid til at opdatere gui, hvori vores progress bar er.
        {
            await Task.Delay(10);
        }
        private static void CheckForNull(XmlNode name, XmlNode xmlId, XmlNode addressLine1, XmlNode url, XmlNode tlf, XmlNode latitude, XmlNode longitude, XmlNode region, XmlNode description, XmlNode category, XmlNode email, XmlNode city, XmlNode zip, TempData temp, Actors actor, Products products, XmlNode price) //Metoden tjekker om den fundne data er Null, og hvis den er indsætter den en string så det kan ses i databasen.
        {
            if (price == null)
            {
                products.Price = 0;
            }
            else
            {
                products.Price = double.Parse(price.InnerText, CultureInfo.InvariantCulture); // Vi bruger CultureInfo, til at sikre at kommaet ikke ses som en tusinde seperator. Da den decimal seperator der er brugt i XML dokumentet er et punktum og ikke et komma som vi bruger i Danmark.
            }
            if (name == null)
            {
                actor.Name = "Intet Navn";
                products.ActorName = "Intet Navn";
            }
            else
            {
                actor.Name = name.InnerText;
                products.ActorName = name.InnerText;
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
                products.Latitude = double.Parse(latitude.InnerText, CultureInfo.InvariantCulture);
            }
            if (longitude == null)
            {
                products.Longtitude = 00.00;
            }
            else
            {
                products.Longtitude = double.Parse(longitude.InnerText, CultureInfo.InvariantCulture);
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

