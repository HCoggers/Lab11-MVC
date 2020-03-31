using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimePersonMVC.Models;

namespace TimePersonMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            List<TimePerson> persons = ReadPOTYFile(startYear, endYear);
            return RedirectToAction("Results", persons);
        }
        public IActionResult Results(TimePerson[] persons)
        {
            return View(persons);
        }

        static List<TimePerson> ReadPOTYFile(int start, int end)
        {
            String[] stringPeople = System.IO.File.ReadAllLines("C:/Users/harry/Desktop/code/week1-dotnet/Lab11-MVC/TimePersonMVC/TimePersonMVC/personOfTheYear.csv");
            TimePerson[] timePeople = new TimePerson[stringPeople.Length - 1];

            for(int i = 1; i < stringPeople.Length; i++)
            {
                string[] stringPerson = stringPeople[i].Split(",");

                int year;
                Int32.TryParse(stringPerson[0], out year);
                int birth;
                Int32.TryParse(stringPerson[4], out birth);
                int death;
                Int32.TryParse(stringPerson[5], out death);

                timePeople[i - 1] = new TimePerson
                {
                    Year = year,
                    Honor = stringPerson[1],
                    Name = stringPerson[2],
                    Country = stringPerson[3],
                    BirthYear = birth,
                    DeathYear = death,
                    Title = stringPerson[6],
                    Category = stringPerson[7],
                    Context = stringPerson[8],
                };
            }

            var people = from person in timePeople
                         where person.Year >= start && person.Year <= end
                         select person;

            List<TimePerson> queriedPeople = people.ToList();

            return queriedPeople;
        }
    }
}
