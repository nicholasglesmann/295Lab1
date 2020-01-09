using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CS296NCommunityWebsiteNicholasGlesmann.Models
{
    public class Message
    {
        // create a list of responses for each singular message
        private List<Message> responses = new List<Message>();

        // properties
        public int MessageID { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "name")]
        [Required]
        public string Name { get; set; }


        public string Recipient { get; set; }

        public DateTime Date { get; set; }

        public string MessagePriority { get; set; }

        public string MessageTitle { get; set; }

        public string MessageText { get; set; }

        public int IsResponse { get; set; }

        // read-only property for the list of responses
        public List<Message> Responses { get { return responses; } }
    }
}
