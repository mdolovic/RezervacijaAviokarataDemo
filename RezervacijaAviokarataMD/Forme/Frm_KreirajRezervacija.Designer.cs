namespace Forme
{
    partial class Frm_KreirajRezervacija
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
            txtOpis = new TextBox();
            cbPutnik = new ComboBox();
            groupBox1 = new GroupBox();
            dgvStavkaRezervacije = new DataGridView();
            lbLEt = new Label();
            cbLet = new ComboBox();
            label3 = new Label();
            txtNazivStavke = new TextBox();
            lbDa = new Label();
            label4 = new Label();
            dtpDatumOdlaska = new DateTimePicker();
            dtpDatumDolaska = new DateTimePicker();
            label5 = new Label();
            numCenaStavke = new NumericUpDown();
            btnDodajStavku = new Button();
            label6 = new Label();
            txtUkupnaCena = new TextBox();
            btnKreirajRezervaciju = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavkaRezervacije).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCenaStavke).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 34);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 0;
            label1.Text = "Opis:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 75);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Putnik:";
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(125, 31);
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(231, 27);
            txtOpis.TabIndex = 2;
            // 
            // cbPutnik
            // 
            cbPutnik.FormattingEnabled = true;
            cbPutnik.Location = new Point(125, 72);
            cbPutnik.Name = "cbPutnik";
            cbPutnik.Size = new Size(231, 28);
            cbPutnik.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDodajStavku);
            groupBox1.Controls.Add(numCenaStavke);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtpDatumDolaska);
            groupBox1.Controls.Add(dtpDatumOdlaska);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lbDa);
            groupBox1.Controls.Add(txtNazivStavke);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbLet);
            groupBox1.Controls.Add(lbLEt);
            groupBox1.Controls.Add(dgvStavkaRezervacije);
            groupBox1.Location = new Point(19, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(769, 397);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stavka rezervacije";
            // 
            // dgvStavkaRezervacije
            // 
            dgvStavkaRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavkaRezervacije.Location = new Point(305, 65);
            dgvStavkaRezervacije.Name = "dgvStavkaRezervacije";
            dgvStavkaRezervacije.RowHeadersWidth = 51;
            dgvStavkaRezervacije.Size = new Size(443, 256);
            dgvStavkaRezervacije.TabIndex = 0;
            // 
            // lbLEt
            // 
            lbLEt.AutoSize = true;
            lbLEt.Location = new Point(14, 42);
            lbLEt.Name = "lbLEt";
            lbLEt.Size = new Size(32, 20);
            lbLEt.TabIndex = 1;
            lbLEt.Text = "Let:";
            // 
            // cbLet
            // 
            cbLet.FormattingEnabled = true;
            cbLet.Location = new Point(14, 65);
            cbLet.Name = "cbLet";
            cbLet.Size = new Size(250, 28);
            cbLet.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 110);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 3;
            label3.Text = "Naziv stavke:";
            // 
            // txtNazivStavke
            // 
            txtNazivStavke.Location = new Point(14, 133);
            txtNazivStavke.Name = "txtNazivStavke";
            txtNazivStavke.Size = new Size(250, 27);
            txtNazivStavke.TabIndex = 4;
            // 
            // lbDa
            // 
            lbDa.AutoSize = true;
            lbDa.Location = new Point(14, 187);
            lbDa.Name = "lbDa";
            lbDa.Size = new Size(112, 20);
            lbDa.TabIndex = 5;
            lbDa.Text = "Datum odlaska:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 261);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 6;
            label4.Text = "Datum dolaska:";
            // 
            // dtpDatumOdlaska
            // 
            dtpDatumOdlaska.Location = new Point(14, 217);
            dtpDatumOdlaska.Name = "dtpDatumOdlaska";
            dtpDatumOdlaska.Size = new Size(250, 27);
            dtpDatumOdlaska.TabIndex = 7;
            // 
            // dtpDatumDolaska
            // 
            dtpDatumDolaska.Location = new Point(14, 294);
            dtpDatumDolaska.Name = "dtpDatumDolaska";
            dtpDatumDolaska.Size = new Size(250, 27);
            dtpDatumDolaska.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 348);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 9;
            label5.Text = "Cena:";
            // 
            // numCenaStavke
            // 
            numCenaStavke.Location = new Point(88, 346);
            numCenaStavke.Name = "numCenaStavke";
            numCenaStavke.Size = new Size(176, 27);
            numCenaStavke.TabIndex = 10;
            // 
            // btnDodajStavku
            // 
            btnDodajStavku.Location = new Point(611, 344);
            btnDodajStavku.Name = "btnDodajStavku";
            btnDodajStavku.Size = new Size(137, 29);
            btnDodajStavku.TabIndex = 11;
            btnDodajStavku.Text = "Dodaj stavku";
            btnDodajStavku.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 538);
            label6.Name = "label6";
            label6.Size = new Size(172, 20);
            label6.TabIndex = 5;
            label6.Text = "Ukupna cena rezervacije:";
            // 
            // txtUkupnaCena
            // 
            txtUkupnaCena.Enabled = false;
            txtUkupnaCena.Location = new Point(211, 535);
            txtUkupnaCena.Name = "txtUkupnaCena";
            txtUkupnaCena.Size = new Size(181, 27);
            txtUkupnaCena.TabIndex = 6;
            // 
            // btnKreirajRezervaciju
            // 
            btnKreirajRezervaciju.Location = new Point(630, 533);
            btnKreirajRezervaciju.Name = "btnKreirajRezervaciju";
            btnKreirajRezervaciju.Size = new Size(137, 29);
            btnKreirajRezervaciju.TabIndex = 7;
            btnKreirajRezervaciju.Text = "Kreiraj";
            btnKreirajRezervaciju.UseVisualStyleBackColor = true;
            // 
            // Frm_KreirajRezervacija
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 579);
            Controls.Add(btnKreirajRezervaciju);
            Controls.Add(txtUkupnaCena);
            Controls.Add(label6);
            Controls.Add(groupBox1);
            Controls.Add(cbPutnik);
            Controls.Add(txtOpis);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Frm_KreirajRezervacija";
            Text = "Kreiraj Rezervaciju";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavkaRezervacije).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCenaStavke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtOpis;
        private ComboBox cbPutnik;
        private GroupBox groupBox1;
        private Label label3;
        private ComboBox cbLet;
        private Label lbLEt;
        private DataGridView dgvStavkaRezervacije;
        private NumericUpDown numCenaStavke;
        private Label label5;
        private DateTimePicker dtpDatumDolaska;
        private DateTimePicker dtpDatumOdlaska;
        private Label label4;
        private Label lbDa;
        private TextBox txtNazivStavke;
        private Button btnDodajStavku;
        private Label label6;
        private TextBox txtUkupnaCena;
        private Button btnKreirajRezervaciju;
    }
}