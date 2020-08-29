using System.Collections.Generic;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Domain.Interfaces.Repositories
{
    public interface ITruckRepository : IRepositoryBase<Truck>
    {
        IEnumerable<Truck> GetTrucks();
    }
}
