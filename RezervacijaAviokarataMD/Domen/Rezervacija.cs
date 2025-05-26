namespace Domen
{
    public class Rezervacija
    {
        public long idRezervacija { get; set; }
        public string Opis { get; set; }
        public long Cena { get; set; }
        public Aviokompanija Aviokompanija { get; set; }
        public Putnik Putnik { get; set; }
    }
}
