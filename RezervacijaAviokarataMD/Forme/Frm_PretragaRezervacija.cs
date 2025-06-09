using Domen;
using PoslovnaLogika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class Frm_PretragaRezervacija : Form
    {
        private List<Aviokompanija> listaAviokompanija;
        private List<Let> listaLetova;
        private List<Putnik> listaPutnika;
        public Frm_PretragaRezervacija()
        {
            InitializeComponent();

            btnIzmeni.Enabled = false;
            // btnPretraga.Enabled = false;
            listaAviokompanija = Kontroler.Instance.vratiListuSviAviokompanija();
            listaLetova = Kontroler.Instance.vratiListuSviLet();
            listaPutnika = Kontroler.Instance.vratiListuSviPutnik(new Putnik());

            cbAviokompanija.DataSource = Kontroler.Instance.vratiListuSviAviokompanija();
            cbAviokompanija.SelectedIndex = -1;

            cbLet.DataSource = Kontroler.Instance.vratiListuSviLet();
            cbLet.SelectedIndex = -1;

            Putnik p = new Putnik();
            cbPutnik.DataSource = Kontroler.Instance.vratiListuSviPutnik(p);
            cbPutnik.SelectedIndex = -1;

            //if (cbLet.SelectedIndex != -1 && cbAviokompanija.SelectedIndex != -1 && cbPutnik.SelectedIndex != -1)
            // btnPretraga.Enabled = true;
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            btnIzmeni.Enabled = true;

            try
            {
                Rezervacija r = new Rezervacija();
                if (cbPutnik.SelectedItem != null)
                    r.Putnik = cbPutnik.SelectedItem as Putnik;
                if (cbAviokompanija.SelectedItem != null)
                    r.Aviokompanija = cbAviokompanija.SelectedItem as Aviokompanija;
                if (cbLet.SelectedItem != null)
                {
                    r.Stavke = new List<StavkaRezervacije>
                    {
                        new StavkaRezervacije { Let = cbLet.SelectedItem as Let }
                    };
                }

                List<Rezervacija> lista = Kontroler.Instance.vratiListuRezervacija(r);

                // KLJUČNA LINIJA
                dgvRezervacija.AutoGenerateColumns = false;
                dgvRezervacija.Columns.Clear();
                dgvRezervacija.DataSource = lista;


                // Aviokompanija
                var colAvio = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Aviokompanija",
                    Name = "Aviokompanija",
                    DataSource = listaAviokompanija,
                    DisplayMember = "PrikazAviokompanije",
                    ValueMember = "idAviokompanija",
                    FlatStyle = FlatStyle.Flat
                };
                dgvRezervacija.Columns.Add(colAvio);

                // Putnik
                var colPutnik = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Putnik",
                    Name = "Putnik",
                    DataSource = listaPutnika,
                    DisplayMember = "PrikazPutnika",
                    ValueMember = "idPutnik",
                    FlatStyle = FlatStyle.Flat
                };
                dgvRezervacija.Columns.Add(colPutnik);

                // Let
                var colLet = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Let",
                    Name = "Let",
                    DataSource = listaLetova,
                    DisplayMember = "PrikazLeta",
                    ValueMember = "idLet",
                    FlatStyle = FlatStyle.Flat
                };
                dgvRezervacija.Columns.Add(colLet);

                // rb
                var colrb = new DataGridViewTextBoxColumn
                {
                    HeaderText = "rb",
                    Name = "rb",
                    ReadOnly = true
                };
                dgvRezervacija.Columns.Add(colrb);

                var colOpis = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Opis",
                    Name = "Opis",
                    DataPropertyName = "Opis"
                };
                dgvRezervacija.Columns.Add(colOpis);

                var colCena = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Cena",
                    Name = "Cena",
                    DataPropertyName = "Cena"
                };
                dgvRezervacija.Columns.Add(colCena);

                // Popunjavanje
                foreach (DataGridViewRow row in dgvRezervacija.Rows)
                {
                    if (row.DataBoundItem is Rezervacija rez && rez.Stavke?.Count > 0)
                    {
                        row.Cells["Putnik"].Value = rez.Putnik.idPutnik;
                        row.Cells["Aviokompanija"].Value = rez.Aviokompanija.idAviokompanija;
                        row.Cells["Let"].Value = rez.Stavke[0].Let.idLet;
                        row.Cells["rb"].Value = rez.Stavke[0].rb;
                        row.Cells["Opis"].Value = rez.Opis;
                        row.Cells["Cena"].Value = rez.Cena.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju rezervacija: " + ex.Message);
            }
        }



        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvRezervacija.Rows)
                {
                    if (row.DataBoundItem is Rezervacija rez)
                    {
                        string opis = row.Cells["Opis"].Value?.ToString();
                        string cenaStr = row.Cells["Cena"].Value?.ToString();
                        string rbStr = row.Cells["rb"].Value?.ToString();

                        if (!long.TryParse(cenaStr, out long cena)) throw new Exception("Cena nije validna.");
                        if (!long.TryParse(rbStr, out long rb)) throw new Exception("rb nije validan.");

                        long idPutnik = (long)row.Cells["Putnik"].Value;
                        Putnik noviPutnik = listaPutnika.FirstOrDefault(p => p.idPutnik == idPutnik);
                        long idAviokompanija = (long)row.Cells["Aviokompanija"].Value;
                        Aviokompanija novaAvio = listaAviokompanija.FirstOrDefault(a => a.idAviokompanija == idAviokompanija);
                        long idLet = (long)row.Cells["Let"].Value;
                        Let noviLet = listaLetova.FirstOrDefault(l => l.idLet == idLet);

                        if (noviPutnik == null || novaAvio == null || noviLet == null)
                            throw new Exception("Neispravan izbor entiteta.");

                        rez.Opis = opis;
                        rez.Cena = cena;
                        rez.Putnik = noviPutnik;
                        rez.Aviokompanija = novaAvio;

                        if (rez.Stavke != null && rez.Stavke.Count > 0)
                        {
                            var stavka = rez.Stavke.FirstOrDefault(s => s.rb == rb);
                            if (stavka != null)
                                stavka.Let = noviLet;
                        }

                        Kontroler.Instance.promeniRezervacija(rez);
                    }
                }

                MessageBox.Show("Rezervacije su uspešno izmenjene.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }


    }
}
