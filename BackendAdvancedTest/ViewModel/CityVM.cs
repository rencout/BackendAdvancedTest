using FluentValidation;
using Liquid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.ViewModel
{
    /// <summary>
    /// View Model used to define City
    /// </summary>
    public class CityVM : LightViewModel<CityVM>
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
