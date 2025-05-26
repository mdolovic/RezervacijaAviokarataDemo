using Domen;
using PoslovnaLogika;
namespace Forme
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string korisnickoIme = txtKorisnickoIme.Text.Trim();
            string sifra = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(korisnickoIme) || string.IsNullOrEmpty(sifra))
            {
                txtKorisnickoIme.BackColor = Color.Red;
                txtPass.BackColor = Color.Red;
                return;
            }

            try
            {
                Aviokompanija a = Kontroler.Instance.PrijaviAviokompanija(korisnickoIme, sifra);

                if (a != null)
                {
                    MessageBox.Show($"Dobrodosli, {a.Naziv}!", "Korisnicko ime i sifra su ispravni.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Frm_GlavniMeni frm = new Frm_GlavniMeni(a);
                    frm.Show();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ne moze da se otvori glavna forma i meni." + ex.Message);
            }
        }
    }
}
