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
            return RedirectToAction("Results", new { startYear, endYear });
        }
        public IActionResult Results(int startYear, int endYear)
        {
            TimePerson persons = new TimePerson();
            return View(persons.ReadPOTYFile(startYear, endYear));
        }

        
    }
}
