using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Parking.Database.Controller;
using System.Data;

namespace Parking.Pages
{
    /// <summary>
    /// Interaction logic for Reservation_Add.xaml
    /// </summary>
    public partial class Reservation_Add : Page
    {
        public Reservation_Add()
        {
            InitializeComponent();
        }
        DataTable allSpacesDT = new DataTable();

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                allSpacesDT = await new ReservationAddController().ListAllSpacesAsync(cts.Token);
            }
            catch (Exception ex)
            {
                cts.Cancel();
                MessageBox.Show(ex.Message);
            }
        }

        private void freeSpacesNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async  void btnAddReservation_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                await new ReservationAddController(1, 6).ReservationAsync(cts.Token);
            }
            catch (Exception ex)
            {
                cts.Cancel();
                MessageBox.Show(ex.Message);
            }

        }
    }
}
