using System.Threading.Tasks;

namespace Parking.Interface
{
    interface IOutlook
    {
        Task CreateNewOutlookAppointment(object obj);
    }
}
