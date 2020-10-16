using Menu.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu.Filters
{
    public class ExcFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {

            string username = string.Empty;
            int kayitSonucu;
            var test = filterContext.HttpContext.Session["yonetim"];
            var mesaj = filterContext.Exception.Message.Replace("'", "`");
            //uye veya yonetici girisi yapılmıssa session varsa
            if (filterContext.HttpContext.Session["yonetim"] != null)
                username = (filterContext.HttpContext.Session["yonetim"] as CurrentSession).kadi;


            using (MySqlConnection con = new MySqlConnection(Baglanti.Baglanti.BaglantiCumlesi))
            {
                con.Open();

                var logKaydet = "INSERT IGNORE INTO logs (user_name,controller_name,action_name,tarih,bilgi) " +
                    "VALUES ( '" + username + "','" + filterContext.RouteData.Values["controller"].ToString() + "', " +
                    "'" + filterContext.RouteData.Values["action"].ToString() + "','" + DateTime.Now.ToString() + "','" + mesaj + "')";

                using (MySqlCommand cmd = new MySqlCommand(logKaydet, con))
                {
                    kayitSonucu = cmd.ExecuteNonQuery();

                }
                con.Close();
            }



            filterContext.ExceptionHandled = true;
            //filterContext.Controller.TempData["hata"] =  filterContext.Exception.Message;
            filterContext.Result = new RedirectResult("/admin/Error");
        }
    }
}