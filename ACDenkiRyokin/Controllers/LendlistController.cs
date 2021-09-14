using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACDenkiRyokin.Models;

namespace ACDenkiRyokin.Controllers
{
    public class LendlistController : Controller
    {
        private db_denkiEntities1 db = new db_denkiEntities1();

        // GET: Lendlist
        public ActionResult Index()
        {
            return View(db.denki_ryokin.ToList());
        }

        // GET: Lendlist/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            denki_ryokin denki_ryokin = db.denki_ryokin.Find(id);
            if (denki_ryokin == null)
            {
                return HttpNotFound();
            }
            return View(denki_ryokin);
        }

        // GET: Lendlist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lendlist/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChangeInfomation,Date,Applicant,Status")] denki_ryokin denki_ryokin)
        {
            if (ModelState.IsValid)
            {
                db.denki_ryokin.Add(denki_ryokin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(denki_ryokin);
        }

        // GET: Lendlist/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            denki_ryokin denki_ryokin = db.denki_ryokin.Find(id);
            if (denki_ryokin == null)
            {
                return HttpNotFound();
            }
            return View(denki_ryokin);
        }

        // POST: Lendlist/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManagementID,ChangeInfomation,Date,Applicant,Status")] denki_ryokin denki_ryokin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(denki_ryokin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(denki_ryokin);
        }

        // GET: Lendlist/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            denki_ryokin denki_ryokin = db.denki_ryokin.Find(id);
            if (denki_ryokin == null)
            {
                return HttpNotFound();
            }
            return View(denki_ryokin);
        }

        // POST: Lendlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            denki_ryokin denki_ryokin = db.denki_ryokin.Find(id);
            db.denki_ryokin.Remove(denki_ryokin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //検索設定
        [HttpPost]
        public ActionResult Search(string ManagementID, string ChangeInfomation, string Date, string Applicant, string Status)
        {
            var changeorders = from orders in db.denki_ryokin select orders;



            DateTime workDate;


            if (!string.IsNullOrEmpty(ManagementID))
            {
                changeorders = changeorders.Where(a => a.ManagementID.Equals(ManagementID));
            }

            if (!string.IsNullOrEmpty(ChangeInfomation))
            {
                changeorders = changeorders.Where(a => a.ChangeInfomation.Equals(ChangeInfomation));
            }

            if (!string.IsNullOrEmpty(Date))
            {
                workDate = DateTime.Parse(Date);
                changeorders = changeorders.Where(a => a.Date == workDate);
            }

            if (!string.IsNullOrEmpty(Applicant))
            {
                changeorders = changeorders.Where(a => a.Applicant.Equals(Applicant));
            }

            if (!string.IsNullOrEmpty(Status))
            {
                changeorders = changeorders.Where(a => a.Status.Equals(Status));
            }

        
            changeorders = changeorders.OrderByDescending(a => a.Date);


            return View("Index", changeorders.ToList());
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