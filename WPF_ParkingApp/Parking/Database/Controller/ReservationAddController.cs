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
        ParkingEntities pe = new ParkingEntities();
        private int _ownerId { get; set; }
        private int _parkingSpaceId { get; set; }
        private DateTime _dateFrom { get; set; }
        private DateTime _dateTo { get; set; }
        public ReservationAddController()
        {

        }
        public ReservationAddController(int ownerId, int parkingSpaceId)
        {
            this._ownerId = ownerId;
            this._parkingSpaceId = parkingSpaceId;
        }
        public ReservationAddController(int ownerId, DateTime dateFrom, DateTime dateTo)
        {
            this._ownerId = ownerId;
            this._dateFrom = dateFrom;
            this._dateTo = dateTo;
        }
        public async Task<DataTable> ListAllSpacesAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => ListAllSpaces(), ct);
        }
        public async Task ReservationAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => Reservation(), ct);
        }

        private void Reservation()
        {
            ParkingSpace updateParkingSpaces = (from p in pe.ParkingSpaces where p.ParkingSpaceId == _parkingSpaceId select p).FirstOrDefault();
            updateParkingSpaces.PlaceRentedFor = _ownerId;
            pe.SaveChanges();
        }

        private DataTable ListAllSpaces()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ParkingSpaceId");
            dt.Columns.Add("Date");
            dt.Columns.Add("SpaceNumber");

            var listDate = pe.ParkingSpaces.ToList();
            var listOwners = pe.ParkingSpacesOwners.ToList();
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
                        s.ParkingSpaceId
                        ,
                        s.Date
                        ,
                        o.SpaceNumber
                    };
            var query = from r in spaces select r;
            foreach (var item in query)
            {
                dt.Rows.Add(Date.Format(item.Date), item.SpaceNumber);
            }
            return dt;
        }
    }
}
