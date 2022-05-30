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
            IEnumerable<Appointment> Appointments = _db.Appointments;
            return View(Appointments);
        }

        public IActionResult Profil(int? id)
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

        //ADD
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Appointment obj)
        {
            _db.Appointments.Add(obj);
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
