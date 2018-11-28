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
    public class CostsController : Controller
    {
        private IrrcmsDbContext ctx = new IrrcmsDbContext();

        // GET: Admin/Costs
        public ActionResult Index()
        {
           
            return View(ctx.Costs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = ctx.Costs.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wage,Maintenance,Date,Description")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                ctx.Costs.Add(cost);
                ctx.SaveChanges();
                TempData["Message"] = "هزینه با موفقیت افزوده شد";
                TempData["MessageClass"] = "success";

                return RedirectToAction("Index");
            }

            return View(cost);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = ctx.Costs.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wage,Maintenance,Date,Description")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(cost).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cost);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cost cost = ctx.Costs.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cost cost = ctx.Costs.Find(id);
            ctx.Costs.Remove(cost);
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
