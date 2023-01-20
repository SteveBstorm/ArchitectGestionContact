using GestionContact.DAL.Interface;
using GestionContact.DAL.Services;
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
    }
}
