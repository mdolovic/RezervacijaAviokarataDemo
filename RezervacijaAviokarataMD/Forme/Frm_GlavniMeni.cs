using Domen;
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
    public partial class Frm_GlavniMeni : Form
    {
        private Aviokompanija aviokompanija;
        public Frm_GlavniMeni(Aviokompanija a)
        {
            InitializeComponent();
            aviokompanija = a;
        }

        private void kreirajRezervacijuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_KreirajRezervacija f = new Frm_KreirajRezervacija(aviokompanija, null);
            f.ShowDialog();

        }

        private void pretragaRezervacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_PretragaRezervacija f = new Frm_PretragaRezervacija();
            f.ShowDialog();
        }

        private void dodajDestinacijuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_UbaciDestinacija f = new Frm_UbaciDestinacija();
            f.ShowDialog();
        }
    }
}
