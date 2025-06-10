using Domen;
using System;
using Microsoft.Data.SqlClient;
using System.Text;

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
                                            srb.idLet, srb.rb, l.ModelAviona
                            FROM Rezervacija rez
                            JOIN Aviokompanija a ON rez.idAviokompanija = a.idAviokompanija
                            JOIN Putnik p ON rez.idPutnik = p.idPutnik
                            JOIN StavkaRezervacije srb ON srb.idRezervacija = rez.idRezervacija
                            JOIN Let l ON l.idLet = srb.idLet
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
                                    idLet = reader.GetInt64(8),
                                    ModelAviona = reader.GetString(10)
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

        //SK3: Promeni rezervaciju
        public void promeniRezervacija(Rezervacija r)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE Rezervacija 
                            SET Opis = @opis, 
                                Cena = @cena, 
                                idPutnik = @idPutnik,
                                idAviokompanija = @idAviokompanija
                            WHERE idRezervacija = @id";
                cmd.Parameters.AddWithValue("@opis", r.Opis);
                cmd.Parameters.AddWithValue("@cena", r.Cena);
                cmd.Parameters.AddWithValue("@idPutnik", r.Putnik.idPutnik);
                cmd.Parameters.AddWithValue("@idAviokompanija", r.Aviokompanija.idAviokompanija);
                cmd.Parameters.AddWithValue("@id", r.idRezervacija);
                if (transaction != null) cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                
                if (r.Stavke != null)
                {
                    foreach (var s in r.Stavke)
                    {
                        SqlCommand cmdSt = conn.CreateCommand();
                        cmdSt.CommandText = @"UPDATE StavkaRezervacije 
                                      SET idLet = @idLet 
                                      WHERE idRezervacija = @idRez AND rb = @rb";
                        cmdSt.Parameters.AddWithValue("@idLet", s.Let.idLet);
                        cmdSt.Parameters.AddWithValue("@idRez", r.idRezervacija);
                        cmdSt.Parameters.AddWithValue("@rb", s.rb);
                        if (transaction != null) cmdSt.Transaction = transaction;
                        cmdSt.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //SK21: Dodaj destinaciju
        public bool dodajDestinaciju(Destinacija d)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Destinacija (Naziv) VALUES (@naziv)";
                cmd.Parameters.AddWithValue("@naziv", d.Naziv);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception)
            {
                throw new Exception("Sistem ne može da doda destinaciju.");
            }
        }

        //SK4: Kreiraj putnika
        public List<Sediste> vratiListuSviSedista()
        {
            List<Sediste> lista = new List<Sediste>();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Sediste", conn);
            SqlDataReader reader = komanda.ExecuteReader();

            while (reader.Read())
            {
                Sediste s = new Sediste
                {
                    idSediste = (long)reader["idSediste"],
                    Kategorija = reader["Kategorija"].ToString()
                };
                lista.Add(s);
            }

            reader.Close();
            return lista;
        }
        public bool dodajPutnik(Putnik p)
        {
            SqlCommand komanda = new SqlCommand(@"INSERT INTO Putnik (Ime, Prezime, Kategorija, BrojPasosa, idSediste) 
                                          VALUES (@Ime, @Prezime, @Kategorija, @BrojPasosa, @idSediste)", conn);

            komanda.Parameters.AddWithValue("@Ime", p.Ime);
            komanda.Parameters.AddWithValue("@Prezime", p.Prezime);
            komanda.Parameters.AddWithValue("@Kategorija", p.Kategorija);
            komanda.Parameters.AddWithValue("@BrojPasosa", p.BrojPasosa);
            komanda.Parameters.AddWithValue("@idSediste", p.Sediste.idSediste);

            return komanda.ExecuteNonQuery() > 0;
        }

        //SK5: Pretrazi putnika
        public List<Putnik> vratiPutnikePoKriterijumu(Putnik kriterijum)
        {
            List<Putnik> rezultat = new List<Putnik>();

            StringBuilder upit = new StringBuilder(@"
                SELECT p.idPutnik, p.Ime, p.Prezime, p.Kategorija, p.BrojPasosa, p.idSediste,
                       s.Kategorija AS KategorijaSedista
                FROM Putnik p
                JOIN Sediste s ON p.idSediste = s.idSediste
                WHERE 1 = 1 ");

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = conn;

            if (!string.IsNullOrWhiteSpace(kriterijum.Ime))
            {
                upit.Append("AND p.Ime LIKE @Ime ");
                komanda.Parameters.AddWithValue("@Ime", "%" + kriterijum.Ime + "%");
            }
            if (!string.IsNullOrWhiteSpace(kriterijum.Prezime))
            {
                upit.Append("AND p.Prezime LIKE @Prezime ");
                komanda.Parameters.AddWithValue("@Prezime", "%" + kriterijum.Prezime + "%");
            }
            if (!string.IsNullOrWhiteSpace(kriterijum.Kategorija))
            {
                upit.Append("AND p.Kategorija LIKE @Kategorija ");
                komanda.Parameters.AddWithValue("@Kategorija", "%" + kriterijum.Kategorija + "%");
            }
            if (!string.IsNullOrWhiteSpace(kriterijum.BrojPasosa))
            {
                upit.Append("AND p.BrojPasosa LIKE @BrojPasosa ");
                komanda.Parameters.AddWithValue("@BrojPasosa", "%" + kriterijum.BrojPasosa + "%");
            }
            if (kriterijum.Sediste != null && kriterijum.Sediste.idSediste > 0)
            {
                upit.Append("AND p.idSediste = @idSediste ");
                komanda.Parameters.AddWithValue("@idSediste", kriterijum.Sediste.idSediste);
            }

            komanda.CommandText = upit.ToString();

            using (SqlDataReader reader = komanda.ExecuteReader())
            {
                while (reader.Read())
                {
                    Sediste s = new Sediste
                    {
                        idSediste = (long)reader["idSediste"],
                        Kategorija = reader["KategorijaSedista"].ToString()
                    };

                    Putnik p = new Putnik
                    {
                        idPutnik = (long)reader["idPutnik"],
                        Ime = reader["Ime"].ToString(),
                        Prezime = reader["Prezime"].ToString(),
                        Kategorija = reader["Kategorija"].ToString(),
                        BrojPasosa = reader["BrojPasosa"].ToString(),
                        Sediste = s
                    };

                    rezultat.Add(p);
                }
            }

            return rezultat;
        }

        //SK7: Obrisi putnika
        public bool obrisiPutnika(Putnik p)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Putnik WHERE idPutnik = @id";
            cmd.Parameters.AddWithValue("@id", p.idPutnik);

            return cmd.ExecuteNonQuery() > 0;
        }


    }
}
