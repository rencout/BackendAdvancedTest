using Liquid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAdvancedTest.ViewModel
{
    /// <summary>
    /// View Model used to Response Playlist
    /// </summary>
    public class PlaylistVM : LightViewModel<PlaylistVM>
    {
        /// <summary>
        /// List of track's name
        /// </summary>
        public List<string> Playlist { get; set; }

        /// <summary>
        /// Validates PlaylistVM's fields
        /// </summary>
        public override void Validate()
        {
        }
    }
}
