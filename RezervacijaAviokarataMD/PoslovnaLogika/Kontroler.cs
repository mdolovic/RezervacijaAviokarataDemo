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


    }
}
