using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookMonolithic.CRUDServices;
using System.Collections.Generic;
using PhoneBookMonolithic.Models;
using System;

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
        public ActionResult Details(string? id)
        {
            var contact = ((List<Contact>)service.GetAll()).Find(x => x.UUID == id);
            return View(contact);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            Contact _cx = new Contact();
            _cx.CreateContactInfos();
            return View(_cx);
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact c)
        {
            try
            {
                service.Create(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(c);
            }
        }



        // GET: ContactController/Edit/5
        public ActionResult Edit(string? id)
        {
            var model = service.GetOne(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact c)
        {
            try
            {
                service.Update(c);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(c.UUID);
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(string? id)
        {
            var c = service.GetOne(id);
            return View(c);
        }

        // POST: ContactController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string? id)
        {
            var entity = service.GetOne(id);
            try
            {
                if (entity == null)
                    throw new NotImplementedException();
                else
                {
                    service.DeletOne(entity);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(entity);
            }
        }

        [HttpPost]
        public IActionResult GetProperInputField(int count, string data, int type)
        {
            return ViewComponent("InputComponent", new { count = count, data = data, tip = (CommunicationInfoType)type });
        }

        [HttpPost]
        public IActionResult GetComInfoCreateFields(int count)
        {
            return ViewComponent("CommunicationInfoComponent", new { count = count });
        }

        public IActionResult GetCommunicationInfoEditPartial(int count, Models.CommunicationInfo info)
        {
            return PartialView("_partialComInfoEdit", new Tuple<int, CommunicationInfo>(count, info));
        }



    }
}
