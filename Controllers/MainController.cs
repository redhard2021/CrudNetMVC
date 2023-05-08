using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MainController : Controller
    {

        ContactData _contactData = new ContactData();

        public IActionResult Technologies() { return View(); }

        public IActionResult About() { return View(); }
        public IActionResult GetList()
        {
            var list = _contactData.GetList();
            return View(list);
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(ContactModel contactoM)
        {
            if (!ModelState.IsValid)
                return View();

            var resp = _contactData.Save(contactoM);
            if (resp)
                return RedirectToAction("GetList");
            return View();
        }

        public IActionResult Edit(int IdContact)
        {
            ContactModel contact = _contactData.Obtain(IdContact);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            if (!ModelState.IsValid)
                return View();

            var resp = _contactData.Edit(contact);
            if (resp)
                return RedirectToAction("GetList");
            return View();
        }

        public IActionResult Delete(int IdContact)
        {
            var contacto = _contactData.Obtain(IdContact);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Delete(ContactModel contact)
        {
            var name = contact.Name;
            var resp = _contactData.Eliminar(contact.IdContact);
            if (resp)
                return RedirectToAction("GetList");
            return View();
        }

    }
}
