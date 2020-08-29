using System;
using System.ComponentModel.DataAnnotations;

namespace TruckRegistration.Web.DataAnnotatios
{
    public class ValidateYearModel : ValidationAttribute
    {
        private int YearManufacture { get; set; } = DateTime.Now.Year;
        private int YearModel { get; set; } = DateTime.Now.Year + 1;

        public override bool IsValid(object value) =>
            (YearModel >= int.Parse(value.ToString())) && (YearManufacture <= int.Parse(value.ToString()));

        public override string FormatErrorMessage(string name) =>
            $"Value for Year Model must be between {YearManufacture} and {YearModel}";
    }
}
