using agenda.Data;
using agenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace agenda.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly agendaContext _db;
        public AppointmentController(agendaContext db)
        {
            _db = db;
        }

        //LIST
        public IActionResult Index()
        {
            var appointment = _db.Appointments.ToList();
           
            return View(appointment);
        }

        //ADD
        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<Customer> Customers = _db.Customers;
            ViewBag.Customers = Customers.ToList();
            IEnumerable<Broker> Brokers = _db.Brokers;
            ViewBag.Brokers = Brokers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Appointment obj)
        {
            _db.Appointments.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "le rendez vous a bien été ajouté";
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
            var Appointment = _db.Appointments.Find(id);
            if (Appointment == null)
            {
                return NotFound();
            }
            return View(Appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Appointment obj)
        {
            _db.Appointments.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
