using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubularMc.Domain
{
    public class Video : IVideo
    {
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public string FileSize { get; set; }
        public string ThumdnailLocation { get; set; }
        public string Title { get; set; }
    }
}
