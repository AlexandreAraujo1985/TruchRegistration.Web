using System.Collections.Generic;
using TruckRegistration.Application.Interfaces;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Interfaces.Services;

namespace TruckRegistration.Application.Services
{
    public class TruckApplication : ApplicationBase<Truck>, ITruckApplication
    {
        private readonly ITruckService _truckService;
        public TruckApplication(ITruckService truckService) : base(truckService)
        {
            _truckService = truckService;
        }

        public IEnumerable<Truck> GetTrucks() => _truckService.GetTrucks();
    }
}
