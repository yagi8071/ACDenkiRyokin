using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ACDenkiRyokin.Models;

namespace ACDenkiRyokin.Controllers
{
    public class denki_ryokinController : Controller
    {
        private db_denkiEntities1 db = new db_denkiEntities1();

        // GET: denki_ryokin
        public ActionResult Index()
        {
            return View(db.denki_ryokin.ToList());
        }

        // GET: denki_ryokin/Details/5
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

        // GET: denki_ryokin/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: denki_ryokin/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManagementID,ChangeInfomation,Date,Applicant,Status")] denki_ryokin denki_ryokin)
        {
            if (ModelState.IsValid)
            {
                db.denki_ryokin.Add(denki_ryokin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(denki_ryokin);
        }

        // GET: denki_ryokin/Edit/5
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

        // POST: denki_ryokin/Edit/5
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

        // GET: denki_ryokin/Delete/5
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

        // POST: denki_ryokin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            denki_ryokin denki_ryokin = db.denki_ryokin.Find(id);
            db.denki_ryokin.Remove(denki_ryokin);
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
