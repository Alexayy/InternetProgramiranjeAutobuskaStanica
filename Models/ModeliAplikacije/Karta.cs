using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije
{
    public class Karta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int RezervacijaID { get; set; }
        public DateTime DatumKupovine { get; set; }
        public List<KorisnikKarta> KarteKorisnika { get; set; }
    }
}
