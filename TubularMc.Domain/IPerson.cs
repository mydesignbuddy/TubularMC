using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubularMc.Domain
{
    internal interface IPerson
    {
        string Prefix { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Suffix { get; set; }
        string Bio { get; set; }
        DateTime DateOfBirth { get; set; }
        DateTime DateOfDeath { get; set; }
    }
}
