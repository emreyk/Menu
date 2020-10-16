using Menu.Baglanti;
using Menu.Models;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        Sorgular sorgu = new Sorgular();
        public ActionResult Index(CurrentSession model)
        {
            var yonetici = sorgu.YoneticiKontrol(model);
            if (yonetici.kadi != null && yonetici.sifre != null)
            {
                Session["yonetim"] = yonetici;
                return Redirect("/admin/default");
            }
            else
            {
                TempData["giris"] = "Kullanıcı bilgileri eksik veya hatalı";
                return View();
            }
        }

        public ActionResult Cikis()
        {
            Session.Abandon();
            return Redirect("/admin/login");
        }
    }
}