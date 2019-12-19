using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDevCodeChallange1.Entities
{
    public class CountryLanguage
    {
        public string CountryCode { get; set; }

        public string Language { get; set; }

        [Column(TypeName = "BIT")]
        public bool IsOfficial { get; set; }

        public float Percentage { get; set; }
    }
}
