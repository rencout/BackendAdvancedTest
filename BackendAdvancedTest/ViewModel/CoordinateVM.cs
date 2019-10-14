using FluentValidation;
using Liquid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.ViewModel
{
    /// <summary>
    /// View Model used to Request Coordinate
    /// </summary>
    public class CoordinateVM : LightViewModel<CoordinateVM>
    {
        /// <summary>
        /// Latitude from city
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Longitude from city
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Validates Coordinate's fields
        /// </summary>
        public override void Validate()
        {
            RuleFor(i => i.Latitude).NotEmpty().WithErrorCode("LATITUDE_MUSTNOT_BE_EMPTY");
            RuleFor(i => i.Longitude).NotEmpty().WithErrorCode("LONGITUDE_MUSTNOT_BE_EMPTY");
        }
    }
}
