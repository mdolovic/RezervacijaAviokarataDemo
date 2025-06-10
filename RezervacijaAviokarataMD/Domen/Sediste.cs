namespace Domen
{
    public class Sediste
    {
        public long idSediste { get; set; }
        public string Kategorija { get; set; }

        public override string ToString()
        {
            return $"{idSediste} {Kategorija}";
        }
    }

}
