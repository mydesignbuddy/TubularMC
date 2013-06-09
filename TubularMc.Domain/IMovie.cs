using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubularMc.Domain
{
    interface IMovie : IVideo
    {
        string MovieId { get; set; }
        string PosterArtLocation { get; set; }
        string FanArtLocation { get; set; }
        IEnumerable<Actor> Actors { get; set; }
    }
}
