using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using classdemotoday.Areas.Common.Models;

namespace classdemotoday.Areas.Shop.Controllers
{
    public class ItemDetailsController : Controller
    {
        private Emartweb db = new Emartweb();

        // GET: Shop/ItemDetails
        public async Task<ActionResult> Index()
        {
            var itemDetails = db.ItemDetails.Include(i => i.Category);
            return View(await itemDetails.ToListAsync());
        }

        // GET: Shop/ItemDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetail itemDetail = await db.ItemDetails.FindAsync(id);
            if (itemDetail == null)
            {
                return HttpNotFound();
            }
            return View(itemDetail);
        }

        // GET: Shop/ItemDetails/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Code");
            return View();
        }

        // POST: Shop/ItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CategoryId,ItemCode,Name,Description,UnitPrice,ImageURL,OrderId,IsActive,CreatedDateTime,ModifiedDatetime,CreatedUserId,ModifiedUserId")] ItemDetail itemDetail)
        {
            if (ModelState.IsValid)
            {
                db.ItemDetails.Add(itemDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Code", itemDetail.CategoryId);
            return View(itemDetail);
        }

        // GET: Shop/ItemDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetail itemDetail = await db.ItemDetails.FindAsync(id);
            if (itemDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Code", itemDetail.CategoryId);
            return View(itemDetail);
        }

        // POST: Shop/ItemDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CategoryId,ItemCode,Name,Description,UnitPrice,ImageURL,OrderId,IsActive,CreatedDateTime,ModifiedDatetime,CreatedUserId,ModifiedUserId")] ItemDetail itemDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Code", itemDetail.CategoryId);
            return View(itemDetail);
        }

        // GET: Shop/ItemDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetail itemDetail = await db.ItemDetails.FindAsync(id);
            if (itemDetail == null)
            {
                return HttpNotFound();
            }
            return View(itemDetail);
        }

        // POST: Shop/ItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItemDetail itemDetail = await db.ItemDetails.FindAsync(id);
            db.ItemDetails.Remove(itemDetail);
            await db.SaveChangesAsync();
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
