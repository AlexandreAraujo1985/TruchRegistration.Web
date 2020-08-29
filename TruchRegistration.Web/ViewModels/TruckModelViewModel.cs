using System.ComponentModel.DataAnnotations;

namespace TruckRegistration.Web.ViewModels
{
    public class TruckModelViewModel
    {
        [ScaffoldColumn(false)]
        public int TruckModelId { get; set; }
        [Display(Name = "Model Description")]
        public string ModelDescription { get; set; }
    }
}
