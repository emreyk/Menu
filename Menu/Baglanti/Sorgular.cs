using Menu.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Menu.Baglanti
{
    public class Sorgular
    {
        public void KategoriKaydet(kategori model)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                con.Open();

                var kategoriKaydet = "INSERT IGNORE INTO kategori (ad , resim) " +
                    "VALUES ('" + model.ad + "', '" + model.resim + "' )";


                using (MySqlCommand cmd = new MySqlCommand(kategoriKaydet, con))
                {
                    cmd.ExecuteNonQuery();

                }

                con.Close();
            }


        }
        public List<kategori> Kategoriler()
        {
            var kategori = new List<kategori>();

            using (MySqlConnection connection = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var kategoriGelen = "SELECT * FROM kategori";

                connection.Open();
                using (MySqlCommand command = new MySqlCommand(kategoriGelen, connection))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        kategori model = new kategori();
                        model.id = Convert.ToInt32(reader["id"]);
                        model.ad = reader["ad"].ToString();
                        model.resim = reader["resim"].ToString();

                        kategori.Add(model);
                    }

                }

                connection.Close();
            }



            return kategori;

        }
        public kategori KategoriGetir(int id)
        {
            kategori modelKategori = new kategori();
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var paketSorgu = "SELECT * FROM kategori WHERE id = '" + id + "'  ";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(paketSorgu, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        modelKategori.id = Convert.ToInt32(reader["id"]);
                        modelKategori.ad = reader["ad"].ToString();
                        modelKategori.resim = reader["resim"].ToString();

                    }


                }
                con.Close();
            }

            return modelKategori;

        }
        public void KategorikGuncelle(kategori model)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var guncelle = " UPDATE kategori SET ad='" + model.ad + "',resim='" + model.resim + "' WHERE id='" + model.id + "' ";

                using (MySqlCommand cmd = new MySqlCommand(guncelle, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }
        public void KategoriSil(int id)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                con.Open();

                var sliderSil = "Delete From kategori where id = '" + id + "' ";


                using (MySqlCommand cmd = new MySqlCommand(sliderSil, con))
                {
                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }


        }
        public string KategoriToplam()
        {
            var toplam = "";
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var talep = " SELECT COUNT(*) as toplam FROM kategori ";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(talep, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        toplam = reader["toplam"].ToString();
                    }
                }
                con.Close();
            }

            return toplam;


        }

        public void MenuKaydet(menu model)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                con.Open();

                var kategoriKaydet = "INSERT IGNORE INTO menu (kategori_id,ad,aciklama,resim,fiyat) " +
                    "VALUES ('" + model.kategori_id + "','" + model.ad + "', '" + model.aciklama + "','" + model.resim + "','" + model.fiyat + "' )";


                using (MySqlCommand cmd = new MySqlCommand(kategoriKaydet, con))
                {
                    cmd.ExecuteNonQuery();

                }

                con.Close();
            }


        }
        public List<menukategori> Menuler()
        {
            var menuler = new List<menukategori>();

            using (MySqlConnection connection = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var kategoriGelen = "select menu.id,kategori.ad as kategoriadi,menu.ad,aciklama,menu.resim , fiyat " +
                    " from kategori inner join menu on kategori.id = menu.kategori_id ";

                connection.Open();
                using (MySqlCommand command = new MySqlCommand(kategoriGelen, connection))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        menukategori model = new menukategori();
                        model.id = Convert.ToInt32(reader["id"]);
                        model.ad = reader["ad"].ToString();
                        model.kategoriadi = reader["kategoriadi"].ToString();
                        model.aciklama = reader["aciklama"].ToString();
                        model.resim = reader["resim"].ToString();
                        model.fiyat = Convert.ToDouble(reader["fiyat"]);

                        menuler.Add(model);
                    }

                }

                connection.Close();
            }



            return menuler;

        }
        public menu MenuGetir(int id)
        {
            menu modelMenu = new menu();
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var menuSorgu = "SELECT * FROM menu WHERE id = '" + id + "'  ";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(menuSorgu, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        modelMenu.id = Convert.ToInt32(reader["id"]);
                        modelMenu.ad = reader["ad"].ToString();
                        modelMenu.aciklama = reader["aciklama"].ToString();
                        modelMenu.resim = reader["resim"].ToString();
                        modelMenu.fiyat = Convert.ToDouble(reader["fiyat"]);
                    }


                }
                con.Close();
            }

            return modelMenu;

        }
        public void MenukGuncelle(menu model)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var guncelle = " UPDATE menu SET ad='" + model.ad + "',aciklama='" + model.aciklama + "',resim='" + model.resim + "',fiyat='" + model.fiyat + "' WHERE id='" + model.id + "' ";

                using (MySqlCommand cmd = new MySqlCommand(guncelle, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }
        public void MenuSil(int id)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                con.Open();

                var sliderSil = "Delete From menu where id = '" + id + "' ";


                using (MySqlCommand cmd = new MySqlCommand(sliderSil, con))
                {
                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }


        }
        public string MenuToplam()
        {
            var toplam = "";
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var talep = " SELECT COUNT(*) as toplam FROM menu ";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(talep, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        toplam = reader["toplam"].ToString();


                    }


                }
                con.Close();
            }

            return toplam;


        }
        public List<menu> KatMenuGetir(int id)
        {

            List<menu> listeMenu = new List<menu>();
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var menuSorgu = "SELECT * FROM menu WHERE kategori_id = '" + id + "'  ";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(menuSorgu, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        menu modelMenu = new menu();
                        modelMenu.id = Convert.ToInt32(reader["id"]);
                        modelMenu.ad = reader["ad"].ToString();
                        modelMenu.aciklama = reader["aciklama"].ToString();
                        modelMenu.resim = reader["resim"].ToString();
                        modelMenu.fiyat = Convert.ToDouble(reader["fiyat"]);
                        listeMenu.Add(modelMenu);
                    }


                }
                con.Close();
            }

            return listeMenu;

        }

        //ayarlar
        public ayar AyarGetir()
        {

            ayar model = new ayar();

            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {

                var ayarSorgu = "SELECT * FROM ayar";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(ayarSorgu, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.id = Convert.ToInt32(reader["id"]);
                        model.yazi = reader["yazi"].ToString();
                        model.wifi = reader["wifi"].ToString();
                        model.kadi = reader["kadi"].ToString();
                        model.sifre = reader["sifre"].ToString();
                    }

                }
                con.Close();
            }

            return model;

        }

        public void AyarGuncelle(ayar model)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var guncelle = " UPDATE ayar SET yazi='" + model.yazi + "',wifi='" + model.wifi + "' ,kadi='" + model.kadi + "', " +
                    " sifre='" + model.sifre + "' ";

                using (MySqlCommand cmd = new MySqlCommand(guncelle, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
        }
        public CurrentSession YoneticiKontrol(CurrentSession parametre)
        {
            CurrentSession model = new CurrentSession();

            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var yoneticiSorgu = "SELECT * FROM ayar WHERE kadi = '" + parametre.kadi + "' and sifre = '" + parametre.sifre + "'  ";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(yoneticiSorgu, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.id = Convert.ToInt32(reader["id"]);
                        model.kadi = reader["kadi"].ToString();
                        model.sifre = reader["sifre"].ToString();

                    }
                }
                con.Close();
            }
            return model;
        }

        public void YorumKaydet(yorum model)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                con.Open();

                var kategoriKaydet = "INSERT IGNORE INTO yorum (id,mesaj) " +
                    "VALUES ('" + model.id + "','" + model.mesaj + "' )";


                using (MySqlCommand cmd = new MySqlCommand(kategoriKaydet, con))
                {
                    cmd.ExecuteNonQuery();

                }

                con.Close();
            }


        }
        public List<yorum> Yorumlar()
        {
            var yorum = new List<yorum>();

            using (MySqlConnection connection = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                var kategoriGelen = "SELECT * FROM yorum";

                connection.Open();
                using (MySqlCommand command = new MySqlCommand(kategoriGelen, connection))
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        yorum model = new yorum();
                        model.id = Convert.ToInt32(reader["id"]);
                        model.mesaj = reader["mesaj"].ToString();
                        

                        yorum.Add(model);
                    }

                }

                connection.Close();
            }



            return yorum;

        }

        public void YorumSil(int id)
        {
            using (MySqlConnection con = new MySqlConnection(Baglanti.BaglantiCumlesi))
            {
                con.Open();

                var yorumSil = "Delete From yorum where id = '" + id + "' ";


                using (MySqlCommand cmd = new MySqlCommand(yorumSil, con))
                {
                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }

        }
    }


}