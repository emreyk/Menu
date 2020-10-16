using Menu.Baglanti;
using Menu.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu.Areas.admin.Controllers
{
    [ExcFilter, AuthFilter]
    public class DefaultController : Controller
    {
        Sorgular sorgu = new Sorgular();

        public ActionResult Index()
        {
            ViewBag.ToplamKategori = sorgu.KategoriToplam();
            ViewBag.ToplamMenu = sorgu.MenuToplam();
            return View();
        }
    }
}