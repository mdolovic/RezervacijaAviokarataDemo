using BrokerBazePodataka;
using Domen;

namespace PoslovnaLogika
{
    public class Kontroler
    {
        private static Kontroler instance;
        private Broker broker = new Broker();

        private Kontroler() { }

        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                    instance = new Kontroler();
                return instance;
            }
        }

        //SK8: Prijavi aviokompaniju

        public Aviokompanija PrijaviAviokompanija(string korisnickoIme, string sifra)
        {
            broker.Connect();
            try
            {
                return broker.PrijaviAviokompanija(korisnickoIme, sifra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                broker.Disconnect();
            }
        }
    }
}
