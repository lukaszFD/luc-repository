using Parking.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Database.Controller
{
    class ReservationAddController
    {
        private static DataModelDataContext Data
        {
            get
            {
                return new DataModelDataContext();
            }
        }
        public async Task<List<DateTime>> ListAllSpacesAsync()
        {
            return await Task.Factory.StartNew(() => ListAllSpaces());
        }

        private List<DateTime> ListAllSpaces()
        {
            List<DateTime> list = new List<DateTime>();
            var listDate = Data.ParkingSpaces.ToList();
            var spaces =
                    from s in listDate
                    where
                        s.Date >= DateTime.Now
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
