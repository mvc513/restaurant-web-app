using Microsoft.AspNetCore.Http;
using restaurant_web_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace restaurant_web_app.Controllers
{
    public class BookNowController : Controller
    {
        private readonly DB _db;

        // Constructor for dependency injection
        public BookNowController(DB db)
        {
            _db = db;
        }
        // GET: bookNowController
        public ActionResult Index()
        {
            List<BookNow> bookings = _db.BookNow.ToList();
            return View(bookings);
        }

        // GET: bookNowController/Details/5
        public ActionResult Details(int id)
        {
            var booking = _db.BookNow.Find(id);
            return View(booking);
        }

        // GET: bookNowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bookNowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookNow newBooking)
        {
            if (ModelState.IsValid)
            {
                _db.BookNow.Add(newBooking);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(newBooking);
        }

        // GET: bookNowController/Edit/5
        public ActionResult Edit(int id)
        {
            var bookingEdited = _db.BookNow.Find(id);
            return View(bookingEdited);
        }

        // POST: bookNowController/Edit/5
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: bookNowController/Delete/5
        public ActionResult Delete(int id)
        {
            var bookingDelete = _db.BookNow.Find(id);

            return View(bookingDelete);
        }

        // POST: bookNowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var bookingDeleting = _db.BookNow.Find(id);
                _db.BookNow.Remove(bookingDeleting);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
