namespace Forme
{
    partial class Frm_PretragaPutnik
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtKategorija = new TextBox();
            txtBrojPasosa = new TextBox();
            cbSediste = new ComboBox();
            btnPretraga = new Button();
            dgvPutnici = new DataGridView();
            btnObrisi = new Button();
            Izmeni = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPutnici).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPretraga);
            groupBox1.Controls.Add(cbSediste);
            groupBox1.Controls.Add(txtBrojPasosa);
            groupBox1.Controls.Add(txtKategorija);
            groupBox1.Controls.Add(txtPrezime);
            groupBox1.Controls.Add(txtIme);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(32, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(317, 355);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kriterijumi za pretragu putnika";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 52);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 99);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 150);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 2;
            label3.Text = "Kategorija:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 204);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 3;
            label4.Text = "Broj pasosa:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 259);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 4;
            label5.Text = "Sediste:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(128, 49);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(168, 27);
            txtIme.TabIndex = 5;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(128, 96);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(168, 27);
            txtPrezime.TabIndex = 6;
            // 
            // txtKategorija
            // 
            txtKategorija.Location = new Point(128, 143);
            txtKategorija.Name = "txtKategorija";
            txtKategorija.Size = new Size(168, 27);
            txtKategorija.TabIndex = 7;
            // 
            // txtBrojPasosa
            // 
            txtBrojPasosa.Location = new Point(128, 197);
            txtBrojPasosa.Name = "txtBrojPasosa";
            txtBrojPasosa.Size = new Size(168, 27);
            txtBrojPasosa.TabIndex = 8;
            // 
            // cbSediste
            // 
            cbSediste.FormattingEnabled = true;
            cbSediste.Location = new Point(128, 256);
            cbSediste.Name = "cbSediste";
            cbSediste.Size = new Size(168, 28);
            cbSediste.TabIndex = 9;
            // 
            // btnPretraga
            // 
            btnPretraga.Location = new Point(110, 304);
            btnPretraga.Name = "btnPretraga";
            btnPretraga.Size = new Size(94, 29);
            btnPretraga.TabIndex = 10;
            btnPretraga.Text = "Pretrazi";
            btnPretraga.UseVisualStyleBackColor = true;
            // 
            // dgvPutnici
            // 
            dgvPutnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPutnici.Location = new Point(383, 50);
            dgvPutnici.Name = "dgvPutnici";
            dgvPutnici.RowHeadersWidth = 51;
            dgvPutnici.Size = new Size(390, 273);
            dgvPutnici.TabIndex = 1;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(383, 343);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(146, 51);
            btnObrisi.TabIndex = 2;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // Izmeni
            // 
            Izmeni.Location = new Point(627, 343);
            Izmeni.Name = "Izmeni";
            Izmeni.Size = new Size(146, 51);
            Izmeni.TabIndex = 3;
            Izmeni.Text = "Izmeni";
            Izmeni.UseVisualStyleBackColor = true;
            // 
            // Frm_PretragaPutnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Izmeni);
            Controls.Add(btnObrisi);
            Controls.Add(dgvPutnici);
            Controls.Add(groupBox1);
            Name = "Frm_PretragaPutnik";
            Text = "Pretraga putnika";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPutnici).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnPretraga;
        private ComboBox cbSediste;
        private TextBox txtBrojPasosa;
        private TextBox txtKategorija;
        private TextBox txtPrezime;
        private TextBox txtIme;
        private DataGridView dgvPutnici;
        private Button btnObrisi;
        private Button Izmeni;
    }
}