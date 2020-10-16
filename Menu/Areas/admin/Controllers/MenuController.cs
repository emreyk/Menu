using Menu.Baglanti;
using Menu.Filters;
using Menu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Menu.Areas.admin.Controllers
{
    [ExcFilter, AuthFilter]
    public class MenuController : Controller
    {

        Sorgular sorgu = new Sorgular();

        
        public ActionResult Index()
        {
            var kategoriler = sorgu.Kategoriler();
            return View(kategoriler);
        }

        public ActionResult Kategoriekle()
        {
            var kategoriler = sorgu.Kategoriler();
            return View(kategoriler);

        }

        [HttpPost]
        public ActionResult Kategoriekle(kategori model, HttpPostedFileBase ResimURL)
        {
            if (ResimURL != null)
            {
                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);
                string menuSayfalar = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(370, 355, preserveAspectRatio: false);
                img.Save("~/Uploads/Menu/" + menuSayfalar);
                model.resim = "/Uploads/Menu/" + menuSayfalar;
            }

            sorgu.KategoriKaydet(model);
            //TempData["Uyari"] = "İşlem başarılı";
            return Redirect("Kategoriekle");
        }


        public ActionResult Kategoriduzenle(int id)
        {
            TempData["id"] = id;
            var kategori = sorgu.KategoriGetir(id);
            return View(kategori);
        }

        [HttpPost]
        public ActionResult Kategoriduzenle(kategori model, HttpPostedFileBase ResimURL)
        {
            model.id = Convert.ToInt32(TempData["id"]);
            var kategori = sorgu.KategoriGetir(model.id);

            if (ResimURL != null)
            {
                if (System.IO.File.Exists(Server.MapPath(kategori.resim)))
                {
                    System.IO.File.Delete(Server.MapPath(kategori.resim));
                }

                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);
                string kategoriresim = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(370, 355, preserveAspectRatio: false);
                img.Save("~/Uploads/Menu/" + kategoriresim);
                model.resim = "/Uploads/Menu/" + kategoriresim;
            }

            else
            {
                model.resim = kategori.resim;
            }
            sorgu.KategorikGuncelle(model);
            TempData["Uyari"] = "İşlem başarılı";
            return RedirectToAction("Kategoriekle");

        }

        public ActionResult kategorisil(int id)
        {
            var kategori = sorgu.KategoriGetir(id);
            if (System.IO.File.Exists(Server.MapPath(kategori.resim)))
            {
                System.IO.File.Delete(Server.MapPath(kategori.resim));
            }
            sorgu.KategoriSil(id);
            TempData["Uyari"] = "İşlem başarılı";
            return RedirectToAction("Kategoriekle");
        }

        //menü işlemleri
        public ActionResult Ekle(int id)
        {
            TempData["id"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(menu model, HttpPostedFileBase ResimURL)
        {
            model.kategori_id = Convert.ToInt32(TempData["id"]);
            if (ResimURL != null)
            {
                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);
                string menuSayfalar = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(370, 355, preserveAspectRatio: false);
                img.Save("~/Uploads/Menu/" + menuSayfalar);
                model.resim = "/Uploads/Menu/" + menuSayfalar;
            }

            sorgu.MenuKaydet(model);
            TempData["Uyari"] = "İşlem başarılı";
            return RedirectToAction("/Ekle/" + model.kategori_id + "");
          
        }

        public ActionResult Menuler()
        {
            var menuler = sorgu.Menuler();
            return View(menuler);
        }

        public ActionResult Menuduzenle(int id)
        {
            TempData["id"] = id;
            var kategori = sorgu.MenuGetir(id);
            return View(kategori);
        }

        [HttpPost]
        public ActionResult Menuduzenle(menu model, HttpPostedFileBase ResimURL)
        {
            model.id = Convert.ToInt32(TempData["id"]);
            var kategori = sorgu.MenuGetir(model.id);

            if (ResimURL != null)
            {
                if (System.IO.File.Exists(Server.MapPath(kategori.resim)))
                {
                    System.IO.File.Delete(Server.MapPath(kategori.resim));
                }

                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);
                string kategoriresim = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(370, 355, preserveAspectRatio: false);
                img.Save("~/Uploads/Menu/" + kategoriresim);
                model.resim = "/Uploads/Menu/" + kategoriresim;
            }

            else
            {
                model.resim = kategori.resim;
            }
            sorgu.MenukGuncelle(model);
            TempData["Uyari"] = "İşlem başarılı";
            return RedirectToAction("Menuler");

        }

        public ActionResult Menusil(int id)
        {
            var kategori = sorgu.MenuGetir(id);
            if (System.IO.File.Exists(Server.MapPath(kategori.resim)))
            {
                System.IO.File.Delete(Server.MapPath(kategori.resim));
            }
            sorgu.MenuSil (id);
            TempData["Uyari"] = "İşlem başarılı";
            return RedirectToAction("Menuler");
        }
    }
}