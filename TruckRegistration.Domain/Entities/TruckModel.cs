using System.Collections.Generic;

namespace TruckRegistration.Domain.Entities
{
    public class TruckModel
    {
        public int TruckModelId { get; set; }
        public string ModelDescription { get; set; }
        public virtual IEnumerable<Truck> Trucks { get; set; }
    }
}
