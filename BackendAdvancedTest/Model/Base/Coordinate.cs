using FluentValidation;
using Liquid.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Model
{
    /// <summary>
    /// Model used to define Coordinate
    /// </summary>
    public class Coordinate : LightModel<Coordinate>
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
