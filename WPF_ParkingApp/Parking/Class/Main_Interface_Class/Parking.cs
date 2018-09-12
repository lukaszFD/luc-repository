using Parking.Interface;
using System.Threading.Tasks;

namespace Parking.Class.Main_Interface_Class
{
    class Parking
    {
        public void Start(IWindows win)
        {
            win.Start();
        }
        public void Stop(IWindows win)
        {
            win.Stop();
        }
        public async Task StartBalloon(ISetBalloonTip ball)
        {
            await ball.StartBalloonInformation();
        }
        public async Task OutlookAppointment(IOutlook app)
        {
            await app.CreateNewOutlookAppointment();
        }
    }
}
