using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menu.Models
{
    public class kategori
    {
        public int id { get; set; }

        [Display(Name = "ad"), Required(ErrorMessage = "Kategori boş geçilemez")]
        public string ad { get; set; }
        public string resim { get; set; }
    }
}