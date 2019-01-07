using KaratePortal.Models.PersonKarate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaratePortal.Controllers
{
    public class CoachController : Controller
    {
        private KaratePersonContext db = new KaratePersonContext();

        [HttpGet]
        public ActionResult ShowCoaches()
        {
            KaratePerson karatePerson = new KaratePerson(); ;
            ViewBag.CountCoaches = karatePerson.CountPeople(db.Coaches.ToList());
            return View(db.Coaches.ToList());
        }

        [HttpGet]
        [Authorize(Users = "admin")]
        public ActionResult Create()
        {
            ViewBag.KarateStudents = db.KarateStudents.ToList();
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(BranchChief branchChief, int[] selectedStudents)
        {
                if (selectedStudents != null)
                {
                    foreach (var s in db.KarateStudents.Where(ks => selectedStudents.Contains(ks.Id)))
                    {
                        branchChief.KarateStudents.Add(s);
                    }
                }
            db.BranchChieves.Add(branchChief);
          
            branchChief.CountsStudent = branchChief.CountPeople(selectedStudents);

            db.SaveChanges();
            return RedirectToAction("ShowCoaches", "Coach");
        }

       
        [HttpGet]
        [Authorize(Users = "admin")]
        public ActionResult Edit(int id = 0)
        {
            ViewBag.KarateStudents = db.KarateStudents.ToList();
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                BranchChief branchChief = db.BranchChieves.Find(id);
                return View(branchChief);
            }
            
            return View(coach);
        }

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }
        
        [HttpGet]
        [Authorize(Users = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            ViewBag.KarateStudents = db.KarateStudents.ToList();
            return View(coach);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            db.Coaches.Remove(coach);
            db.SaveChanges();
            return RedirectToAction("ShowCoaches", "Coach");
        }

        [HttpPost]
        public ActionResult Edit(BranchChief branchChief, int[] selectedStudents)
        {
            BranchChief newBranch = db.BranchChieves.Find(branchChief.Id);
            newBranch.Name = branchChief.Name;
            newBranch.LastName = branchChief.LastName;
            newBranch.Age = branchChief.Age;
            newBranch.Country = branchChief.Country;
            newBranch.City = branchChief.City;
            newBranch.Belt = branchChief.Belt;
            newBranch.CountsStudent = branchChief.CountPeople(selectedStudents);
            newBranch.YearStartTrainer = branchChief.YearStartTrainer;
            newBranch.JadgeCategory = branchChief.JadgeCategory;
            newBranch.Rank = branchChief.Rank;
            newBranch.NameBranch = branchChief.NameBranch;
            newBranch.NationalRole = branchChief.NationalRole;

            newBranch.KarateStudents.Clear();
            if (selectedStudents != null)
            {
                foreach (var s in db.KarateStudents.Where(ks => selectedStudents.Contains(ks.Id)))
                {
                    newBranch.KarateStudents.Add(s);
                }
            }
            db.Entry(newBranch).State=EntityState.Modified;
            db.SaveChanges();


            db.SaveChanges();
            return RedirectToAction("ShowCoaches", "Coach");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
