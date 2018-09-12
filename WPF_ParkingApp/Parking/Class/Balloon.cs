using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Parking.Interface;

namespace Parking.Class
{
    class Balloon
    {
        public void SetBalloonTip(string text)
        {
            try
            {
                using (var icon = new NotifyIcon())
                {
                    icon.Icon = SystemIcons.Information;
                    icon.BalloonTipTitle = "Wolne miejsce parkingowe";
                    icon.BalloonTipText = text;
                    icon.BalloonTipIcon = ToolTipIcon.Info;
                    icon.Visible = true;
                    icon.ShowBalloonTip(6000);
                    Thread.Sleep(9000);
                    icon.Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
