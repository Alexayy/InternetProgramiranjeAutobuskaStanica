namespace AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije
{
    public class Linija
    {
        public int ID { get; set; }
        public string PolaznaStanica { get; set; }
        public string DolaznaStanica { get; set; }
        public DateTime VremePolaska { get; set; }
    }
}
