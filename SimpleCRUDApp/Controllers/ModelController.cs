using SimpleCRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SimpleCRUDApp.Controllers
{
    public class ModelController : Controller
    {
        readonly Ent db = new Ent();
        // GET: Model
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            Item item1 = db.Items.Find(item.ID);
            item1.Name = item.Name;
            item1.Description = item.Description;
            item1.Price = item.Price;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }
        public ActionResult Delete(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Delete(Item item)
        {
            Item i1 = db.Items.Find(item.ID);
            db.Items.Remove(i1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}