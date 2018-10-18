using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Database.Model;
using System.Threading;

namespace Parking.Database.Controller
{
    class ReservationDeleteController
    {
        private int _ownerId { get; set; }
        private DateTime _date { get; set; }

        public ReservationDeleteController(int ownerId)
        {
            this._ownerId = ownerId;
        }
        public ReservationDeleteController(int ownerId, DateTime date)
        {
            this._ownerId = ownerId;
            this._date = date;
        }
        private static DataModelDataContext Data
        {
            get
            {
                return new DataModelDataContext();
            }
        }

        public async Task ReleaseSpaceAsync(DateTime start, DateTime end)
        {
            await Task.Factory.StartNew(() => Data.usp_FreeParkingSpaces_AddNew(_ownerId, start, end));
        }

        public async Task<List<DateTime>> GetSpacesAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => ListSpaces(),ct);
        }
        public async Task DeleteReleaseSpaceAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => DeleteReleaseSpace(), ct);
        }

        private void DeleteReleaseSpace()
        {
            var deleteDetails = Data.ParkingSpaces.Single(p => p.Date == _date && p.ParkingSpacesOwnerID == _ownerId);
            DataModelDataContext d = new DataModelDataContext();
            d.ParkingSpaces.Attach(deleteDetails);
            d.ParkingSpaces.DeleteOnSubmit(deleteDetails);
            d.SubmitChanges();
        }

        private List<DateTime> ListSpaces()
        {
            List<DateTime> list = new List<DateTime>();
            var listDate = Data.ParkingSpaces.ToList();
            var spaces =
                    from s in listDate
                    where
                        s.Date >= Convert.ToDateTime(Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                        &&
                        s.ParkingSpacesOwnerID == _ownerId
                        &&
                        s.PlaceRentedFor == null
                    orderby
                        s.Date ascending
                    select s.Date;

            foreach (var item in spaces)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
