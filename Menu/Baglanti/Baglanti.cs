using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menu.Baglanti
{
    public class Baglanti
    {
        private const string adres = "localhost";
        private const string veritabani = "menu";
        private const string kullanici = "root";
        private const string sifre = "";


        //private const string adres = "localhost";
        //private const string veritabani = "u9544174_menu";
        //private const string kullanici = "u9544174_menu";
        //private const string sifre = "RAkr55K4YTfg89I";

        public const string BaglantiCumlesi = "Server=" + adres + ";" +
                                                          "Database=" + veritabani + ";" +
                                                          "Uid=" + kullanici + ";" +
                                                          "Pwd=" + sifre + ";" +
            "Persist Security Info=True;pooling=false;Allow User Variables=True; charset=utf8;Max Pool Size=1000;ConnectionReset=True";
    }
}