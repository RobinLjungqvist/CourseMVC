using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Models
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var person = new Person()
            {
                Name = "Robin Ljungqvist",
                Age = 26,
                Email = "Robin@email.com"
            };
            return View(person);
        }
    }
}