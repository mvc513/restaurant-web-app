using Microsoft.AspNetCore.Mvc;
using restaurant_web_app.Models;
using System.Collections.Generic;
using System.Linq;

namespace restaurant_web_app.Controllers
{
    public class MenuController : Controller
    {
        private readonly DB _db;

        // Constructor for dependency injection
        public MenuController(DB db)
        {
            _db = db;
        }

        // GET: MenuController 
        public ActionResult Index()
        {
            List<Menu> menuItems = _db.Menu.ToList();
            return View(menuItems);
        }

        // GET: MenuController/Details/5
        public ActionResult Details(int id)
        {
            var menu = _db.Menu.Find(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // GET: MenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menu newMenu)
        {
            if (ModelState.IsValid)
            {
                _db.Menu.Add(newMenu);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(newMenu);
        }

        // GET: MenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var menuModification = _db.Menu.Find(id);
            if (menuModification == null)
            {
                return NotFound();
            }
            return View(menuModification);
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu menuEdited)
        {
            if (ModelState.IsValid)
            {
                var menuOrg = _db.Menu.Find(menuEdited.nrMenu);

                if (menuOrg != null)
                {
                    menuOrg.titulli = menuEdited.titulli; // Update only the title
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return NotFound(); // Handle not found case
            }
            return View(menuEdited); // Return the view with the model state errors
        }

        // GET: MenuController/Delete/5
        public ActionResult Delete(int id)
        {
            var menuDeleting = _db.Menu.Find(id);
            if (menuDeleting == null)
            {
                return NotFound();
            }
            return View(menuDeleting);
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            var menuDeleting = _db.Menu.Find(id);
            if (menuDeleting != null)
            {
                _db.Menu.Remove(menuDeleting);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
