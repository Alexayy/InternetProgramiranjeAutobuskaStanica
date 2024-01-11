using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije
{
    public class Rezervacija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int LinijaID { get; set; }
        public int SedisteID { get; set; }
        public string KorisnikID { get; set; }
    }
}
