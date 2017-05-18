using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAVO_SemesterProjekt
{
    
    public class Print
    {
        

        public static void WriteToFile(Products product)
        {
           

            StreamWriter writer = new StreamWriter(@"C: \Users\Public\TestFolder\WriteLines.txt");
            string text = product.ProductName + product.Category + product.ActorName + product.City + product.Description + product.Latitude + product.Longtitude + product.Region + product.Street + product.Url + product.Zipcode;

            writer.Write(text);
        }
     
    }
}
