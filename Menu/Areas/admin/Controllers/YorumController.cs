using Menu.Baglanti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu.Areas.admin.Controllers
{
    public class YorumController : Controller
    {
        Sorgular sorgu = new Sorgular();

        public ActionResult Index()
        {
            var yorum = sorgu.Yorumlar();
            return View(yorum);
        }

        public ActionResult YorumSil(int id)
        {
           
            sorgu.YorumSil(id);
            TempData["Uyari"] = "İşlem başarılı";
            return RedirectToAction("Index");
        }
    }
}