using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menu.Models
{
    public class menu
    {
        public int id { get; set; }

        public int kategori_id { get; set; }
    
        public string ad { get; set; }
      
        public string aciklama { get; set; }
        public string resim { get; set; }

        public double fiyat { get; set; }
    }
}