using Microsoft.Win32;
using System.IO;

namespace BRAVO_SemesterProjekt
{

    public class Print
    {


        public static void WriteToFile(Products product)
        {



            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Tekst fil | *.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Gem Produkt";
            if (saveFileDialog.ShowDialog() == true)
            {
                string[] lines = { "Produkt navn" + "\r\n" + product.ProductName + "\r\n","Kategori" + "\r\n" + product.Category + "\r\n", "Beskrivelse" + "\r\n" + product.Description + "\r\n", "By" + "\r\n" + product.City + "\r\n", "Kommune" + "\r\n" + product.Region + "\r\n", "Postnummer" + "\r\n" + product.Zipcode + "\r\n", "Latitude" + "\r\n" + product.Latitude.ToString(), "Longitude" + "\r\n" + product.Longtitude.ToString() + "\r\n", "URL" + "\r\n" + product.Url };

                using (StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

            }


        }

    }
}
