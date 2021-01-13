using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Uzduotis
{
    static class ServerOperations
    {

        private const String filename = "Codes.xml";
        private static Random random = new Random();

        /// <summary>
        /// Generates a code of desired length
        /// </summary>
        /// <param name="length"></param>
        /// <returns>Generated value</returns>
        static string RandomString(int length)
        {       
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        /// <summary>
        /// Generates codes and writes them into xml file
        /// </summary>
        /// <param name="length">Desired code length</param>
        /// <param name="count">Number of codes</param>
        /// <returns>True: codes generated</returns>
        /// <returns>False: error occured</returns>
        public static bool GenerateCodes(byte length, uint count)
        {
            try
            {

                //xml file settings to split into seperate lines
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";


                //writing to xml
                using (XmlWriter xmlWriter = XmlWriter.Create("Codes.xml", settings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Codes");

                    for (int i = 0; i < count; i++)
                    {

                        xmlWriter.WriteStartElement("code");
                        xmlWriter.WriteAttributeString("used", "False"); //state of code - false by default
                        xmlWriter.WriteString(ServerOperations.RandomString(length)); //generating code
                        xmlWriter.WriteEndElement();

                    }

                    xmlWriter.WriteEndDocument();
                    xmlWriter.Close();
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }               
        }

        /// <summary>
        /// Uses the desired code if file and code exists
        /// </summary>
        /// <param name="input">Code input</param>
        public static byte UseCode(string input)
        {
            XmlDocument doc = new XmlDocument();

            if (File.Exists(filename))
            {
                doc.Load(filename);


                //reads the xml where codes are stored
                foreach(XmlNode node in doc.LastChild.ChildNodes)
                {
                    if(input.Equals(node.InnerText))
                    {
                        if (node.Attributes.Item(0).InnerText.Equals("False"))
                        {
                            node.Attributes.Item(0).InnerText = "True";
                            return 0;
                        }
                        else
                            return 1;
                    }     
                }
                return 2;

            }       
            else
                return 3;

            
        }


    }

    
}
