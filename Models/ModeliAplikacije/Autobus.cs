using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije
{
    public class Autobus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int BrojSedista { get; set; }
        public string SedisteKompanije { get; set; }
        public string BrojTelefonaKompanije { get; set; }
        public string EmailKompanije { get; set; }
        public string SajtKompanije { get; set; }
        public string SlikaAutobusa {  get; set; }
    }
}
