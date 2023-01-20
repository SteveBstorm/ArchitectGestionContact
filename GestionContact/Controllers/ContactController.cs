using GestionContact.DAL.Interface;
using GestionContact.DAL.Services;
using GestionContact.Models;
using GestionContact.Tools;
using Microsoft.AspNetCore.Mvc;

namespace GestionContact.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository repo;
        public ContactController(IContactRepository contactRepository)
        {
            repo = contactRepository;
        }
        public IActionResult Index()
        {
            return View(repo.GetAll().Where(c => c.IsActive));
        }

        public IActionResult Details(int id)
        {
            return View(repo.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            repo.Create(form.ToDal());
            return RedirectToAction("Index");
        }
    }
}
