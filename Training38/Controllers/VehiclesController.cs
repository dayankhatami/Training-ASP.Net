using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training38.Models;

namespace Training38.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class VehiclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vehicles
        [AllowAnonymous]
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include("Category").ToList();
            return View(vehicles);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = db.Vehicles.Include("Category").Where(x => x.IdVehicle == id).SingleOrDefault();
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            //Categories
            var categories = db.Categories.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdCategory,
                Selected = false
            }).ToArray();
            ViewBag.Categories = categories;
            return View();
        }

        private void ToArray()
        {
            throw new NotImplementedException();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.Vehicle addVehicle)
        {
            var category = db.Categories.Find(addVehicle.Category);
            if (category!= null)
            {
                var vehicle = new Vehicle()
                {
                    IdVehicle = Guid.NewGuid().ToString(),
                    Name = addVehicle.Name,
                    Category = category,
                    Color = addVehicle.Color,
                    Description = addVehicle.Description,
                    Fuel = addVehicle.Fuel,
                    Wheel = addVehicle.Wheel,
                };
                db.Vehicles.Add(vehicle);
                var result=db.SaveChanges();
                if(result>0)
                { 
                return RedirectToAction("Index");
                }
            }

            return View(addVehicle);
        }

        private ActionResult Edit()
        {
            throw new NotImplementedException();
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = db.Vehicles.Include("Category").Where(x => x.IdVehicle == id)
                .SingleOrDefault();
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            var categories = db.Categories.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdCategory,
                Selected = false
            }).ToArray();
            if (vehicle.Category != null)
            {
                foreach (var l in categories)
                {
                    if (vehicle.Category.IdCategory == l.Value)
                    {
                        l.Selected = true;
                    }
                }
            }
            ViewBag.Categories = categories;
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModels.EditVehicle editVehicle)
        {
            if (ModelState.IsValid)
            {
                var vehicle = db.Vehicles.Find(editVehicle.IdVehicle);
                var category = db.Categories.Find(editVehicle.Category);
                if (category != null)
                {
                    vehicle.Name = editVehicle.Name;
                    vehicle.Description = editVehicle.Description;
                    vehicle.Wheel = editVehicle.Wheel;
                    vehicle.Color = editVehicle.Color;
                    vehicle.Fuel = editVehicle.Fuel;
                    vehicle.Category = category;
                }
                db.Entry(vehicle).State = EntityState.Modified;
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(editVehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
