using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CS296NCommunityWebsiteNicholasGlesmann.Models
{
    public class SignificantPerson
    {
        // properties

        public int SignificantPersonID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string StarCraftRace { get; set; }

        public string League { get; set; }
    }
}
