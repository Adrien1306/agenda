using agenda.Data;
using agenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace agenda.Controllers
{
    public class BrokerController : Controller
    {
        private readonly agendaContext _db;
        public BrokerController(agendaContext db)
        {
            _db = db;
        }

        //LIST
        public IActionResult Index()
        {
            IEnumerable<Broker> Brokers = _db.Brokers;
            return View(Brokers);
        }

        public IActionResult Profil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Broker = _db.Brokers.Find(id);
            if (Broker == null)
            {
                return NotFound();
            }
            return View(Broker);
        }

        //ADD
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Broker obj)
        {
            _db.Brokers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //EDIT
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Broker = _db.Brokers.Find(id);
            if (Broker == null)
            {
                return NotFound();
            }
            return View(Broker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Broker obj)
        {
            _db.Brokers.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
