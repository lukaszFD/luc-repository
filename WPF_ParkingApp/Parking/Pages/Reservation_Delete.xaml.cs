using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Parking.Database.Controller;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        private DateTime _dateFrom { get; set; }
        private DateTime _dateTo { get; set; }
        private ReservationDeleteController reserv = new ReservationDeleteController(1);


        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (_dateFrom > _dateTo)
            {
                dateTo.Background = Brushes.Red;
            }
            else
            {
                dateTo.Background = Brushes.Transparent;
                try
                {
                    await reserv.ReleaseSpace(_dateFrom, _dateTo);
                    FillListBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FillListBox()
        {
            foreach (var item in reserv.ListSpaces())
            {
                freeSpaces.Items.Add(item);
            }
        }

        private void dateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _dateFrom = Convert.ToDateTime(Convert.ToDateTime(dateFrom.Text).ToString("yyyy-MM-dd"));
        }

        private void dateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _dateTo = Convert.ToDateTime(Convert.ToDateTime(dateTo.Text).ToString("yyyy-MM-dd"));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabCheck != null && tabCheck.IsSelected)
            {
                FillListBox();
            }
        }
    }
}
