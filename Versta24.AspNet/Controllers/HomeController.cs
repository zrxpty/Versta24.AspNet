using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Versta24.AspNet.Data;
using Versta24.AspNet.Models;

namespace Versta24.AspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;
        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _db = appDbContext;
        }
        //Get
        public IActionResult Index()
        {
            return View();
        }
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public IActionResult ViewOrder()
        {
            IEnumerable<Order> objList = _db.Orders;
            return View(objList);  
        }
        //GET - EDIT
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewOrder");
            }
            return View(obj);

        }
        //GET - DELETE
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOrder(Guid? id)
        {
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Orders.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("ViewOrder");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}