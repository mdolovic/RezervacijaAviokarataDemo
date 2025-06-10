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
    public partial class Frm_PromeniPutnik : Form
    {
        private Putnik stariPutnik;
        private List<Sediste> sedista;
        public Frm_PromeniPutnik(Putnik selektovaniPutnik)
        {
            InitializeComponent();
            stariPutnik = selektovaniPutnik;

            sedista = Kontroler.Instance.vratiListuSviSedista();
            cbSediste.DataSource = sedista;
            cbSediste.DisplayMember = "Kategorija";
            cbSediste.ValueMember = "idSediste";

            txtIme.Text = selektovaniPutnik.Ime;
            txtPrezime.Text = selektovaniPutnik.Prezime;
            txtKategorija.Text = selektovaniPutnik.Kategorija;
            txtBrojPasosa.Text = selektovaniPutnik.BrojPasosa;

            if (selektovaniPutnik.Sediste != null)
                cbSediste.SelectedValue = selektovaniPutnik.Sediste.idSediste;

        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa()) return;

            Putnik izmenjenPutnik = new Putnik
            {
                idPutnik = stariPutnik.idPutnik, 
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                Kategorija = txtKategorija.Text.Trim(),
                BrojPasosa = txtBrojPasosa.Text.Trim(),
                Sediste = cbSediste.SelectedItem as Sediste
            };

            bool uspesno = Kontroler.Instance.izmeniPutnika(izmenjenPutnik);
            if (uspesno)
            {
                MessageBox.Show("Putnik uspešno izmenjen.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Došlo je do greške prilikom izmene putnika.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidacijaUnosa()
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text) ||
                string.IsNullOrWhiteSpace(txtPrezime.Text) ||
                string.IsNullOrWhiteSpace(txtKategorija.Text) ||
                string.IsNullOrWhiteSpace(txtBrojPasosa.Text) ||
                cbSediste.SelectedItem == null)
            {
                MessageBox.Show("Sva polja moraju biti popunjena!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string brojPasosa = txtBrojPasosa.Text.Trim();
            if (brojPasosa.Length != 10 || !brojPasosa.All(char.IsDigit))
            {
                MessageBox.Show("Broj pasoša mora imati tačno 10 cifara i sme sadržati samo brojeve.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
