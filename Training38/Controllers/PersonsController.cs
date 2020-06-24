using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training38.Models;

namespace Training38.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult Show(string id, string name, string address)
        {
            var person = new Person()
            {
                IdPerson = id,
                FullName = name,
                Address = address
            };
            return View(person);
        }
        public ActionResult Looping(int number)
        {
            ViewBag.Statement = "Hello World";
            return View(number);
        }
        public ActionResult Conditional(string name)
        {
            string answer = "Yenny";
            if (name != null)
            {
                if (name.Equals(answer))
                {
                    return Content("Hello " + name);
                }
                else
                {
                    return Content("I am Sorry");
                }
            
            }
            return Content("Please input your name");
        }
        public ActionResult EditVehicle()
        {
            return View();
        }
    }
}