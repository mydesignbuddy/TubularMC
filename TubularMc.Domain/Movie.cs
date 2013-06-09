using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubularMc.Domain
{
    class Movie : IMovie
    {
        public string MovieId { get; set; }
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public string FileSize { get; set; }
        public string ThumdnailLocation { get; set; }
        public string Title { get; set; }
        public string PosterArtLocation { get; set; }
        public string FanArtLocation { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}
