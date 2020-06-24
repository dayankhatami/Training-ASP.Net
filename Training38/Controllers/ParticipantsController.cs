using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Training38.Controllers
{
    public class ParticipantsController : Controller
    {
        // GET: Participants
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditParticipant()
        {
            return View();
        }
    }
}