using System.ComponentModel.DataAnnotations;

namespace Mvc_Projem.Models
{
    public class Birim
    {
        [Key]
        public int Id { get; set; }
        public string BirimAd { get; set; }
        public IList<Personel> Personels { get; set; } // bir birimin birden fazla personeli olabilir.
    }
}
