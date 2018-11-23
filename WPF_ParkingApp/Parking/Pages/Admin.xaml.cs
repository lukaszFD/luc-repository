using Parking.Class;
using Parking.Database.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Parking.Pages
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            checkBoxSendEmail.IsEnabled = false;
            checkBoxAddInfoToCalendar.IsEnabled = false;
        }
        DataTable allSpacesDT = new DataTable();
        DateTime selectedDate { get; set; }
        int selectedSpaceNumber { get; set; }
        string selectedEmail { get; set; }
        int parkingSpaceOwnerID { get; set; }

        #region Guest

        private async void freeGuestSpacesNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                tbxGuestName.Text = null;
                int index = freeGuestSpacesNumber.SelectedIndex;
                if (index >= 0)
                {
                    selectedSpaceNumber = Convert.ToInt32(freeGuestSpacesNumber.Items[index].ToString().Substring(0, freeGuestSpacesNumber.Items[index].ToString().IndexOf("-") - 1));
                    tbxGuestName.Text = freeGuestSpacesNumber.Items[index].ToString().Substring(freeGuestSpacesNumber.Items[index].ToString().IndexOf("-") + 2);
                    parkingSpaceOwnerID = await new AdminController(selectedSpaceNumber).ListParkingSpaceOwnerAsync(cts.Token);
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                cts.Cancel();
                throw;
            }

        }

        private async void btnAddReservationGuest_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                if (
                    selectedDate != null
                    &&
                    tbxGuestName.Text.Length > 0
                &&
                (
                   radioScpace90.IsChecked == true
                || radioScpace98.IsChecked == true
                || radioScpace109.IsChecked == true
                || radioScpace119.IsChecked == true
                || radioScpace161.IsChecked == true
                )
                   )
                {
                    int parkingSpaceOwner =
                         radioScpace90.IsChecked == true ? 1 :
                         radioScpace98.IsChecked == true ? 2 :
                         radioScpace109.IsChecked == true ? 3 :
                         radioScpace119.IsChecked == true ? 4 :
                         radioScpace161.IsChecked == true ? 5 : 0;

                    await new AdminController(parkingSpaceOwner, selectedDate, tbxGuestName.Text, Environment.UserName).AddReservationsAsync(cts.Token);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cts.Cancel();
            }
            finally
            {
                MessageBox.Show("Miejsce parkingowe zostało przypisane.");
                Page_Loaded(sender, e);
                CancellationTokenSource cts2 = new CancellationTokenSource();

                try
                {
                    if (checkBoxSendEmail.IsChecked == true)
                    {
                        int selectedNumber =
                             radioScpace90.IsChecked == true ? 90 :
                             radioScpace98.IsChecked == true ? 98 :
                             radioScpace109.IsChecked == true ? 109 :
                             radioScpace119.IsChecked == true ? 119 :
                             radioScpace161.IsChecked == true ? 161 : 0;
                        await new OutlookSendEmail().Email_Async(cts2.Token, "Rezerwacja miejsca parkingowego - Wonga", OutlookSendEmail.AddNewSpace(selectedNumber.ToString(), selectedDate.ToString("dd-MM-yyyy")), tbxGuestName.Text);
                    }
                }
                catch (Exception ex)
                {
                    cts2.Cancel();
                    MessageBox.Show(ex.Message);
                }
            }
            checkBoxSendEmail.IsChecked = false;
            tbxGuestName.Text = null;
        }

        private async void btnRemoveGuest_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                await new AdminController(selectedDate, parkingSpaceOwnerID).DeleteReleaseSpaceAsync(cts.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cts.Cancel();
            }
            finally
            {
                MessageBox.Show("Miejsce parkingowe zostało usunięte.");
                Page_Loaded(sender, e);
                CancellationTokenSource cts2 = new CancellationTokenSource();
                try
                {
                    if (checkBoxSendEmail.IsChecked == true)
                    {
                        await new OutlookSendEmail().Email_Async(cts2.Token, "Cofnięcie rezerwacji miejsca parkingowego - Wonga", OutlookSendEmail.DeleteSpace(selectedSpaceNumber.ToString(), selectedDate.ToString("dd-MM-yyyy")), tbxGuestName.Text);
                    }
                }
                catch (Exception ex)
                {
                    cts2.Cancel();
                    MessageBox.Show(ex.Message);
                }
            }
            checkBoxSendEmail.IsChecked = false;
            freeGuestSpacesNumber.Items.Clear();
            tbxGuestName.Text = null;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                allSpacesDT = await new AdminController().ListAllReservationsAsync(cts.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cts.Cancel();
            }
        }

        private void CalendarControl_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            freeGuestSpacesNumber.Items.Clear();
            radioScpace90.IsEnabled = true;
            radioScpace98.IsEnabled = true;
            radioScpace109.IsEnabled = true;
            radioScpace119.IsEnabled = true;
            radioScpace161.IsEnabled = true;

            try
            {
                selectedDate = CalendarControl.SelectedDate.Value;
                
                for (int i = 0; i < allSpacesDT.Rows.Count; i++)
                {
                    if (Convert.ToString(Date.Format(selectedDate)) == allSpacesDT.Rows[i][1].ToString())
                    {
                        freeGuestSpacesNumber.Items.Add(allSpacesDT.Rows[i][0].ToString() + " - " + allSpacesDT.Rows[i][2].ToString());


                        if (allSpacesDT.Rows[i][0].ToString() == "90")
                        {
                            radioScpace90.IsEnabled = false;
                        }
                        if (allSpacesDT.Rows[i][0].ToString() == "98")
                        {
                            radioScpace98.IsEnabled = false;
                        }
                        if (allSpacesDT.Rows[i][0].ToString() == "109")
                        {
                            radioScpace109.IsEnabled = false;
                        }
                        if (allSpacesDT.Rows[i][0].ToString() == "119")
                        {
                            radioScpace119.IsEnabled = false;
                        }
                        if (allSpacesDT.Rows[i][0].ToString() == "161")
                        {
                            radioScpace161.IsEnabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return;
            }
        }

        private void TbxGuestName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(tbxGuestName.Text, @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"))
            {
                checkBoxSendEmail.IsEnabled = true;
            }
            else
            {
                checkBoxSendEmail.IsEnabled = false;
            }
            if (tbxGuestName.Text.Length > 0)
            {
                checkBoxAddInfoToCalendar.IsEnabled = true;
            }
            else
            {
                checkBoxAddInfoToCalendar.IsEnabled = false;
            }
        }
        #endregion

    }
}
