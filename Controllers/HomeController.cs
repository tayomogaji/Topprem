using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XI.Models;
using Google.GData.Client;
using Google.GData.YouTube;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace XI.Controllers
{
    public class HomeController : Controller
    {
        //this new private field represents my new data base model i now wish to communicate with.
        private XIEntities3 db = new XIEntities3();

        // GET: Players By searching the Players Team option. 
        public ActionResult Index(string playerTeam, string searchString)
        {
            //return View(db.Players.ToList()); 
            var TeamLst = new List<string>();
            var TeamQry = from d in db.Players
                          orderby d.Team
                          select d.Team;

            TeamLst.AddRange(TeamQry.Distinct());
            ViewBag.playerTeam = new SelectList(TeamLst);


            //Searching by name
            var players = from p in db.Players
                          select p;

            //once the user has entered a team in an empty search box
            //a list of players from the club will appear.
            if (!String.IsNullOrEmpty(searchString)) {
                players = players.Where(s => s.Name.Contains(searchString));
            }

            //finalising the team search option
            if (!String.IsNullOrEmpty(playerTeam)) {
                players = players.Where(x => x.Team == playerTeam);
            }

            return View(players);

        }



        // GET: player/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = db.Players.Find(Id);
            if (player == null) {
                return HttpNotFound();
            }

            return View(player);
        }



        // GET: Home/Create
        
        public ActionResult Create()
        {
            return View();

        }

        // POST: Home/Create
        //To prevent overposting attacks I have enabled
        //spacific properties I would like to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Img1,Name,Age,Nation," +
            "Team,Position,Appearances,Img2,Bio")] Player player)
        {
                //ensuring the application doesn't crash if nothing is entered by 
                //seting up defult images
                if (player.Img1 == null)
                {
                    player.Img1 = "http://www.silhouette-portrait.com/images/silhouettes05.jpg";
                }

                if (player.Img2 == null)
                {
                    player.Img2 = "https://i.pinimg.com/564x/1e/9e/e5/1e9ee5b20b0ad38152bfb6ceb9eb1120.jpg";
                }

            //testing for any uncaught validation errors.
            try
            {
                //saving changes to database.
                if (ModelState.IsValid)
                {
                    db.Players.Add(player);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            //the bug will be traced and displayed in the output page of the debugger.
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return View(player);
        }
            

        // GET: Home/Edit/5
        public ActionResult Edit(int? Id)
        {
            if (Id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = db.Players.Find(Id);
            if (Id == null) {
                return HttpNotFound();
            }

            return View(player);
        }

        // POST: Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Img1,Name,Age,Nation," +
            "Team,Position,Appearances,Img2,Bio")] Player player)
        {
            //ensuring the application doesn't crash if nothing is entered by 
            //seting up defult images
            if (player.Img1 == null)
            {
                player.Img1 = "http://www.silhouette-portrait.com/images/silhouettes05.jpg";
            }

            if (player.Img2 == null)
            {
                player.Img2 = "https://i.pinimg.com/564x/1e/9e/e5/1e9ee5b20b0ad38152bfb6ceb9eb1120.jpg";
            }

            //testing for any uncaught validation errors.
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(player).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //the bug will be traced and displayed in the output page of the debugger
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return View(player);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? Id)
        {
            if (Id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = db.Players.Find(Id);
            if (player == null) {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Home/Delete/5
        
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? Id)
        {
            Player player = db.Players.Find(Id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }//Home controller
}//NameSpace 
