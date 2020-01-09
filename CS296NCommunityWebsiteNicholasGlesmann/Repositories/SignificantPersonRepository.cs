using CS296NCommunityWebsiteNicholasGlesmann.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296NCommunityWebsiteNicholasGlesmann.Models
{
    public class SignificantPersonRepository
    {
        // create a list of significant persons
        private static List<SignificantPerson> significantPersons = new List<SignificantPerson>();

        // read-only property for the list of significant persons
        public static List<SignificantPerson> SignificantPersons { get { return significantPersons; } }

        // method to add a significant person to the list of significant persons
        public static void AddSignificantPerson(SignificantPerson significantPerson)
        {
            significantPersons.Add(significantPerson);
        }
    }
}
