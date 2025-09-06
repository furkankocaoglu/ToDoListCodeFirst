using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using ToDoListMVC.Models;

namespace ToDoListMVC.Controllers
{
    public class WorkController : Controller
    {
        ToDoListDB db = new ToDoListDB();
        public ActionResult Index()
        {
            return View(db.Works.Where(x => x.Deleted == false && x.IsCompleted == false).ToList());   
        }

        public ActionResult Completed()
        {
            return View(db.Works.Where(x => x.Deleted == false && x.IsCompleted == true).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Work Model)
        {
            if(ModelState.IsValid)
            {
                db.Works.Add(Model);
                db.SaveChanges();
                TempData["Mesaj"] = "Görev Eklendi";
                return RedirectToAction("Index", "Work");
            }
            return View (Model);
        }

        [HttpGet]
        public ActionResult Edit(int?id)
        {
            if(id!=null)
            {
                Work w =db.Works.Find(id);
                if(w!=null)
                {
                    return View(w);
                }
            }
            return RedirectToAction("Index", "Work");
        }

        [HttpPost]
        public ActionResult Edit(Work Model)
        {
            if(ModelState.IsValid)
            {
                Work w = db.Works.FirstOrDefault(x=> x.Id == Model.Id);

                if(w!=null)
                {
                    w.Title = Model.Title;
                    w.IsCompleted = Model.IsCompleted;
                    db.SaveChanges();

                    TempData["Mesaj"] = "Güncelleme Yapıldı";
                    return RedirectToAction("Index", "Work");
                }
                else
                {
                    TempData["Mesaj"] = "Bulunamadı";
                }
            }
               return View(Model);
        }
        public ActionResult Delete(int?id)
        {
            if(id != null)
            {
                Work w = db.Works.Find(id);

                if(w!=null)
                {
                    w.Deleted = true;
                    db.SaveChanges();
                    TempData["Mesaj"] = "Silindi";
                }
            }
            return RedirectToAction("Index","Work"); 
        }
        public ActionResult Back(int? id)
        {
            if (id != null)
            {
                Work w = db.Works.Find(id);

                if (w != null)
                {
                    w.IsCompleted = false;
                    db.SaveChanges();
                    TempData["Mesaj"] = "İşlem Geri Alındı";
                }
            }
            return RedirectToAction("Index", "Completed");
        }
        public ActionResult Done(int? id)
        {
            if (id!=null)
            {
                Work w = db.Works.Find(id);
                if(w!=null)
                {
                    w.IsCompleted = true;
                    db.SaveChanges();
                    TempData["Mesaj"] = "Tamamlandı Olarak İşaretlendi";
                }            
            }
            return RedirectToAction("Index", "Work");
        }

    }
}