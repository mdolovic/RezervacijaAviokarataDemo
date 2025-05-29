using Domen;
using System;
using Microsoft.Data.SqlClient;

namespace BrokerBazePodataka
{
    public class Broker
    {
        private SqlConnection conn;
        private SqlTransaction transaction;

        public void Connect()
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RezervacijaAvioKarata;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            conn.Open();
        }

        public void Disconnect()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public void BeginTransaction()
        {
            transaction = conn.BeginTransaction();
        }

        public void CommitTransaction()
        {
            transaction?.Commit();
            transaction = null;
        }

        public void RollbackTransaction()
        {
            transaction?.Rollback();
            transaction = null;
        }

        public SqlCommand CreateCommand(string query)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            if (transaction != null)
                cmd.Transaction = transaction;
            return cmd;
        }

        //SK8: Prijavi aviokompaniju
        public Aviokompanija PrijaviAviokompanija(string korisnickoIme, string sifra)
        {
            try
            {
                string upit = "SELECT * FROM Aviokompanija WHERE korisnickoIme = @user AND sifra = @pass";
                using SqlCommand cmd = new SqlCommand(upit, conn);
                cmd.Parameters.AddWithValue("@user", korisnickoIme);
                cmd.Parameters.AddWithValue("@pass", sifra);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Aviokompanija a = new Aviokompanija()
                    {
                        idAviokompanija = (long)reader["idAviokompanija"],
                        Naziv = reader["Naziv"].ToString(),
                        Email = reader["Email"].ToString(),
                        korisnickoIme = reader["korisnickoIme"].ToString(),
                        sifra = reader["sifra"].ToString()
                    };

                    return a;
                }

                else
                {
                    throw new Exception("Korisnicko ime i sifra nisu ispravni.");
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri radu sa bazom!");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //SK1: Kreiraj rezervaciju
        public List<Aviokompanija> vratiListuSviAviokompanija()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM [Aviokompanija]";
                List<Aviokompanija> aviokompanije = new List<Aviokompanija>();
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Aviokompanija a = new Aviokompanija
                    {
                        idAviokompanija = (long)reader["idAviokompanija"],
                        Naziv = reader["Naziv"].ToString(),
                        Email = reader["Email"].ToString(),
                        korisnickoIme = reader["korisnickoIme"].ToString(),
                        sifra = reader["sifra"].ToString()
                    };

                    aviokompanije.Add(a);
                }

                if (aviokompanije.Count > 0) return aviokompanije;
                else throw new Exception("Sistem ne moze da pronadje aviokompanije.");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Putnik> vratiListuSviPutnik(Putnik p)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT * FROM Putnik pu JOIN Sediste s ON (pu.idSediste = s.idSediste) WHERE (@ime IS NULL OR pu.Ime = @ime) AND (@prezime IS NULL OR pu.Prezime = @prezime) AND (@brojPasosa IS NULL OR pu.BrojPasosa = @brojPasosa) AND (@sediste IS NULL OR pu.idSediste = @sediste)";

                cmd.Parameters.AddWithValue("@ime", string.IsNullOrEmpty(p.Ime) ? DBNull.Value : p.Ime);
                cmd.Parameters.AddWithValue("@prezime", string.IsNullOrEmpty(p.Prezime) ? DBNull.Value : p.Prezime);
                cmd.Parameters.AddWithValue("@brojPasosa", string.IsNullOrEmpty(p.BrojPasosa) ? DBNull.Value : p.BrojPasosa);
                cmd.Parameters.AddWithValue("@sediste", p.Sediste == null ? DBNull.Value : p.Sediste.idSediste);

                List<Putnik> putnici = new List<Putnik>();
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Putnik putnik = new Putnik();
                    putnik.idPutnik = reader.GetInt64(0);
                    putnik.Ime = reader.GetString(1);
                    putnik.Prezime = reader.GetString(2);
                    putnik.Kategorija = reader.GetString(3);
                    putnik.BrojPasosa = reader.GetString(4);

                    putnik.Sediste = new Sediste
                    {
                        idSediste = reader.GetInt64(5),
                        Kategorija = reader.GetString(7)
                    };

                    putnici.Add(putnik);
                }

                if (putnici.Count > 0)
                {
                    return putnici;
                }
                else
                {
                    throw new Exception("Sistem ne može da pronađe putnike po zadatim kriterijumima.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Let> vratiListuSviLet()
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM [Let]";
                List<Let> letovi = new List<Let>();
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Let l = new Let()
                    {
                        idLet = reader.GetInt64(0),
                        ModelAviona = reader.GetString(1)
                    };
                    letovi.Add(l);
                }
                if (letovi.Count > 0) return letovi;
                else throw new Exception("Sistem ne moze da pronadje letove.");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public long KreirajRezervacija(Rezervacija r)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Rezervacija (Opis, idAviokompanija, Cena, idPutnik)
                            OUTPUT inserted.idRezervacija
                            VALUES (@opis, @aviokompanija, @cena, @putnik)";

                cmd.Parameters.AddWithValue("@opis", r.Opis);
                cmd.Parameters.AddWithValue("@aviokompanija", r.Aviokompanija.idAviokompanija);
                cmd.Parameters.AddWithValue("@cena", r.Cena);
                cmd.Parameters.AddWithValue("@putnik", r.Putnik.idPutnik);

                if (transaction != null)
                    cmd.Transaction = transaction;

                long rezervacijaId = (long)cmd.ExecuteScalar();

                
                foreach (StavkaRezervacije stavka in r.Stavke)
                {
                    SqlCommand cmdStavka = conn.CreateCommand();
                    cmdStavka.CommandText = @"INSERT INTO StavkaRezervacije 
                (idRezervacija, NazivStavke, idLet, datumOdlaska, datumDolaska, cenaStavke)
                VALUES (@rezID, @naziv, @letID, @odlazak, @dolazak, @cena)";

                    cmdStavka.Parameters.AddWithValue("@rezID", rezervacijaId);
                    cmdStavka.Parameters.AddWithValue("@naziv", stavka.NazivStavke);
                    cmdStavka.Parameters.AddWithValue("@letID", stavka.Let.idLet);
                    cmdStavka.Parameters.AddWithValue("@odlazak", stavka.datumOdlaska);
                    cmdStavka.Parameters.AddWithValue("@dolazak", stavka.datumDolaska);
                    cmdStavka.Parameters.AddWithValue("@cena", stavka.cenaStavke);

                    if (transaction != null)
                        cmdStavka.Transaction = transaction;

                    cmdStavka.ExecuteNonQuery();
                }

                return rezervacijaId;
            }
            catch (Exception)
            {
                throw new Exception("Sistem ne može da zapamti rezervaciju i njene stavke.");
            }
        }
        public List<StavkaRezervacije> vratiListuStavkeRezervacije(Rezervacija r)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                List<StavkaRezervacije> stavke = new List<StavkaRezervacije>();

                cmd.CommandText = @"SELECT * 
                            FROM StavkaRezervacije sr 
                            JOIN Let l ON sr.idLet = l.idLet 
                            WHERE sr.idRezervacija = @idRezervacija";
                cmd.Parameters.AddWithValue("@idRezervacija", r.idRezervacija);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StavkaRezervacije s = new StavkaRezervacije();
                    s.Rezervacija = r;
                    s.rb = reader.GetInt32(1); 
                    s.NazivStavke = reader.GetString(2);
                    s.Let = new Let
                    {
                        idLet = reader.GetInt64(3),
                        ModelAviona = reader.GetString(7)
                    };
                    s.datumOdlaska = reader.GetDateTime(4);
                    s.datumDolaska = reader.GetDateTime(5);
                    s.cenaStavke = reader.GetInt64(6);

                    stavke.Add(s);
                }

                if (stavke.Count > 0)
                {
                    return stavke;
                }
                else
                {
                    throw new Exception("Sistem ne može da pronađe stavke rezervacije po zadatim kriterijumima.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //SK2: Pretrazi rezervaciju

        public List<Rezervacija> vratiListuRezervacija(Rezervacija r)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                            SELECT DISTINCT rez.idRezervacija, rez.Opis, rez.Cena, rez.idAviokompanija, rez.idPutnik,
                                            p.Ime, p.Prezime, a.Naziv,
                                            srb.idLet, srb.rb
                            FROM Rezervacija rez
                            JOIN Aviokompanija a ON rez.idAviokompanija = a.idAviokompanija
                            JOIN Putnik p ON rez.idPutnik = p.idPutnik
                            JOIN StavkaRezervacije srb ON srb.idRezervacija = rez.idRezervacija
                            WHERE (@idPutnik IS NULL OR p.idPutnik = @idPutnik)
                              AND (@idAvio IS NULL OR a.idAviokompanija = @idAvio)
                              AND (@idLet IS NULL OR srb.idLet = @idLet)";

                cmd.Parameters.AddWithValue("@idPutnik", r.Putnik == null ? DBNull.Value : r.Putnik.idPutnik);
                cmd.Parameters.AddWithValue("@idAvio", r.Aviokompanija == null ? DBNull.Value : r.Aviokompanija.idAviokompanija);
                cmd.Parameters.AddWithValue("@idLet", r.Stavke != null && r.Stavke.Count > 0 ? r.Stavke[0].Let.idLet : DBNull.Value);

                List<Rezervacija> rezervacije = new List<Rezervacija>();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Rezervacija rez = new Rezervacija
                    {
                        idRezervacija = reader.GetInt64(0),
                        Opis = reader.GetString(1),
                        Cena = reader.GetInt64(2),
                        Aviokompanija = new Aviokompanija
                        {
                            idAviokompanija = reader.GetInt64(3),
                            Naziv = reader.GetString(7)
                        },
                        Putnik = new Putnik
                        {
                            idPutnik = reader.GetInt64(4),
                            Ime = reader.GetString(5),
                            Prezime = reader.GetString(6)
                        },
                        Stavke = new List<StavkaRezervacije>
                        {
                            new StavkaRezervacije
                            {
                                Let = new Let
                                {
                                    idLet = reader.GetInt64(8)
                                },
                                rb =  reader.GetInt64(9)
                            }
                        }
                    };

                    rezervacije.Add(rez);
                }

                if (rezervacije.Count == 0)
                {
                    throw new Exception("Sistem ne može da pronađe rezervacije po zadatim kriterijumima.");
                }

                return rezervacije;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
