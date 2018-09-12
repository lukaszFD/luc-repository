using System.Text;
using HttpWebRequest_API.Enum;

namespace HttpWebRequest_API
{
    class XMLBuilder
    {
        private string login = "";
        private string password = "";

        public string firstname { get; set; }
        public string lastname { get; set; }
        public AddressType addressType { get; set; }
        public string streetName { get; set; }
        public string flatNumber { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }

        /// <summary>
        /// This method returns xml with variables 
        /// </summary>
        /// <returns> xml </returns>
        public string xml()
        {
            StringBuilder xmlSB = new StringBuilder();
            //your xml with variables
            xmlSB.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:con=\"http://www.exaples/\">");
            xmlSB.Append("<soapenv:Header/>");
            xmlSB.Append("<soapenv:Body>");
            xmlSB.Append("<con:newApplicationRequest>");
            xmlSB.Append("<user_login>" + login + "</user_login>");
            xmlSB.Append("<user_password>" + password + "</user_password>");
            xmlSB.Append("<contract>");
            
            xmlSB.Append("<![CDATA[<sof:Contract xmlns:s=\"http://www.exaples/\" xmlns:sof=\"http://www.exaples/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.exaples/\">");
           
            xmlSB.Append("<product>");
            xmlSB.Append("<prefix>MOP</prefix>");
            xmlSB.Append("</product>");
            xmlSB.Append("<participants>");
            xmlSB.Append("<customers>");
            xmlSB.Append("<main_borrower>");
            xmlSB.Append("<personal_data>");
            xmlSB.Append("<firstname>" + firstname + "</firstname>");
            xmlSB.Append("<lastname>" + lastname + "</lastname>");
            xmlSB.Append("<secondname />");
            xmlSB.Append("</personal_data>");
            xmlSB.Append("<contact_data>");
            xmlSB.Append("<addresses>");
            xmlSB.Append("<address>");
            xmlSB.Append("<type>" + addressType + "</type>");
            xmlSB.Append("<street_name>" + streetName + "</street_name>");
            xmlSB.Append("<flat_number>" + flatNumber + "</flat_number>");
            xmlSB.Append("<postal_code>" + postalCode + "</postal_code>");
            xmlSB.Append("<city>" + city + "</city>");
            xmlSB.Append("</address>");
            xmlSB.Append("</addresses>");
            xmlSB.Append("<phones_mobile>");
            xmlSB.Append("<phone_mobile>");
            xmlSB.Append("<number>" + phoneNumber + "</number>");
            xmlSB.Append("</phone_mobile>");
            xmlSB.Append("</phones_mobile>");
            xmlSB.Append("</contact_data>");
            xmlSB.Append("<household_pointer>/households.0</household_pointer>");
            xmlSB.Append("</main_borrower>");
            xmlSB.Append("</customers>");
            xmlSB.Append("</participants>");

            xmlSB.Append("</sof:Contract>]]>");

            xmlSB.Append("</contract>");
            xmlSB.Append("</con:newApplicationRequest>");
            xmlSB.Append("</soapenv:Body>");
            xmlSB.Append("</soapenv:Envelope>");

            return xmlSB.ToString();

        }
    }
}
