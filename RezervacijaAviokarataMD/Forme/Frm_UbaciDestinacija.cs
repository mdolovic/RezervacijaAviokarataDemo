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
    public partial class Frm_UbaciDestinacija : Form
    {
        public Frm_UbaciDestinacija()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                string naziv = txtNaziv.Text.Trim();
                if (string.IsNullOrWhiteSpace(naziv))
                {
                    MessageBox.Show("Unesite naziv destinacije.");
                    return;
                }

                Destinacija d = new Destinacija
                {
                    Naziv = naziv
                };

                bool uspesno = Kontroler.Instance.dodajDestinaciju(d);
                if (uspesno)
                {
                    MessageBox.Show("Sistem je uspešno dodao destinaciju.");
                    txtNaziv.Clear();
                }
                else
                {
                    MessageBox.Show("Sistem ne može da doda destinaciju.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }
    }
}
