using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije
{
    public class Korisnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Uloga { get; set; }
        public string SlikaKorisnika { get; set; }
    }
}
