using GestionContact.DAL.Interface;
using GestionContact.DAL.Models;
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
            return View(repo.GetAll());
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

        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            Contact toEdit = repo.GetById(id);
            ContactForm toView = toEdit.ToAsp();

            return View(toView);
        }
        [HttpPost]
        public IActionResult Edit(ContactForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            if (!repo.Update(form.ToDal()))
                return View(form);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Activate(int id)
        {
            repo.ReActivate(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
