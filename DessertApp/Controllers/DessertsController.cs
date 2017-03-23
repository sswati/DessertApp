using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DessertApp.Models;
using PagedList;

namespace DessertApp.Controllers
{
    public class DessertsController : Controller
    {
        private DessertDb db = new DessertDb();

        //implement pagination


        // GET: Desserts
        public ActionResult Index(string sortOrder, string currentFilter, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DietarySortParm = sortOrder == "Dietary" ? "diet_desc" : "Dietary";


            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;


            var desserts = from s in db.Desserts
                           select s;

            if (!String.IsNullOrEmpty(search))
            {
                desserts = desserts.Where(s => s.Title.Contains(search)
                                       || s.Dietary.Contains(search)
                                       );
            }

            switch (sortOrder)
            {
                case "title_desc":
                    desserts = desserts.OrderByDescending(s => s.Title);
                    break;
                case "Dietary":
                    desserts = desserts.OrderBy(s => s.Dietary);
                    break;
                case "diet_desc":
                    desserts = desserts.OrderByDescending(s => s.Dietary);
                    break;
                default:
                    desserts = desserts.OrderBy(s => s.Title);
                    break;
            }


            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(desserts.ToPagedList(pageNumber, pageSize));

            //  return View(db.Desserts.ToList());
        }

        public ActionResult Like(int id)

        {
            Dessert dessert = db.Desserts.Find(id);

            int currentLikes = dessert.Like;

            dessert.Like = currentLikes + 1;

            if (ModelState.IsValid)

            {

                db.Entry(dessert).State = EntityState.Modified;
                db.SaveChanges();

            }

            return RedirectToAction("Index");

        }

        public ActionResult Dislike(int id)

        {

            Dessert dessert = db.Desserts.Find(id);

            int currentDislikes = dessert.Dislikes;

            dessert.Dislikes = currentDislikes + 1;

            if (ModelState.IsValid)

            {

                db.Entry(dessert).State = EntityState.Modified;
                db.SaveChanges();

            }

            return RedirectToAction("Index");

        }


        // GET: Desserts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = db.Desserts.Find(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View(dessert);
        }

        // GET: Desserts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Desserts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Dietary,Ingredients,CookTime,PrepTime,RecipeMethod,Servings,DessertArtUrl,Like,Dislikes,User")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                db.Desserts.Add(dessert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dessert);
        }

        // GET: Desserts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = db.Desserts.Find(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View(dessert);
        }

        // POST: Desserts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Dietary,Ingredients,CookTime,PrepTime,RecipeMethod,Servings,DessertArtUrl,Like,Dislikes,User")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dessert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dessert);
        }

        // GET: Desserts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = db.Desserts.Find(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View(dessert);
        }

        // POST: Desserts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dessert dessert = db.Desserts.Find(id);
            db.Desserts.Remove(dessert);
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
