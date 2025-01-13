using Exercice1MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exercice1MVC.Controllers
{
    public class ContactController : Controller
    {
        // Liste statique de contacts
        private static List<ContactModel> contacts = new List<ContactModel>
        {
            new ContactModel { Id = 1, Name = "Jean Dupont", PhoneNumber = "0123456789", Email = "jean.dupont@email.com" },
            new ContactModel { Id = 2, Name = "Marie Martin", PhoneNumber = "0987654321", Email = "marie.martin@email.com" },
            new ContactModel { Id = 3, Name = "Pierre Durand", PhoneNumber = "0112233445", Email = "pierre.durand@email.com" }
        };

        // GET: /Contact/
        public ActionResult Index()
        {
            ViewBag.Message = "Votre liste de contacts";
            return View();
        }

        // GET: /Contact/LesContacts/
        public ActionResult LesContacts()
        {
            return View(contacts);
        }

        // GET: /Contact/AddContact/
        public ActionResult AddContact()
        {
            return View();
        }

        // POST: /Contact/AddContact/
        [HttpPost]
        public ActionResult AddContact(ContactModel newContact)
        {
            if (ModelState.IsValid)
            {
                newContact.Id = contacts.Count + 1; 
                contacts.Add(newContact);
                return RedirectToAction("LesContacts");
            }
            return View(newContact);
        }
    }
}
