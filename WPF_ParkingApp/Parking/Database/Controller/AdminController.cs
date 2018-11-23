using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Database.Model;
using System.Threading;
using Parking.Class;
using System.Data;
using System.Windows;

namespace Parking.Database.Controller
{
    class AdminController
    {
        ParkingEntities1 pe = new ParkingEntities1();
        private int _parkingSpaceOwner { get; set; }
        private DateTime _dateToDelete { get; set; }
        private DateTime _dateToAdd { get; set; }
        private string _name { get; set; }
        private string _sendedEmail { get; set; }
        private int _spaceNumber { get; set; }

        #region Constructors
        public AdminController()
        {

        }
        public AdminController( int parkingSpaceOwner, DateTime dateToAdd, string name, string sendedEmail)
        {
            this._dateToAdd = dateToAdd;
            this._parkingSpaceOwner = parkingSpaceOwner;
            this._name = name;
            this._sendedEmail = sendedEmail;
        }
        public AdminController(DateTime dateToDelete, int parkingSpaceOwner)
        {
            this._dateToDelete = dateToDelete;
            this._parkingSpaceOwner = parkingSpaceOwner;
        }
        public AdminController( int spaceNumber)
        {
            this._spaceNumber = spaceNumber;
        }
        #endregion

        #region Guest
        public async Task DeleteReleaseSpaceAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => DeleteReservations(), ct);
        }
        public async Task AddReservationsAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => AddReservations(), ct);
        }
        public async Task<DataTable> ListAllReservationsAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => ListAllReservations(), ct);
        }
        public async Task<int> ListParkingSpaceOwnerAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => ListParkingSpaceOwner(), ct);
        }
        private int ListParkingSpaceOwner()
        {
            var list = pe.ParkingSpaceOwners.ToArray();
            var spaces =
                        (
                            from l in list
                            where l.SpaceNumber == _spaceNumber
                            select l.ParkingSpaceOwnerID
                        ).First();
            return spaces;
        }
        private DataTable ListAllReservations()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SpaceNumber");
            dt.Columns.Add("Date");
            dt.Columns.Add("Name");

            var listDate = pe.ParkingSpaceGuests.ToArray();
            var listOwners = pe.ParkingSpaceOwners.ToArray();
            var spaces =
                    from
                        s in listDate
                    join
                        o in listOwners on s.ParkingSpaceOwnerID equals o.ParkingSpaceOwnerID
                    where
                        s.Date >= Date.Format(DateTime.Now)
                    select new
                    {
                         o.SpaceNumber
                        ,s.Date
                        ,s.Name
                    };
            var query = from r in spaces select r;
            foreach (var item in query)
            {
                dt.Rows.Add(item.SpaceNumber, Date.Format(item.Date), item.Name);
            }
            return dt;
        }
        private void AddReservations()
        {
            ParkingSpaceGuest p = new ParkingSpaceGuest
            {
                Date = _dateToAdd,
                ParkingSpaceOwnerID = _parkingSpaceOwner,
                Name = _name,
                EmailSentBy = _sendedEmail
            };
            pe.ParkingSpaceGuests.Add(p);
            pe.SaveChanges();
        }
        private void DeleteReservations()
        {
            var deleteDetails = (from par in pe.ParkingSpaceGuests
                                 where
                                    par.Date == _dateToDelete
                                    &&
                                    par.ParkingSpaceOwnerID == _parkingSpaceOwner
                                 select par).SingleOrDefault();
            
            pe.ParkingSpaceGuests.Remove(deleteDetails);
            pe.SaveChanges();
        }
        #endregion
    }
}
