using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant_web_app.Models;
using System.Linq.Expressions;

namespace restaurant_web_app.Controllers
{
    public class itemController : Controller
    {
        private static DB db = new DB();
        
        public ActionResult Index()
        {
            List<Item> items = new List<Item>();
            items = db.Item.ToList();
            return View(items);
        }

        // GET: itemController/Details/5
        public ActionResult Details(int id)
        {
            var item = db.Item.Find(id);
            return View(item);
        }

        // GET: itemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: itemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item newItem)
        {
            try
            {
                db.Item.Add(newItem);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: itemController/Edit/5
        public ActionResult Edit(int id) 
        {
            var itemEdited = db.Item.Find(id);
            return View(itemEdited);
        }

        // POST: itemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item itemEdited)
        {
            try
            {
                var itemOrg = db.Item.Find(itemEdited.itemID);
                itemOrg.Name = itemEdited.Name;
                itemOrg.Description = itemEdited.Description;
                itemOrg.Price = itemEdited.Price;
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }


        // GET: itemController/Delete/5
        public ActionResult Delete(int id)
        {
            var itemDelete = db.Item.Find(id);

            return View(itemDelete);
        }

        // POST: itemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteDelete(int id)
        {
            try
            {
                var itemDeleting = db.Item.Find(id);
                db.Item.Remove(itemDeleting);
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
