namespace Domen
{
    public class StavkaRezervacije
    {
        public Rezervacija Rezervacija { get; set; }
        public int rb { get; set; }
        public string NazivStavke { get; set; }
        public Let Let { get; set; }
        public DateTime datumOdlaska { get; set; }
        public DateTime datumDolaska { get; set; }
        public long cenaStavke { get; set; }
    }
}
