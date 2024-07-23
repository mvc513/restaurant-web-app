using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restaurant_web_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace restaurant_web_app.Controllers
{
    public class MenuController : Controller
    {
        private static DB _db;

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
            try
            {
                _db.Menu.Add(newMenu);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var menuModification = _db.Menu.Find(id);
            var menu = _db.Menu.ToList();
            return View(menuModification);
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu menuEdited)
        {
            try
            {
                var menuOrg = _db.Menu.Find(menuEdited.nrMenu);

                if (menuOrg != null)
                {
                    menuOrg.nrMenu = menuEdited.nrMenu;
                    menuOrg.titulli = menuEdited.titulli;
                    _db.SaveChanges();
                }
                else
                {

                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Delete/5
        public ActionResult Delete(int id)
        {
            var menuDeleting = _db.Menu.Find(id);

            return View(menuDeleting);
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var menuDeleting = _db.Menu.Find(id);
                _db.Menu.Remove(menuDeleting);
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
