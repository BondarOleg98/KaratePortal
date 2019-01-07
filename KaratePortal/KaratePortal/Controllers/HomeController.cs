using KaratePortal.Models;
using KaratePortal.Models.Map;
using KaratePortal.Models.PersonKarate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaratePortal.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Name = User.Identity.Name;
            }
            return View();
        }
        [HttpGet]
        public ActionResult ShowClubs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Map()
        {
            return View();
        }
        public JsonResult GetData()
        {
            List<Club> stations = new List<Club>();
            stations.Add(new Club()
            {
                Id = 1,
                GeoLat = 28.5814912,
                GeoLong = 49.8940442,
               
            });
            stations.Add(new Club()
            {
                Id = 2,
                GeoLat = 25.591886,
                GeoLong = 49.5557716,
              
            });
            stations.Add(new Club()
            {
                Id = 3,
                GeoLat = 35.0417711,
                GeoLong = 48.4680221,
            
            });
            stations.Add(new Club()
            {
                Id = 4,
                GeoLat = 32.0042471,
                GeoLong = 46.9713483,

            });
            stations.Add(new Club()
            {
                Id = 5,
                GeoLat = 30.68365101,
                GeoLong = 46.4858883,

            });
            stations.Add(new Club()
            {
                Id = 6,
                GeoLat = 36.3967617,
                GeoLong = 50.138019,

            });
            stations.Add(new Club()
            {
                Id = 7,
                GeoLat = 38.72475,
                GeoLong = 48.2571,

            });

            return Json(stations, JsonRequestBehavior.AllowGet);
        }
    }
}