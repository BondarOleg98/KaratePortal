using KaratePortal.Models.PersonKarate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaratePortal.Controllers
{
    public class BranchChiefController : Controller
    {
        private KaratePersonContext db = new KaratePersonContext();

        [HttpGet]
        public ActionResult ShowBranchChief()
        {
            return View(db.BranchChieves);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}