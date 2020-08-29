using System.Collections.Generic;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Interfaces.Repositories;
using TruckRegistration.Domain.Interfaces.Services;

namespace TruckRegistration.Domain.Services
{
    public class TruckService : ServiceBase<Truck>, ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository) : base(truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public IEnumerable<Truck> GetTrucks() => _truckRepository.GetTrucks();
    }
}
