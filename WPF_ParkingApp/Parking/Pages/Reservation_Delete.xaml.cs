using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Parking.Database.Controller;
using System.Threading;
using Parking.Class;

namespace Parking.Pages
{
    /// <summary>
    /// Interaction logic for Reservation_Delete.xaml
    /// </summary>
    public partial class Reservation_Delete : Page
    {
        public Reservation_Delete()
        {
            InitializeComponent();
        }
        private DateTime _date { get; set; }
        private DateTime _dateFrom { get; set; }
        private DateTime _dateTo { get; set; }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (_dateFrom > _dateTo)
            {
                dateToDatePicker.Background = Brushes.Red;
            }
            else
            {
                dateToDatePicker.Background = Brushes.Transparent;
                try
                {
                    await new ReservationDeleteController(1).ReleaseSpaceAsync(_dateFrom, _dateTo);
                    FillListBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void FillListBox()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                freeSpaces.Items.Clear();
                foreach (var item in await new ReservationDeleteController(1).GetSpacesAsync(cts.Token))
                {
                    freeSpaces.Items.Add(item);
                }
            }
            catch (Exception)
            {
                cts.Cancel();
                throw;
            }
        }

        private void dateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _dateFrom = Convert.ToDateTime(Convert.ToDateTime(dateFromDatePicker.Text).ToString("yyyy-MM-dd"));
        }

        private void dateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _dateTo = Convert.ToDateTime(Convert.ToDateTime(dateToDatePicker.Text).ToString("yyyy-MM-dd"));
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                await new ReservationDeleteController(1, _date).DeleteReleaseSpaceAsync(cts.Token);
            }
            catch (Exception ex)
            {
                cts.Cancel();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                FillListBox();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Days days = new Days();
                foreach (var item in days.Weekend())
                {
                    dateFromDatePicker.BlackoutDates.Add(new CalendarDateRange(item));
                    dateToDatePicker.BlackoutDates.Add(new CalendarDateRange(item));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                FillListBox();
            }
        }

        private void freeSpaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = freeSpaces.SelectedIndex;
            if (index >= 0)
            {
                _date = Convert.ToDateTime(Convert.ToDateTime(freeSpaces.Items[index].ToString()).ToString("yyyy-MM-dd"));
            }
            else
            {
                return;
            }
        }

    }
}
