using BrokerBazePodataka;
using Domen;
using Microsoft.Data.SqlClient;

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

        //SK1: Kreiraj rezervaciju
        public List<Aviokompanija> vratiListuSviAviokompanija()
        {
            broker.Connect();
            try
            {
                return broker.vratiListuSviAviokompanija();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                broker.Disconnect();
            }
        }
        public List<Putnik> vratiListuSviPutnik(Putnik p)
        {
            broker.Connect();
            try
            {
                return broker.vratiListuSviPutnik(p);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                broker.Disconnect();
            }
        }
        public List<Let> vratiListuSviLet()
        {
            broker.Connect();
            try
            {
                return broker.vratiListuSviLet();
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }
        public long KreirajRezervacija(Rezervacija r)
        {
            broker.Connect();
            try
            {
                return broker.KreirajRezervacija(r);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }
        public List<StavkaRezervacije> vratiListuStavkeRezervacije(Rezervacija r)
        {
            broker.Connect();
            try
            {
                return broker.vratiListuStavkeRezervacije(r);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }

        //SK2: Pretraga rezervacije
        public List<Rezervacija> vratiListuRezervacija(Rezervacija r)
        {
            broker.Connect();
            try
            {
                return broker.vratiListuRezervacija(r);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }
        public void promeniRezervacija(Rezervacija r)
        {
            broker.Connect();
            try
            {
                broker.promeniRezervacija(r);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }

        //SK21: Dodaj destinaciju
        public bool dodajDestinaciju(Destinacija d)
        {
            broker.Connect();
            try
            {
                return broker.dodajDestinaciju(d);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }

        //SK4: Dodaj putnika
        public List<Sediste> vratiListuSviSedista()
        {
            broker.Connect();
            try
            {
                return broker.vratiListuSviSedista();
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }
        public bool dodajPutnik(Putnik putnik)
        {
            broker.Connect();
            try
            {
                return broker.dodajPutnik(putnik);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }

        //SK5: Pretrazi putnika
        public List<Putnik> vratiPutnikePoKriterijumu(Putnik kriterijum)
        {
            broker.Connect();
            try
            {
                return broker.vratiPutnikePoKriterijumu(kriterijum);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }

        }

        //SK7: Obrisi putnika
        public bool obrisiPutnika(Putnik p)
        {
            broker.Connect();
            try
            {
                return broker.obrisiPutnika(p);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }

        //SK6: Promeni putnika
        public bool izmeniPutnika(Putnik putnik)
        {
            broker.Connect();
            try
            {
                return broker.izmeniPutnika(putnik);
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.Disconnect(); }
        }
    }
}
