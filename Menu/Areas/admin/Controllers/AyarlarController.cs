
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Menu.Baglanti;
using Menu.Models;
using Menu.Filters;

namespace Menu.Areas.admin.Controllers
{
    [ExcFilter, AuthFilter]
    public class AyarlarController : Controller
    {
        Sorgular sorgu = new Sorgular();

        public ActionResult Index()
        {
            var ayarlar = sorgu.AyarGetir();
            return View(ayarlar);
            
        }

        [HttpPost]
        public ActionResult Index(ayar model)
        {
            sorgu.AyarGuncelle(model);
            TempData["Uyari"] = "İşlem başarılı";
            var ayarlar = sorgu.AyarGetir();
            return View(ayarlar);
        }
  
    }

 
}