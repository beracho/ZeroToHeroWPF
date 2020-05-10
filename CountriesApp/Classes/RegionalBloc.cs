using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Classes
{
    public class RegionalBloc
    {
        public string acronym { get; set; }
        public string name { get; set; }
        public IList<string> otherAcronyms { get; set; }
        public IList<string> otherNames { get; set; }
    }
}
