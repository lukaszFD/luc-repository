using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
                foreach (var item in await new ReservationDeleteController(1).GetSpacesAsync(cts.Token))
                {
                    freeSpaces.Items.Add(item);
                }
            }
        }


        private void dateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _dateFrom = Date.Format(dateFrom.Text);
        }

        private void dateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _dateTo = Date.Format(dateTo.Text);
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            if (freeSpaces.SelectedIndex >= 0)
            {
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
                    await FillListBox();
                }
            }
            else
            {
                return;
            }

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Days days = new Days();
                //foreach (var item in days.Weekend(100))
                //{
                //    dateFrom.BlackoutDates.Add(new CalendarDateRange(item));
                //    dateTo.BlackoutDates.Add(new CalendarDateRange(item));
                //}
                await FillListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (_dateFrom > _dateTo)
            {
                dateTo.Background = Brushes.Red;
            }
            else
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                dateTo.Background = Brushes.Transparent;
                try
                {
                    await new ReservationDeleteController(1, _dateFrom, _dateTo).ReleaseSpaceAsync(cts.Token);
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                   await FillListBox();
                }
            }
        }
    }
}
