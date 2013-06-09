using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubularMc.Domain
{
    interface IMedia
    {
        string FileName { get; set; }
        string FileLocation { get; set; }
        string FileSize { get; set; }
        string ThumdnailLocation { get; set; }
    }
}
