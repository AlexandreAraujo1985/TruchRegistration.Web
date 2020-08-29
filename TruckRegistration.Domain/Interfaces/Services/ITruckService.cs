using System.Collections.Generic;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Domain.Interfaces.Services
{
    public interface ITruckService : IServiceBase<Truck>
    {
        IEnumerable<Truck> GetTrucks();
    }
}
