using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TruckRegistration.Web.DataAnnotatios;

namespace TruckRegistration.Web.ViewModels
{
    public class TruckViewModel
    {
        [ScaffoldColumn(false)]
        public int TruckId { get; set; }
        //[Required]
        public TruckModelViewModel Model { get; set; }
        [Required]
        [Display(Name = "Name Truck")]
        public string NameTruck { get; set; }
        [Required]
        [Display(Name = "Year Manufacture")]
        public int YearManufacture { get; set; } = DateTime.Now.Year;
        [Required]
        [Display(Name = "Year Model")]
        [ValidateYearModel(ErrorMessage = null)]
        public int YearModel { get; set; }
        [Display(Name = "Truck Models")]
        public IList<TruckModelViewModel> TruckModels { get; set; } = new List<TruckModelViewModel>();
        [ScaffoldColumn(false)]
        public int TruckModelId { get; set; }
    }
}
