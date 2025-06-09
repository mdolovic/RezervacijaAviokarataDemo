namespace Domen
{
    public class Let
    {
        public long idLet { get; set; }
        public string ModelAviona { get; set; }
        public string PrikazLeta => $"{ModelAviona} ({idLet})";

        public override string ToString()
        {
            return PrikazLeta;
        }

    }
}
