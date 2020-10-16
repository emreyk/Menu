using Menu.Baglanti;
using Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu.Controllers
{
    public class HomeController : Controller
    {
        Sorgular sorgu = new Sorgular();
        public ActionResult Index()
        {
            var kategoriler = sorgu.Kategoriler();
            
            return View(kategoriler);
        }

        public ActionResult Detay(int id)
        {
            var menu = sorgu.KatMenuGetir(id);
            return View(menu);
        }


        public ActionResult Yorumyap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yorumyap(yorum model)
        {
            sorgu.YorumKaydet(model);
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}