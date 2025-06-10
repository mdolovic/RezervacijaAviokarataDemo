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
    public partial class Frm_KreirajPutnik : Form
    {
        private List<Sediste> sedista;
        public Frm_KreirajPutnik()
        {
            InitializeComponent();
            sedista = Kontroler.Instance.vratiListuSviSedista();
            cbSediste.DataSource = sedista;
            cbSediste.SelectedIndex = -1;
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa()) return;
            try
            {
                Putnik noviPutnik = new Putnik
                {
                    Ime = txtIme.Text.Trim(),
                    Prezime = txtPrezime.Text.Trim(),
                    Kategorija = txtKategorija.Text.Trim(),
                    BrojPasosa = txtBrojPasosa.Text.Trim(),
                    Sediste = cbSediste.SelectedItem as Sediste
                };

                bool uspesno = Kontroler.Instance.dodajPutnik(noviPutnik);
                if (uspesno)
                {
                    MessageBox.Show("Putnik uspešno kreiran.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Došlo je do greške prilikom kreiranja putnika.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Izuzetak", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
