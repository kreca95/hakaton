using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton.Models;

namespace hakaton.Controllers
{
    public class BaseController : Controller
    {
        protected knjiznicaEntities db = new knjiznicaEntities();

        
        protected override void Dispose(bool disposing)
        { 
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}