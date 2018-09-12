using Parking.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Parking.Class
{
    class Information : Balloon, ISetBalloonTip
    {
        private string _text { get; set; }

        public Information(string text)
        {
            this._text = text;
        }

        private void BalloonInformation()
        {
            while (true)
            {
                SetBalloonTip(_text);
                Thread.Sleep(3600000);
            }
        }
        public async Task StartBalloonInformation()
        {
            await Task.Run(() => BalloonInformation());
        }

    }
}
