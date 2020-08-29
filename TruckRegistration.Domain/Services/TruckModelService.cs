using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Interfaces.Repositories;
using TruckRegistration.Domain.Interfaces.Services;

namespace TruckRegistration.Domain.Services
{
    public class TruckModelService : ServiceBase<TruckModel>, ITruckModelService
    {
        private readonly ITruckModelRepository _truckModelRepository;

        public TruckModelService(ITruckModelRepository truckModelRepository) : base(truckModelRepository)
        {
            _truckModelRepository = truckModelRepository;
        }
    }
}
