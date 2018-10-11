using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton;
using hakaton.Models;
namespace hakaton.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            Clan naci = db.Clan.FirstOrDefault(x => x.Email == User.Identity.Name);
            var user = db.Clan.Find(naci.ID).Rezervacija.Select(x=> x.Knjiga.Naziv);
            ViewBag.Knjiga = user;
            ViewBag.useri= db.Clan.Select(x => x.Email).ToList(); ;
            
            return View();
        }

    }
}