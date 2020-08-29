using TruckRegistration.Application.Interfaces;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Interfaces.Services;

namespace TruckRegistration.Application.Services
{
    public class TruckModelApplication : ApplicationBase<TruckModel>, ITruckModelApplication
    {
        private ITruckModelService _truckModelService;
        public TruckModelApplication(ITruckModelService truckModelService) : base(truckModelService)
        {
            _truckModelService = truckModelService;
        }
    }
}
