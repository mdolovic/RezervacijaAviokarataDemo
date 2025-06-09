namespace Domen
{
    public class Aviokompanija
    {
        public long idAviokompanija { get; set; }
        public string Naziv { get; set; }
        public string Email { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }
        public string PrikazAviokompanije
        {
            get { return Naziv; }
        }

        public override string ToString()
        {
            return PrikazAviokompanije;
        }

    }
}
