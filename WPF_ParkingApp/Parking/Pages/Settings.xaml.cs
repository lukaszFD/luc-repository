using System.Windows;
using System.Windows.Controls;
using Parking.Class.Main_Interface_Class;
using Parking.Class;
using Parking.Interface;
using System;

namespace Parking.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page, IWindows
    {
        public Settings()
        {
            InitializeComponent();
        }

        public void Start()
        {
            new AutomaticallyStartWithWindows();
        }

        public void Stop()
        {
            new AutomaticallyStartWithWindows();
        }

        private void startWithWindows_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stopWithWindows_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Stop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
