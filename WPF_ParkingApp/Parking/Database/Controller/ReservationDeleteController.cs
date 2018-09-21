using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Database.Model;

namespace Parking.Database.Controller
{
    class ReservationDeleteController
    {
        private int _ownerId { get; set; }

        public ReservationDeleteController(int ownerId)
        {
            this._ownerId = ownerId;
        }
        private DataModelDataContext data = new DataModelDataContext();

        public async Task ReleaseSpace(DateTime start, DateTime end)
        {
            try
            {
                await Task.Run(() => data.usp_AddFreeParkingSpaces(_ownerId, start, end));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GetSpaces()
        {
            await Task.Run(() => ListSpaces());
        }

        public List<DateTime> ListSpaces()
        {
            List<DateTime> list = new List<DateTime>();
            var listDate = data.ParkingSpaces.ToList();
            var spaces =
                    from s in listDate
                    where
                        s.Date >= DateTime.Now
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
