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
    public partial class Frm_PretragaPutnik : Form
    {
        public Frm_PretragaPutnik()
        {
            InitializeComponent();

            cbSediste.DataSource = Kontroler.Instance.vratiListuSviSedista();
            cbSediste.SelectedIndex = -1;

            dgvPutnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPutnici.MultiSelect = false;
            dgvPutnici.ReadOnly = true;

        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            try
            {
                Putnik kriterijum = new Putnik
                {
                    Ime = string.IsNullOrWhiteSpace(txtIme.Text) ? null : txtIme.Text.Trim(),
                    Prezime = string.IsNullOrWhiteSpace(txtPrezime.Text) ? null : txtPrezime.Text.Trim(),
                    Kategorija = string.IsNullOrWhiteSpace(txtKategorija.Text) ? null : txtKategorija.Text.Trim(),
                    BrojPasosa = string.IsNullOrWhiteSpace(txtBrojPasosa.Text) ? null : txtBrojPasosa.Text.Trim(),
                    Sediste = cbSediste.SelectedIndex >= 0 ? cbSediste.SelectedItem as Sediste : null
                };

                List<Putnik> rezultat = Kontroler.Instance.vratiPutnikePoKriterijumu(kriterijum);

                dgvPutnici.Columns.Clear();
                dgvPutnici.AutoGenerateColumns = false;
                dgvPutnici.DataSource = rezultat;

                // Ime
                dgvPutnici.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Ime",
                    DataPropertyName = "Ime"
                });

                // Prezime
                dgvPutnici.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Prezime",
                    DataPropertyName = "Prezime"
                });

                // Kategorija
                dgvPutnici.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Kategorija",
                    DataPropertyName = "Kategorija"
                });

                // Broj pasoša
                dgvPutnici.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Broj pasoša",
                    DataPropertyName = "BrojPasosa"
                });

                // Sediste
                dgvPutnici.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Sedište",
                    Name = "Sediste",
                    ReadOnly = true
                });
                foreach (DataGridViewRow row in dgvPutnici.Rows)
                {
                    if (row.DataBoundItem is Putnik p)
                    {
                        row.Cells["Sediste"].Value = p.Sediste.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
