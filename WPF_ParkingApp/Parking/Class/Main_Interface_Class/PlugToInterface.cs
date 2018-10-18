using Parking.Interface;
using System.Threading.Tasks;

namespace Parking.Class.Main_Interface_Class
{
    class PlugToInterface
    {
        public PlugToInterface()
        {
        }
        private object _obj { get; set; }

        public PlugToInterface(object obj)
        {
            this._obj = obj;
        }
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
            await ball.StartBalloonInformation( _obj);
        }
        public async Task OutlookAppointment(IOutlook app)
        {
            await app.CreateNewOutlookAppointment(_obj);
        }
    }
}
