using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieDetails.DAL;
using MovieDetails.Models;

namespace MovieDetails.Controllers
{
    public class MoviesController : Controller
    {
        private DetailsContext db = new DetailsContext();

        // GET: Movies
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var movies = from s in db.Movies
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MovieName.Contains(searchString));
            }
            switch (sortOrder) {
                case "name_desc":
                    movies = movies.OrderByDescending(s => s.MovieName).Include(m => m.Actors).Include(m => m.Producers);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.MovieRelease).Include(m => m.Actors).Include(m => m.Producers);
                    break;
                default:
                    movies = movies.OrderBy(s => s.MovieName).Include(m => m.Actors).Include(m => m.Producers);
                    break;



            }
        return View(movies.ToList());
        
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName");
            ViewBag.ProducerID = new SelectList(db.Producers, "ProducerID", "ProducerName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,ActorID,ProducerID,MovieName,MoviePlot,MovieRelease")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", movie.ActorID);
            ViewBag.ProducerID = new SelectList(db.Producers, "ProducerID", "ProducerName", movie.ProducerID);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", movie.ActorID);
            ViewBag.ProducerID = new SelectList(db.Producers, "ProducerID", "ProducerName", movie.ProducerID);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,ActorID,ProducerID,MovieName,MoviePlot,MovieRelease")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", movie.ActorID);
            ViewBag.ProducerID = new SelectList(db.Producers, "ProducerID", "ProducerName", movie.ProducerID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
