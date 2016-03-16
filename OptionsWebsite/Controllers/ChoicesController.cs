using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OptionsWebsite.Models.BCITModels;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OptionsWebsite.Models;

namespace OptionsWebsite.Controllers
{
    public class ChoicesController : Controller
    {
        private BCITContext db = new BCITContext();

        Dictionary<int, string> Terms = new Dictionary<int, string>()
        {
            { 10, "Winter" },
            { 20, "Spring/Summer" },
            { 30, "Fall" }
        };


        private UserManager<ApplicationUser> userManager;
        IList<string> roles;

        //Returns weather or not a list of roles contains Admin
        public bool IsAdmin(IList<string> roles)
        {
            foreach(string role in roles)
            {
                if(role == "Admin")
                {
                    return true;
                }
            }
            return false;
        }


        public ChoicesController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>((new ApplicationDbContext())));

            //roles = userManager.GetRoles(userManager.FindByName(User.Identity.Name).Id);
        }

        // GET: Choices
        [Authorize(Roles = "Admin,Student")]
        public ActionResult Index()
        {
            bool isAdmin = false;
            System.Linq.IQueryable<OptionsWebsite.Models.BCITModels.Choice> choices;

            //gets the all roles of a user
            roles = userManager.GetRoles(userManager.FindByName(User.Identity.Name).Id);

            isAdmin = IsAdmin(roles);

            //Admin
            if (isAdmin)
            {
                choices = db.Choices.Include(c => c.FirstOption).Include(c => c.FourthOption).Include(c => c.SecondOption).Include(c => c.ThirdOption).Include(c => c.YearTerm);
            }
            else//student
            {
                choices = db.Choices.Include(c => c.FirstOption).Include(c => c.FourthOption).Include(c => c.SecondOption).Include(c => c.ThirdOption).Include(c => c.YearTerm).Where(c => c.StudentId == User.Identity.Name);
            }


            
            return View(choices.ToList());
        }

        //// GET: Choices/Details/5
        //[Authorize(Roles = "Admin")]
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Choice choice = db.Choices.Find(id);
        //    if (choice == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(choice);
        //}

        // GET: Choices/Create
        [Authorize(Roles = "Student, Admin")]
        public ActionResult Create()
        {
            bool isAdmin = false;

            //gets the all roles of a user
            roles = userManager.GetRoles(userManager.FindByName(User.Identity.Name).Id);

            isAdmin = IsAdmin(roles);

            if (isAdmin)
            {
                ViewBag.Admin = true;
            }
            else
            {
                ViewBag.Admin = false;
            }

            ViewBag.StudentId = User.Identity.Name; //User's student number

            ViewBag.FirstChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title");
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title");
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title");
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title");
            ViewBag.YearTermId = new SelectList(db.YearTerms.Where(y => y.IsDefault == true), "YearTermId", "YearTermId");

            var term = db.YearTerms.Where(y => y.IsDefault == true).ToArray();
            ViewBag.Term = $"{Terms[term[0].Term]} {term[0].Year}";

            return View();
        }

        // POST: Choices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student, Admin")]
        public ActionResult Create([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            bool isAdmin = false;

            //gets the all roles of a user
            roles = userManager.GetRoles(userManager.FindByName(User.Identity.Name).Id);

            isAdmin = IsAdmin(roles);
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                if (!isAdmin)   //Not admin, make sure user saves their student #
                {
                    choice.StudentId = User.Identity.Name;
                }

                YearTerm[] yearTerms = db.YearTerms.Where(y => y.IsDefault == true).ToArray();
                choice.YearTermId = yearTerms[0].YearTermId;
                choice.SelectionDate = DateTime.Now;

                Choice [] haschoice = db.Choices.Where(x => x.StudentId == choice.StudentId).Where(x => x.YearTermId == choice.YearTermId).ToArray();
                if (haschoice.Length == 0)
                {

                    db.Choices.Add(choice);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else {
                    ViewBag.Error = "<p style='color: red;'>This student already has an entry for this term.</p>";

                }
            }

            if (isAdmin)
            {
                ViewBag.Admin = true;
            }
            else
            {
                ViewBag.Admin = false;
            }
            ViewBag.StudentId = User.Identity.Name; //User's student number

            ViewBag.FirstChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.YearTermId = db.YearTerms.Where(x => x.YearTermId == choice.YearTermId);

            var term = db.YearTerms.Where(y => y.IsDefault == true).ToArray();
            ViewBag.Term = $"{Terms[term[0].Term]} {term[0].Year}";

            return View(choice);
        }

        // GET: Choices/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirstChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms.Where(y => y.IsDefault == true), "YearTermId", "YearTermId");
            return View(choice);
        }

        // POST: Choices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            if (ModelState.IsValid)
            {
                choice.SelectionDate = DateTime.Now;
                db.Entry(choice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
                   
            }
            ViewBag.FirstChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options.Where(o => o.IsActive == true), "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
            return View(choice);
        }

        // GET: Choices/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // POST: Choices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Choice choice = db.Choices.Find(id);
            db.Choices.Remove(choice);
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
