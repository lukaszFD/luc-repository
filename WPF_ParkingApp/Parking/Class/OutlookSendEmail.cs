using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Parking.Class
{
    class OutlookSendEmail
    {
        public async Task Email_Async(object obj, string subject, string body, List<string> recipients)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => Email(subject, body, recipients), ct);
        }
        public async Task Email_Async(object obj, string subject, string body, string recipient)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => Email(subject, body, recipient), ct);
        }

        private static void OutlookApp(out Outlook.Application oApp, out Outlook.MailItem oMsg)
        {
            oApp = new Outlook.Application();
            oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
        }
        private void Email(string subject, string body, string recipient)
        {
            try
            {
                Outlook.Application oApp;
                Outlook.MailItem oMsg;
                OutlookApp(out oApp, out oMsg);

                Outlook.Recipient oRecip = (Outlook.Recipient)oMsg.Recipients.Add(recipient);
                oRecip.Resolve();

                oMsg.Subject = subject;
                oMsg.Body = body;

                oMsg.Save();
                oMsg.Send();

                oRecip = null;
                oMsg = null;
                oApp = null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Email(string subject, string body, List<string> recipients)
        {
            try
            {
                Outlook.Application oApp;
                Outlook.MailItem oMsg;
                OutlookApp(out oApp, out oMsg);
                Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMsg.Recipients;

                foreach (var item in recipients)
                {
                    Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(item);
                    oRecip.Resolve();
                    oRecip = null;
                }

                oMsg.Subject = subject;
                oMsg.Body = body;
                oMsg.Save();
                oMsg.Send();
                oRecips = null;
                oMsg = null;
                oApp = null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public string AddNewSpace(string spaceNumber, string date)
        {
            return "Dzień dobry," + Environment.NewLine +
                    string.Format("Miejsce parkingowe numer : {0}, zostało zarezerwoane w dniu {1}.", spaceNumber, date) + Environment.NewLine +
                    "Pozdrawiamy," + Environment.NewLine +
                    "Wonga";
        }
        static public string DeleteSpace(string spaceNumber, string date)
        {
            return "Dzień dobry," + Environment.NewLine +
                    string.Format("Rezerwacja miejsca parkingowego numer : {0}, z dnia {1} została cofnięta.", spaceNumber, date) + Environment.NewLine +
                    "Pozdrawiamy," + Environment.NewLine +
                    "Wonga";
        }
    }
}
