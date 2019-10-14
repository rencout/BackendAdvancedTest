using FluentValidation;
using Liquid.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.Model
{
    /// <summary>
    /// Model used to define City
    /// </summary>
    public class City : LightModel<City>
    {
        /// <summary>
        /// Name from city
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Validates City's fields
        /// </summary>
        public override void Validate()
        {
            RuleFor(i => i.Name).NotEmpty().WithErrorCode("CITY_NAME_MUSTNOT_BE_EMPTY");
        }
    }
}
