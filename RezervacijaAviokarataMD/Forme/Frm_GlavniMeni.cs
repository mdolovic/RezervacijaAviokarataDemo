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
        private Aviokompanija prijavljena;
        public Frm_GlavniMeni(Aviokompanija a)
        {
            InitializeComponent();
            prijavljena = a;
        }
    }
}
