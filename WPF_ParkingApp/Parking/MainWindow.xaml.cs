using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Threading.Tasks;
using Parking.Class;
using Parking.Class.Main_Interface_Class;
using Parking.Pages;
using System.Threading;

namespace Parking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon = new NotifyIcon();

        public MainWindow()
        {
            InitializeComponent();
            OnStart();
        }

        private void notifyIcon_DoubleClick(object Sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;

            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
                this.Activate();
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            { 
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Settings());
        }

        private async Task ShowBalloon(string text)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                await new PlugToInterface(cts.Token).StartBalloon(new Balloon(text));
            }
            catch (Exception ex)
            {
                cts.Cancel();
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void OnStart()
        {
            WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Visible = true;
            notifyIcon.Text = "Parking App" + Environment.NewLine + "Kliknij dwa razy aby powiększyć";
            notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Reservation_Add());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Reservation_Delete());
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Admin());
            //await ShowBalloon("to co robimy ");
        }

        private void BtnCar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
