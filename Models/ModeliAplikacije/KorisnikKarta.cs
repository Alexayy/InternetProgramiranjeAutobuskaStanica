﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije
{
    public class KorisnikKarta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string KorisnikID { get; set; }
        public int KartaID { get; set; }
    }
}
