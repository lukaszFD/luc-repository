using HttpWebRequest_API.Enum;
using System;
using System.Xml;


namespace HttpWebRequest_API
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XMLBuilder xmlB = new XMLBuilder();
                ConnectionManager con = new ConnectionManager();

                xmlB.firstname = "";
                xmlB.lastname = "";
                xmlB.addressType = AddressType.residence;
                xmlB.streetName = "";
                xmlB.flatNumber = "";
                xmlB.postalCode = "";
                xmlB.city = "";
                xmlB.phoneNumber = "";

                string responseFromServer = con.postData(xmlB.xml());

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseFromServer);
                XmlNode text = xmlDoc.SelectSingleNode("//text[1]");
                if (text != null)
                    Console.WriteLine(text.InnerText);

                XmlNode state = xmlDoc.SelectSingleNode("//success[1]");
                if (state != null)
                    Console.WriteLine(state.InnerText);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
