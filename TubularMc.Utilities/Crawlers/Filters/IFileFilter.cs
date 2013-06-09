using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubularMc.Utilities.Crawlers.Filters
{
    interface IFileFilter
    {
        bool Evaluate(string filePath);
    }
}
