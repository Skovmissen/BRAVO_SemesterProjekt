using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace BRAVO_SemesterProjekt
{
    class dummy4
    {
        private static string xmlurl = "\\Bravo_SemesterProjekt\\skive_xml.xml";
     
        public static void Reader()
        {
            XmlDocument impxml = new XmlDocument();
            TempData products = new TempData();
            impxml.Load(xmlurl);
            XmlNodeList productlist = impxml.GetElementsByTagName("Product");
            foreach (XmlNode xmlimp in productlist)
            {
                XmlNode tempnode = xmlimp.SelectSingleNode("Categoy");
                string temp = xmlimp.SelectSingleNode("Name").InnerText;
            }
        }

    }
}
