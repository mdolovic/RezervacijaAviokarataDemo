namespace Forme
{
    partial class Frm_GlavniMeni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            rezervacijaToolStripMenuItem = new ToolStripMenuItem();
            kreirajRezervacijuToolStripMenuItem = new ToolStripMenuItem();
            pretragaRezervacijaToolStripMenuItem = new ToolStripMenuItem();
            putnikToolStripMenuItem = new ToolStripMenuItem();
            kreirajPutnikaToolStripMenuItem = new ToolStripMenuItem();
            pretragaPutnikaToolStripMenuItem = new ToolStripMenuItem();
            destinacijaToolStripMenuItem = new ToolStripMenuItem();
            dodajDestinacijuToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { rezervacijaToolStripMenuItem, putnikToolStripMenuItem, destinacijaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(449, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // rezervacijaToolStripMenuItem
            // 
            rezervacijaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajRezervacijuToolStripMenuItem, pretragaRezervacijaToolStripMenuItem });
            rezervacijaToolStripMenuItem.Name = "rezervacijaToolStripMenuItem";
            rezervacijaToolStripMenuItem.Size = new Size(98, 24);
            rezervacijaToolStripMenuItem.Text = "Rezervacija";
            // 
            // kreirajRezervacijuToolStripMenuItem
            // 
            kreirajRezervacijuToolStripMenuItem.Name = "kreirajRezervacijuToolStripMenuItem";
            kreirajRezervacijuToolStripMenuItem.Size = new Size(224, 26);
            kreirajRezervacijuToolStripMenuItem.Text = "Kreiraj rezervaciju";
            kreirajRezervacijuToolStripMenuItem.Click += kreirajRezervacijuToolStripMenuItem_Click;
            // 
            // pretragaRezervacijaToolStripMenuItem
            // 
            pretragaRezervacijaToolStripMenuItem.Name = "pretragaRezervacijaToolStripMenuItem";
            pretragaRezervacijaToolStripMenuItem.Size = new Size(224, 26);
            pretragaRezervacijaToolStripMenuItem.Text = "Pretraga rezervacija";
            // 
            // putnikToolStripMenuItem
            // 
            putnikToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajPutnikaToolStripMenuItem, pretragaPutnikaToolStripMenuItem });
            putnikToolStripMenuItem.Name = "putnikToolStripMenuItem";
            putnikToolStripMenuItem.Size = new Size(63, 24);
            putnikToolStripMenuItem.Text = "Putnik";
            // 
            // kreirajPutnikaToolStripMenuItem
            // 
            kreirajPutnikaToolStripMenuItem.Name = "kreirajPutnikaToolStripMenuItem";
            kreirajPutnikaToolStripMenuItem.Size = new Size(201, 26);
            kreirajPutnikaToolStripMenuItem.Text = "Kreiraj putnika";
            // 
            // pretragaPutnikaToolStripMenuItem
            // 
            pretragaPutnikaToolStripMenuItem.Name = "pretragaPutnikaToolStripMenuItem";
            pretragaPutnikaToolStripMenuItem.Size = new Size(201, 26);
            pretragaPutnikaToolStripMenuItem.Text = "Pretraga putnika";
            // 
            // destinacijaToolStripMenuItem
            // 
            destinacijaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajDestinacijuToolStripMenuItem });
            destinacijaToolStripMenuItem.Name = "destinacijaToolStripMenuItem";
            destinacijaToolStripMenuItem.Size = new Size(96, 24);
            destinacijaToolStripMenuItem.Text = "Destinacija";
            // 
            // dodajDestinacijuToolStripMenuItem
            // 
            dodajDestinacijuToolStripMenuItem.Name = "dodajDestinacijuToolStripMenuItem";
            dodajDestinacijuToolStripMenuItem.Size = new Size(208, 26);
            dodajDestinacijuToolStripMenuItem.Text = "Dodaj destinaciju";
            // 
            // Frm_GlavniMeni
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 351);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Frm_GlavniMeni";
            Text = "Glavni Meni";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem rezervacijaToolStripMenuItem;
        private ToolStripMenuItem putnikToolStripMenuItem;
        private ToolStripMenuItem kreirajRezervacijuToolStripMenuItem;
        private ToolStripMenuItem pretragaRezervacijaToolStripMenuItem;
        private ToolStripMenuItem kreirajPutnikaToolStripMenuItem;
        private ToolStripMenuItem pretragaPutnikaToolStripMenuItem;
        private ToolStripMenuItem destinacijaToolStripMenuItem;
        private ToolStripMenuItem dodajDestinacijuToolStripMenuItem;
    }
}