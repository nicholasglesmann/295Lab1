using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CS296NCommunityWebsiteNicholasGlesmann.Models
{
    public class Response
    {
        // properties
        public int ResponseID { get; set; }

        public string Name { get; set; }

        public string Recipient { get; set; }

        public DateTime Date { get; set; }

        public string ResponseTitle { get; set; }

        public string ResponseText { get; set; }
    }
}
