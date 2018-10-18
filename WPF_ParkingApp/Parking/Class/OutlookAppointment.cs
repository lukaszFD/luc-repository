using Parking.Interface;
using System;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading.Tasks;
using System.Threading;

namespace Parking.Class
{
    class OutlookAppointment : IOutlook
    {
        private string _subject { get; set; }
        private string _startDate { get; set; }
        private string _endDate { get; set; }

        public OutlookAppointment(string subject, string startDate, string endDate)
        {
            this._subject = subject;
            this._startDate = startDate;
            this._endDate = endDate;
        }
        public async Task CreateNewOutlookAppointment(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => OutlookApp(),ct);
        }
        private void OutlookApp()
        {
            Outlook.AppointmentItem appItem = null;
            Outlook.Application OutlookApp = new Outlook.Application();
            try
            {
                appItem = OutlookApp.Application.CreateItem(
                Outlook.OlItemType.olAppointmentItem)
                as Outlook.AppointmentItem;
                appItem.Subject = _subject;
                appItem.AllDayEvent = true;
                appItem.Start = DateTime.Parse(_startDate + " 09:00 AM");
                appItem.End = DateTime.Parse(_endDate + "05:00 PM");
                appItem.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (appItem != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(appItem);
                if (OutlookApp != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(OutlookApp);
            }
        }
    }
}
