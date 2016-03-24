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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewBag.roles = db.Roles.ToList();
            return View();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult UsersIndex() {
            ViewBag.users = db.Users.ToList();
            
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UserRoles(string Id, string UserName) {
            ViewBag.UserName = UserName;
            ViewBag.UserId = Id;

            var hasroles = (from ur in db.UserRoles
                           join r in db.Roles on
                          ur.RoleId equals r.Id
                           where ur.UserId == Id
                           select r.Name).ToList();

            ViewBag.UserRoles  = from ur in db.UserRoles
                    join r in db.Roles on
                   ur.RoleId equals r.Id
                    where ur.UserId == Id
                    select r;
            
            ViewBag.AllRoles = db.Roles.Where(r => !hasroles.Contains(r.Name)).Select(r => r.Name);
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUserRole(string UserId, string Name) {
            
            ApplicationUser user = db.Users.Where(u => u.Id == UserId).SingleOrDefault();
            if ((user.UserName == "a00111111" || user.UserName == "A00111111") && Name == "Admin") {
     
                return RedirectToAction("UserRoles", "Roles", new { Id = UserId, UserName = user.UserName });
            }
            ViewBag.Message = "";
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            userManager.RemoveFromRole(UserId, Name);
            return RedirectToAction("UserRoles", "Roles", new { Id = UserId, UserName = user.UserName });
        }


        [Authorize(Roles = "Admin")]
        public ActionResult AddUserRole(string UserId, string Name) {
            ApplicationUser user = db.Users.Where(u => u.Id == UserId).SingleOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            userManager.AddToRole(UserId, Name);
            return RedirectToAction("UserRoles", "Roles", new { Id = UserId, UserName = user.UserName });
        }


        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            var r = db.Roles.Find(id);
            db.Roles.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
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
