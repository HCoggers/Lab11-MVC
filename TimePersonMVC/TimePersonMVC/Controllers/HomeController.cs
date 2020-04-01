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
        /// <summary>
        /// Our default view. sends the index view to GET a year range for our Results view.
        /// </summary>
        /// <returns>Opens the Home/Index View</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Our POST action, which takes the information recieved in our GET action, and redirects us to the Results action with that data.
        /// </summary>
        /// <param name="startYear">user inputted start year >=1927</param>
        /// <param name="endYear">user inputted end year <=2016</param>
        /// <returns>Redirects us to Results Action</returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new { startYear, endYear });
        }

        /// <summary>
        /// Calls the GetPersons method on our recieved year range, and sends that TimePerson List to our results view
        /// </summary>
        /// <param name="startYear">year recieved from Index</param>
        /// <param name="endYear">end year recieved from Index</param>
        /// <returns>Opens Results view, and passes it a list of TimePersons</returns>
        public IActionResult Results(int startYear, int endYear)
        {
            TimePerson persons = new TimePerson();
            return View(persons.GetPersons(startYear, endYear));
        }

        
    }
}
