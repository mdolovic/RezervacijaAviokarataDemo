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
        public Frm_PretragaRezervacija()
        {
            InitializeComponent();

            btnIzmeni.Enabled = false;
           // btnPretraga.Enabled = false;

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
                        new StavkaRezervacije
                        {
                            Let = cbLet.SelectedItem as Let
                        }
                    };
                }

                List<Rezervacija> lista = Kontroler.Instance.vratiListuRezervacija(r);

                dgvRezervacija.DataSource = lista;

                if (!dgvRezervacija.Columns.Contains("Let") || !!dgvRezervacija.Columns.Contains("rb"))
                {
                    DataGridViewTextBoxColumn colLet = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Let",
                        Name = "Let"
                    };
                    dgvRezervacija.Columns.Add(colLet);
                    DataGridViewTextBoxColumn colrb = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "rb",
                        Name = "rb"
                    };
                    dgvRezervacija.Columns.Add(colrb);
                }

                foreach (DataGridViewRow row in dgvRezervacija.Rows)
                {
                    if (row.DataBoundItem is Rezervacija rez && rez.Stavke != null && rez.Stavke.Count > 0)
                    {
                        row.Cells["Let"].Value = rez.Stavke[0].Let;
                        row.Cells["rb"].Value = rez.Stavke[0].rb;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
