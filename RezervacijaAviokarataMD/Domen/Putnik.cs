namespace Domen
{
    public class Putnik
    {
        public long idPutnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kategorija { get; set; }
        public string BrojPasosa { get; set; }
        public Sediste Sediste { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime}"; 
        }

    }
}
