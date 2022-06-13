using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookMonolithic.CRUDServices;
using PhoneBookMonolithic.Models;

namespace PhoneBookMonolithic.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportService service;
        private readonly LocationService ls;
        public ReportController(ReportService rs,LocationService l)
        {
            service = rs;
            ls = l;
        }

        // GET: ReportController
        public ActionResult Index()
        {
            
            return View(service.GetAll());
        }

        // GET: ReportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: ReportController/Create
        [HttpPost]
        public ActionResult Create()
        {
            try
            {
                Report r = new Report();
                r.RequestDate = System.DateTime.Now;
                r.Status = ReportStatus.Preparing;
                service.CreateAsync(r);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
