using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Parking.Interface;
using System.Threading.Tasks;

namespace Parking.Class
{
    class Balloon : ISetBalloonTip
    {
        private string _text { get; set; }

        public Balloon(string text)
        {
            this._text = text;
        }
        public async Task StartBalloonInformation(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => SetBalloonTip(_text), ct);
        }
        private void SetBalloonTip(string text)
        {
            try
            {
                while (true)
                {
                    using (var icon = new NotifyIcon())
                    {
                        icon.Icon = SystemIcons.Hand;
                        icon.BalloonTipTitle = "Wolne miejsce parkingowe : ";
                        icon.BalloonTipText = text;
                        icon.BalloonTipIcon = ToolTipIcon.Info;
                        icon.Visible = true;
                        icon.ShowBalloonTip(6000);
                        Thread.Sleep(9000);
                        icon.Visible = false;
                    }
                    Thread.Sleep(3600000);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
