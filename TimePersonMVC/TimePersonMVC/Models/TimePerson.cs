using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimePersonMVC.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }
        public List<TimePerson> ReadPOTYFile(int start, int end)
        {
            String[] stringPeople = System.IO.File.ReadAllLines("personOfTheYear.csv");
            TimePerson[] timePeople = new TimePerson[stringPeople.Length - 1];

            for (int i = 1; i < stringPeople.Length; i++)
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
