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
    }
}