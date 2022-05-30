using agenda.Data;
using agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda.Controllers
{
    public class CustomerController : Controller
    {
        private readonly agendaContext _db;
        public CustomerController(agendaContext db)
        {
            _db = db;
        }

        //LIST
        public IActionResult Index()
        {
            IEnumerable<Customer> Customers = _db.Customers.FromSqlRaw("SELECT * FROM customers ORDER BY lastname ASC");
            /*return View(Customers.OrderBy(element => element.Lastname));*/
            return View(Customers);
        }

        public IActionResult Profil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Customer = _db.Customers.Find(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        //ADD
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Customer obj)
        {
            _db.Customers.Add(obj);
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
            var Customer = _db.Customers.Find(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer obj)
        {
            _db.Customers.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Customer = _db.Customers.Find(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer obj)
        {
            _db.Customers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

