namespace Forme
{
    partial class Frm_KreirajPutnik
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnKreiraj = new Button();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtKategorija = new TextBox();
            txtBrojPasosa = new TextBox();
            cbSediste = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 42);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 103);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 168);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 2;
            label3.Text = "Kategorija:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 240);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 3;
            label4.Text = "Broj pasosa:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 306);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 4;
            label5.Text = "Sediste:";
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(160, 374);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(119, 37);
            btnKreiraj.TabIndex = 5;
            btnKreiraj.Text = "Kreiraj";
            btnKreiraj.UseVisualStyleBackColor = true;
            btnKreiraj.Click += btnKreiraj_Click;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(160, 42);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(214, 27);
            txtIme.TabIndex = 6;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(160, 103);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(214, 27);
            txtPrezime.TabIndex = 7;
            // 
            // txtKategorija
            // 
            txtKategorija.Location = new Point(160, 165);
            txtKategorija.Name = "txtKategorija";
            txtKategorija.Size = new Size(214, 27);
            txtKategorija.TabIndex = 8;
            // 
            // txtBrojPasosa
            // 
            txtBrojPasosa.Location = new Point(160, 237);
            txtBrojPasosa.Name = "txtBrojPasosa";
            txtBrojPasosa.Size = new Size(214, 27);
            txtBrojPasosa.TabIndex = 9;
            // 
            // cbSediste
            // 
            cbSediste.FormattingEnabled = true;
            cbSediste.Location = new Point(160, 303);
            cbSediste.Name = "cbSediste";
            cbSediste.Size = new Size(214, 28);
            cbSediste.TabIndex = 10;
            // 
            // Frm_KreirajPutnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 450);
            Controls.Add(cbSediste);
            Controls.Add(txtBrojPasosa);
            Controls.Add(txtKategorija);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(btnKreiraj);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Frm_KreirajPutnik";
            Text = "Kreiraj putnika";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnKreiraj;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtKategorija;
        private TextBox txtBrojPasosa;
        private ComboBox cbSediste;
    }
}