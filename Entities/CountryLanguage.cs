using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDevCodeChallange1.Entities
{
    public class CountryLanguage
    {
        public string Code { get; set; }

        public string Language { get; set; }

        public bool IsOfficial { get; set; }

        public float Percentage { get; set; }
    }
}
