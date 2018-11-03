using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Database.Model;
using System.Threading;
using Parking.Class;

namespace Parking.Database.Controller
{
    class ReservationDeleteController
    {
        ParkingEntities pe = new ParkingEntities();
        private int _ownerId { get; set; }
        private DateTime _dateToDelete { get; set; }
        private DateTime _dateFrom { get; set; }
        private DateTime _dateTo { get; set; }

        public ReservationDeleteController()
        {

        }
        public ReservationDeleteController(int ownerId)
        {
            this._ownerId = ownerId;
        }
        public ReservationDeleteController(int ownerId, DateTime dateToDelete)
        {
            this._ownerId = ownerId;
            this._dateToDelete = dateToDelete;
        }
        public ReservationDeleteController(int ownerId, DateTime dateFrom, DateTime dateTo)
        {
            this._ownerId = ownerId;
            this._dateFrom = dateFrom;
            this._dateTo = dateTo;
        }


        public async Task ReleaseSpaceAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => FreeParkingSpaces_AddNew(), ct);
        }
        public async Task<List<DateTime>> GetSpacesAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => ListSpaces(), ct);
        }
        public async Task DeleteReleaseSpaceAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => DeleteReleaseSpace(), ct);
        }
        public async Task<List<DateTime>> ListBlackoutDatesAsync(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => ListBlackoutDates(), ct);
        }

        private async void FreeParkingSpaces_AddNew()
        {
            Days day = new Days();
            var listFreeDates = await OwnerFreeSpaces();
            var listBlackoutDates = await ListBlackout();
            var listWorkingDays = day.WorkingDays(_dateFrom, _dateTo).ToList();

            var freeDatesToDelete = from free in listFreeDates select Date.Format(free.Date);
            var blackoutDatesToDelete = from black in listBlackoutDates select Date.Format(black.Date);

            var dateToInsert = (from work in listWorkingDays
                               where
                                    !freeDatesToDelete.Contains(Date.Format(work.Date))
                                    &&
                                    !blackoutDatesToDelete.Contains(Date.Format(work.Date))

                               select Date.Format(work.Date)).ToList();

            ParkingEntities d = new ParkingEntities();

            foreach (var item in dateToInsert)
            {
                ParkingSpace p = new ParkingSpace();
                p.Date = item;
                p.ParkingSpaceOwnerID = _ownerId;
                p.Added = DateTime.Now;

                pe.ParkingSpaces.Add(p);
                pe.SaveChanges();
            }
        }

        private async Task<List<DateTime>> OwnerFreeSpaces()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            List<DateTime> list = new List<DateTime>();
            try
            {
                foreach (var item in await new ReservationDeleteController(_ownerId).GetSpacesAsync(cts.Token))
                {
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                cts.Cancel();
                throw ex;
            }
            return list;
        }
        private async Task<List<DateTime>> ListBlackout()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            List<DateTime> list = new List<DateTime>();
            try
            {
                foreach (var item in await new ReservationDeleteController().ListBlackoutDatesAsync(cts.Token))
                {
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                cts.Cancel();
                throw ex;
            }
            return list;
        }

        private void DeleteReleaseSpace()
        {
            var deleteDetails = (from par in pe.ParkingSpaces
                                 where 
                                    par.Date == _dateToDelete 
                                    && 
                                    par.ParkingSpaceOwnerID == _ownerId
                                    &&
                                    par.PlaceRentedFor == null
                                 select par).SingleOrDefault();

            pe.ParkingSpaces.Remove(deleteDetails);
            pe.SaveChanges();
        }

        private List<DateTime> ListBlackoutDates()
        {
            List<DateTime> list = new List<DateTime>();
            var listDate = pe.BlackoutDates.ToList();
            var spaces =
                    from s in listDate
                    select s.BlackoutDate1;
            foreach (var item in spaces)
            {
                list.Add(item);
            }
            return list;
        }
        private List<DateTime> ListSpaces()
        {
            List<DateTime> list = new List<DateTime>();
            var listDate = pe.ParkingSpaces.ToList();
            var spaces =
                    from s in listDate
                    where
                        s.Date >= Date.Format(DateTime.Now)
                        &&
                        s.ParkingSpaceOwnerID == _ownerId
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
