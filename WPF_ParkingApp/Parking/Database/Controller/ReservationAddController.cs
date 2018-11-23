using Parking.Class;
using Parking.Database.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Parking.Database.Controller
{
    class ReservationAddController
    {
        ParkingEntities1 pe = new ParkingEntities1();
        private int _ownerId { get; set; }
        private int _selectedSpaceNumber { get; set; }
        private DateTime _selectedDate { get; set; }
        private DateTime _dateFrom { get; set; }
        private DateTime _dateTo { get; set; }
        public ReservationAddController()
        {

        }
        #region Constructors
        public ReservationAddController(int ownerId)
        {
            this._ownerId = ownerId;
        }
        public ReservationAddController(int ownerId, int selectedSpaceNumber, DateTime selectedDate)
        {
            this._ownerId = ownerId;
            this._selectedSpaceNumber = selectedSpaceNumber;
            this._selectedDate = selectedDate;
        }
        #endregion

        public async Task<DataTable> ListAllSpacesAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => ListAllSpaces(), ct);
        }
        public async Task<List<DateTime>> ListMyReservationsAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => ListMyReservations(), ct);
        }
        public async Task ReservationAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => Reservation(), ct);
        }
        #region Linq
        private void Reservation()
        {
            ParkingSpace updateParkingSpaces =
                (
                 from
                    p in pe.ParkingSpaces
                 join
                    o in pe.ParkingSpaceOwners on p.ParkingSpaceOwnerID equals o.ParkingSpaceOwnerID
                 where
                    p.Date == _selectedDate 
                    &&
                    o.SpaceNumber == _selectedSpaceNumber
                 select p
                ).FirstOrDefault();

            updateParkingSpaces.PlaceRentedFor = _ownerId;
            updateParkingSpaces.PlaceRentedDate = DateTime.Now;
            pe.SaveChanges();
        }

        private DataTable ListAllSpaces()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SpaceNumber");
            dt.Columns.Add("Date");

            var listDate = pe.ParkingSpaces.ToArray();
            var listOwners = pe.ParkingSpaceOwners.ToArray();
            var spaces =
                    from
                        s in listDate
                    join
                    o in listOwners on s.ParkingSpaceOwnerID equals o.ParkingSpaceOwnerID
                    where
                        s.Date >= Date.Format(DateTime.Now)
                        &&
                        s.PlaceRentedFor == null
                    select new
                    {
                         o.SpaceNumber
                        ,s.Date
                    };
            var query = from r in spaces select r;
            foreach (var item in query)
            {
                dt.Rows.Add(item.SpaceNumber,Date.Format(item.Date));
            }
            return dt;
        }

        private List<DateTime> ListMyReservations()
        {
            List<DateTime> list = new List<DateTime>();
            var listDate = pe.ParkingSpaces.ToList();
            var spaces =
                    from s in listDate
                    where
                        s.Date >= Date.Format(DateTime.Now)
                        &&
                        s.PlaceRentedFor == _ownerId
                    orderby
                        s.Date ascending
                    select s.Date;

            foreach (var item in spaces)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion
    }
}
