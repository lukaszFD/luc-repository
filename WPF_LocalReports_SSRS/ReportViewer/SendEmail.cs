using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ReportViewer
{
    public class SendEmail
    {
        /// <summary>
        /// Send report to recipients
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="pathToAttachment"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="recipients"></param>
        /// <returns></returns>
        public async Task Email_Async(object obj, string pathToAttachment, string subject, string body, List<string> recipients)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => Email(pathToAttachment , subject, body, recipients), ct);
        }
        public void Email(string pathToAttachment, string subject, string body, List<string> recipients)
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMsg.Recipients;

                foreach (var item in recipients)
                {
                    Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(item);
                    oRecip.Resolve();
                    oRecip = null;
                }

                oMsg.Subject = subject;
                oMsg.Body = body;

                String sSource = pathToAttachment;
                String sDisplayName = "Raport";
                int iPosition = (int)oMsg.Body.Length + 1;
                int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                Outlook.Attachment oAttach = oMsg.Attachments.Add(sSource, iAttachType, iPosition, sDisplayName);

                oMsg.Save();
                oMsg.Send();
                oRecips = null;
                oAttach = null;
                oMsg = null;
                oApp = null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
