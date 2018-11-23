using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Parking.Database.Controller;
using System.Data;
using Parking.Class;

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
        DateTime selectedDate { get; set; }
        string selectedSpaceNumber { get; set; }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                freeSpacesNumber.Items.Clear();
                CalendarControl.SelectedDates.Clear();
                allSpacesDT = await new ReservationAddController().ListAllSpacesAsync(cts.Token);

                foreach (var item in await new ReservationAddController(1).ListMyReservationsAsync(cts.Token))
                {
                    CalendarControl.BlackoutDates.Add(new CalendarDateRange(item));
                }
            }
            catch (Exception ex)
            {
                cts.Cancel();
                MessageBox.Show(ex.Message);
            }
        }

        private void freeSpacesNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = freeSpacesNumber.SelectedIndex;
            if (index >= 0)
            {
                selectedSpaceNumber = freeSpacesNumber.Items[index].ToString();
            }
            else
            {
                return;
            }
        }

        private async void btnAddReservation_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSpaceNumber != null)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                try
                {
                    await new ReservationAddController(1, Convert.ToInt32(selectedSpaceNumber), selectedDate).ReservationAsync(cts.Token);
                    Page_Loaded(sender, e);
                    MessageBox.Show("Dodano rezerwację");
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć miejsce które chcesz zarezerwować klikając dwa razy w numer." +Environment.NewLine + "Zaznaczony numer musi byc podświetlony na czerwono.");
            }
        }
        private void CalendarControl_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            freeSpacesNumber.Items.Clear();
            try
            {
                selectedDate = CalendarControl.SelectedDate.Value;
                for (int i = 0; i < allSpacesDT.Rows.Count; i++)
                {
                    if (Convert.ToString(Date.Format(selectedDate)) == allSpacesDT.Rows[i][1].ToString())
                    {
                        freeSpacesNumber.Items.Add(allSpacesDT.Rows[i][0].ToString());
                        
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
