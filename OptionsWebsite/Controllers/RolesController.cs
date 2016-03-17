using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OptionsWebsite.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace OptionsWebsite.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {

            ViewBag.roles = db.Roles.ToList();
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Name)
        {
            if (ModelState.IsValid)
            {

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                if (!roleManager.RoleExists(Name))
                    roleManager.Create(new IdentityRole(Name));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Name);
        }



        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var r  = db.Roles.Find(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            ViewBag.role = r;
            return View();
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var r = db.Roles.Find(id);
            db.Roles.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
