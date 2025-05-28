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
    public partial class Frm_KreirajRezervacija : Form
    {
        private Aviokompanija aviokompanija = new Aviokompanija();
        private Putnik putnik = new Putnik();
        private BindingList<StavkaRezervacije> stavkeRezervacije = new BindingList<StavkaRezervacije>();
        private Rezervacija rezervacija = new Rezervacija();
        private StavkaRezervacije stavka = new StavkaRezervacije();
        private List<StavkaRezervacije> postojece = new List<StavkaRezervacije>();
        public Frm_KreirajRezervacija(Aviokompanija a, Rezervacija? rez)
        {
            InitializeComponent();

            Putnik p = new Putnik();
            List<Putnik> putnici = Kontroler.Instance.vratiListuSviPutnik(p);
            cbPutnik.DataSource = putnici;
            cbPutnik.SelectedIndex = -1;

            btnDodajStavku.Enabled = false;
            btnKreirajRezervaciju.Enabled = false;
            cbLet.Enabled = false;

            List<Let> letovi = Kontroler.Instance.vratiListuSviLet();
            cbLet.DataSource = letovi;
            cbLet.SelectedIndex = -1;

            if (a != null)
            {
                aviokompanija = a;
            }

            if (rez != null)
            {
                rezervacija = rez;
                btnKreirajRezervaciju.Text = "Izmeni";

                txtOpis.Text = rezervacija.Opis.ToString();
                String s = rezervacija.Putnik.Ime + " " + rezervacija.Putnik.Prezime;
                cbPutnik.Text = s;
                cbPutnik.Enabled = true;
                txtUkupnaCena.Text = rezervacija.Cena.ToString();

                rezervacija.Stavke = Kontroler.Instance.vratiListuStavkeRezervacije(rezervacija);
                stavkeRezervacije = new BindingList<StavkaRezervacije>(rezervacija.Stavke);
            } 

            dgvStavkaRezervacije.DataSource = stavkeRezervacije;
            dgvStavkaRezervacije.Columns[0].Visible = false;
            dgvStavkaRezervacije.Columns[1].Visible = false;
        }

        public bool validacija()
        {
            if (string.IsNullOrEmpty(txtOpis.Text) || string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                txtOpis.BackColor = Color.LightCoral;
                return false;
            }
            else
            {
                txtOpis.BackColor = SystemColors.Window;
                return true;
            }
        }
        public bool validacijaStavkeRezervacije()
        {
            DateTime datumOdlaska = dtpDatumOdlaska.Value;
            DateTime datumDolaska = dtpDatumDolaska.Value;

            bool validno = true;

            if (cbLet.SelectedIndex == -1)
            {
                cbLet.BackColor = Color.LightCoral;
                validno = false;
            }
            else cbLet.BackColor = SystemColors.Window;

            if (string.IsNullOrWhiteSpace(txtNazivStavke.Text))
            {
                txtNazivStavke.BackColor = Color.LightCoral;
                validno = false;
            }
            else txtNazivStavke.BackColor = SystemColors.Window;

            if (datumOdlaska >= datumDolaska) 
            {
                dtpDatumOdlaska.CalendarTitleBackColor = Color.LightCoral;
                dtpDatumDolaska.CalendarTitleBackColor = Color.LightCoral;
                validno = false;
            }
            else
            {
                dtpDatumOdlaska.CalendarTitleBackColor = SystemColors.Window;
                dtpDatumDolaska.CalendarTitleBackColor = SystemColors.Window;
            }

            if (numCenaStavke.Value <= 0)
            {
                numCenaStavke.BackColor = Color.LightCoral;
                validno = false;
            }
            else numCenaStavke.BackColor = SystemColors.Window;

            return validno;
        }


        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            if (validacijaStavkeRezervacije())
            {
                StavkaRezervacije stavka = new StavkaRezervacije
                {
                    Let = cbLet.SelectedItem as Let,
                    NazivStavke = txtNazivStavke.Text.Trim(),
                    datumOdlaska = dtpDatumOdlaska.Value,
                    datumDolaska = dtpDatumDolaska.Value,
                    cenaStavke = (long)numCenaStavke.Value,
                    Rezervacija = rezervacija
                };

                stavkeRezervacije.Add(stavka);

                txtUkupnaCena.Text = (Convert.ToInt32(txtUkupnaCena.Text) + stavka.cenaStavke).ToString();

                dgvStavkaRezervacije.DataSource = null;
                dgvStavkaRezervacije.DataSource = stavkeRezervacije;

                cbLet.SelectedIndex = -1;
                txtNazivStavke.Text = "";
                numCenaStavke.Value = 0;
            }
        }

        private void btnKreirajRezervaciju_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klik radi");
            if (validacija())
            {
                Rezervacija r = new Rezervacija();
                r.Opis = txtOpis.Text;
                r.Cena = Convert.ToInt32(txtUkupnaCena.Text);
                r.Putnik = putnik;
                r.Aviokompanija = aviokompanija;
                r.Stavke = new List<StavkaRezervacije>(stavkeRezervacije);
                try
                {
                    Kontroler.Instance.KreirajRezervacija(r);
                    MessageBox.Show("Sistem je uspesno kreirao rezervaciju.");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void cbPutnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbPutnik.SelectedIndex != -1)
            {
                cbLet.Enabled = true;

                btnDodajStavku.Enabled = true;
                btnKreirajRezervaciju.Enabled = true;

                putnik = cbPutnik.SelectedItem as Putnik;
                txtUkupnaCena.Text = "0";

                foreach(StavkaRezervacije sr in stavkeRezervacije)
                {
                    txtUkupnaCena.Text = (Convert.ToInt32(txtUkupnaCena.Text) + sr.cenaStavke).ToString();
                }

                dgvStavkaRezervacije.DataSource = stavkeRezervacije;
                dgvStavkaRezervacije.Columns[0].Visible = false;
                dgvStavkaRezervacije.Columns[1].Visible = false;

            }
        }
    }
}
