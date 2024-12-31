using System.ComponentModel.DataAnnotations;

namespace Mvc_Projem.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; } // PK
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sehir { get; set; }


        public int BirimId { get; set; } // FK
        public Birim Birim { get; set; } // bir personelin bir birimi olur.

    }
}
