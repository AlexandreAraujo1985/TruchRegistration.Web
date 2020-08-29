using System.Collections.Generic;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Application.Interfaces
{
    public interface ITruckApplication : IApplicationBase<Truck>
    {
        IEnumerable<Truck> GetTrucks();
    }
}
