using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IRRCMS.EntityModelsClasses;
using IRRCMS.Models;

namespace IRRCMS.Areas.Admin.Controllers
{
    public class ResidentsController : Controller
    {
        private IrrcmsDbContext ctx = new IrrcmsDbContext();

        // GET: Admin/Residents
        public ActionResult Index()
        {
            var residents = ctx.Residents.Include(r => r.BuildingUnit);
            return View(residents.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = ctx.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        public ActionResult Create()
        {
            ViewBag.BuildingUnit_Id = new SelectList(ctx.BuildingUnits, "Id", "UnitNo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumOfOccupants,BuildingUnit_Id")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                ctx.Residents.Add(resident);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingUnit_Id = new SelectList(ctx.BuildingUnits, "Id", "UnitNo", resident.BuildingUnit_Id);
            return View(resident);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = ctx.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingUnit_Id = new SelectList(ctx.BuildingUnits, "Id", "UnitNo", resident.BuildingUnit_Id);
            return View(resident);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumOfOccupants,BuildingUnit_Id")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(resident).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuildingUnit_Id = new SelectList(ctx.BuildingUnits, "Id", "UnitNo", resident.BuildingUnit_Id);
            return View(resident);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = ctx.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resident resident = ctx.Residents.Find(id);
            ctx.Residents.Remove(resident);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
