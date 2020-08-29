namespace TruckRegistration.Domain.Entities
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string NameTruck { get; set; }
        public int YearManufacture { get; set; }
        public int YearModel { get; set; }
        public virtual TruckModel Model { get; set; }
        public int TruckModelId { get; set; }
    }
}
