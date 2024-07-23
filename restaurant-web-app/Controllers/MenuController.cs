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
        private static DB db = new DB();
        // GET: MenuController 
        public ActionResult Index()
        {
            List<Menu> menuItems = db.Menu.ToList();

            return View(menuItems);
        }

        // GET: MenuController/Details/5
        public ActionResult Details(int id)
        {
            var menu = db.Menu.Find(id);
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
                db.Menu.Add(newMenu);
                db.SaveChanges();
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
            var menuModification = db.Menu.Find(id);
            var menu = db.Menu.ToList();
            return View(menuModification);
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu menuEdited)
        {
            try
            {
                var menuOrg = db.Menu.Find(menuEdited.nrMenu);

                if (menuOrg != null)
                {
                    menuOrg.nrMenu = menuEdited.nrMenu;
                    menuOrg.titulli = menuEdited.titulli;
                    db.SaveChanges();
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
            var menuDeleting = db.Menu.Find(id);

            return View(menuDeleting);
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var menuDeleting = db.Menu.Find(id);
                db.Menu.Remove(menuDeleting);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
