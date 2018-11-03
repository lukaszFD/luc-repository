using System;
using System.Windows;
using System.Windows.Controls;
using Parking.Database.Controller;
using System.Threading;
using Parking.Class;
using System.Threading.Tasks;

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
            dateFrom.DisplayDateStart = DateTime.Today;
            dateTo.DisplayDateStart = DateTime.Today;
        }

        private DateTime _date { get; set; }
        private DateTime _dateFrom { get; set; }
        private DateTime _dateTo { get; set; }

        private async Task FillListBox()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                freeSpaces.Items.Clear();
                freeSpaces.Items.Refresh();
            }
            catch (Exception ex)
            {
                cts.Cancel();
                throw ex;
            }
            finally
            {
                foreach (var item in await new ReservationDeleteController(3).GetSpacesAsync(cts.Token))
                {
                    freeSpaces.Items.Add(item);
                }
            }
        }

        private void dateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dateFrom.SelectedDate.Value != null)
                {
                    _dateFrom = Date.Format(dateFrom.SelectedDate.Value);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dateTo.SelectedDate.Value != null)
                {
                    _dateTo = Date.Format(dateTo.SelectedDate.Value);
                }
            }
            catch (Exception)
            {
                return;
            }

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            if (freeSpaces.SelectedIndex >= 0)
            {
                try
                {
                    await new ReservationDeleteController(3, _date).DeleteReleaseSpaceAsync(cts.Token);
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dateFrom.SelectedDates.Clear();
                    dateTo.SelectedDates.Clear();
                    await FillListBox();
                    Page_Loaded(sender, e);
                }
            }
            else
            {
                return;
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                Days days = new Days();
                foreach (var item in days.Weekend(100))
                {
                    dateFrom.BlackoutDates.Add(new CalendarDateRange(item));
                    dateTo.BlackoutDates.Add(new CalendarDateRange(item));
                }
                foreach (var item in await new ReservationDeleteController(3).GetSpacesAsync(cts.Token))
                {
                    dateFrom.BlackoutDates.Add(new CalendarDateRange(item));
                    dateTo.BlackoutDates.Add(new CalendarDateRange(item));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await FillListBox();
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private async void btnDeleteRes_Click(object sender, RoutedEventArgs e)
        {
            if (_dateFrom < DateTime.Today || _dateTo < DateTime.Today)
            {
                MessageBox.Show("Proszę wybrać daty");
                return;
            }
            if (_dateFrom > _dateTo)
            {
                MessageBox.Show("Wybrana data \"do\" nie może wcześniejsza niż data \"od\"");
                return;
            }
            else
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                try
                {
                    await new ReservationDeleteController(3, _dateFrom, _dateTo).ReleaseSpaceAsync(cts.Token);
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dateFrom.SelectedDates.Clear();
                    dateTo.SelectedDates.Clear();
                    await FillListBox();
                    Page_Loaded(sender, e);
                }
            }
        }
    }
}
