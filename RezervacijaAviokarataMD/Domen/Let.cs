namespace Domen
{
    public class Let
    {
        public long idLet { get; set; }
        public string ModelAviona { get; set; }
        public override string ToString()
        {
            return $"{ModelAviona} - {idLet}";
        }

    }
}
