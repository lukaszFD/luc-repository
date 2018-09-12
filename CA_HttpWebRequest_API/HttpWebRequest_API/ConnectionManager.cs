using System;
using System.Text;
using System.Net;
using System.IO;

namespace HttpWebRequest_API
{
    /// <summary>
    /// This class connect with HTTP 
    /// </summary>
    class ConnectionManager
    {
        /// <summary>
        /// This method returns a response in the xml format 
        /// </summary>
        /// <param name="data"></param>
        public string postData(string data)
        {
            string result;
            StringBuilder xmlSB = new StringBuilder();
            try
            {
                //add endpoint address
                var request = (HttpWebRequest)WebRequest.Create("http://www.exaples/");

                request.Method = "POST";
                request.ProtocolVersion = HttpVersion.Version11;
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.ContentType = "text/xml;charset=UTF-8";
                //add soap action
                request.Headers.Add("SOAPAction:\"http://www.exaples/\"");
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                request.ContentLength = byteArray.Length;
                //add host
                request.Host = "http://www.exaples/";

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                int errorCode = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                xmlSB.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                xmlSB.Append("<error>");
                xmlSB.Append("<success>false</success>");
                xmlSB.Append("<text>" + ex.Message + "</text>");
                xmlSB.Append("<code>" + errorCode.ToString() + "</code>");
                xmlSB.Append("</error>");
                return xmlSB.ToString();
            }
            return result;
        }
    }
}
