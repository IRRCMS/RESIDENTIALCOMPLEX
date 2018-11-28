using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IRRCMS;
using IRRCMS.Models;

namespace IRRCMS.Areas.Admin.Controllers
{
    public class BuildingUnitsController : Controller
    {
        private IrrcmsDbContext ctx = new IrrcmsDbContext();

        // GET: Admin/BuildingUnits
        public ActionResult Index()
        {
            return View(ctx.BuildingUnits.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingUnit buildingUnit = ctx.BuildingUnits.Find(id);
            if (buildingUnit == null)
            {
                return HttpNotFound();
            }
            return View(buildingUnit);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Area,UnitNo,MonthlyCharge,Payment,PaymentStatus,OwnerId,ResidentId")] BuildingUnit buildingUnit)
        {
            if (ModelState.IsValid)
            {
                ctx.BuildingUnits.Add(buildingUnit);
                ctx.SaveChanges();
                TempData["Message"] = "اطلاعات واحد با موفقیت افزوده شد";
                TempData["MessageClass"] = "success";

                return RedirectToAction("Index");
            }

            return View(buildingUnit);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingUnit buildingUnit = ctx.BuildingUnits.Find(id);
            if (buildingUnit == null)
            {
                return HttpNotFound();
            }
            return View(buildingUnit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Area,UnitNo,MonthlyCharge,Payment,PaymentStatus,OwnerId,ResidentId")] BuildingUnit buildingUnit)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(buildingUnit).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildingUnit);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingUnit buildingUnit = ctx.BuildingUnits.Find(id);
            if (buildingUnit == null)
            {
                return HttpNotFound();
            }
            return View(buildingUnit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildingUnit buildingUnit = ctx.BuildingUnits.Find(id);
            ctx.BuildingUnits.Remove(buildingUnit);
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
