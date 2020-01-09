using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS296NCommunityWebsiteNicholasGlesmann.Models;

namespace CS296NCommunityWebsiteNicholasGlesmann.Controllers
{
    public class HomeController : Controller
    {
        // constructor for the HomeController
        public HomeController()
        {
            // hard coded data for the significant persons
            if (SignificantPersonRepository.SignificantPersons.Count == 0)
            {
                SignificantPerson p1 = new SignificantPerson()
                {
                    Name = "Nicholas Glesmann",
                    Age = 30,
                    StarCraftRace = "Zerg",
                    League = "Diamond"
                };
                SignificantPersonRepository.AddSignificantPerson(p1);

                SignificantPerson p2 = new SignificantPerson()
                {
                    Name = "Chris Glesmann",
                    Age = 20,
                    StarCraftRace = "Protoss",
                    League = "Platinum"
                };
                SignificantPersonRepository.AddSignificantPerson(p2);

                SignificantPerson p3 = new SignificantPerson()
                {
                    Name = "Lance Quackenbush",
                    Age = 24,
                    StarCraftRace = "Terran",
                    League = "Gold"
                };
                SignificantPersonRepository.AddSignificantPerson(p3);

                SignificantPerson p4 = new SignificantPerson()
                {
                    Name = "Cody Conley",
                    Age = 27,
                    StarCraftRace = "Zerg",
                    League = "Gold"
                };
                SignificantPersonRepository.AddSignificantPerson(p4);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Info()
        {
            // get the list of significantPersons from the SignificantPersonRepository
            List<SignificantPerson> significantPeople = SignificantPersonRepository.SignificantPersons;

            // sort the list of significantPeople based on StarCraftRace (alphabetically)
            significantPeople.Sort((p1, p2) => string.Compare(p1.StarCraftRace, p2.StarCraftRace, StringComparison.Ordinal));

            // pass the sorted significantPeople list to the View
            return View(significantPeople);
        }


    }
}
