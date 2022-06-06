using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookMonolithic.CRUDServices;
using System.Collections.Generic;
using PhoneBookMonolithic.Models;

namespace PhoneBookMonolithic.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService service;

        public ContactController(ContactService _cs)
        {
            service = _cs;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: ContactController/Details/5
        public ActionResult Details(string?  id)
        {
            //var contact = service.GetAll().Find(x=>x.UUID==id);
            //return View(contact);
            return View();
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactDTO _c)
        {
            try
            {
                Contact cx = new Contact()
                {
                    Ad = _c.Ad,
                    Soyad = _c.Soyad,
                    Firma = _c.Firma,
                    CommuncationInfos = new List<CommunicationInfo>()
                };
                cx.CommuncationInfos.Add(new CommunicationInfo() { InfoType = _c.InfoType, Value = _c.Value });
                service.Create(cx);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactController/Edit/5
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

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
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
