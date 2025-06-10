namespace Forme
{
    partial class Frm_PromeniPutnik
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
            txtIme = new TextBox();
            txtBrojPasosa = new TextBox();
            txtKategorija = new TextBox();
            txtPrezime = new TextBox();
            cbSediste = new ComboBox();
            btnPromeni = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 61);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 117);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 309);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 2;
            label3.Text = "Sediste:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 237);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 3;
            label4.Text = "Broj pasosa:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 174);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 4;
            label5.Text = "Kategorija:";
            // 
            // txtIme
            // 
            txtIme.BackColor = SystemColors.Window;
            txtIme.Location = new Point(192, 58);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(185, 27);
            txtIme.TabIndex = 5;
            // 
            // txtBrojPasosa
            // 
            txtBrojPasosa.Location = new Point(192, 234);
            txtBrojPasosa.Name = "txtBrojPasosa";
            txtBrojPasosa.Size = new Size(185, 27);
            txtBrojPasosa.TabIndex = 6;
            // 
            // txtKategorija
            // 
            txtKategorija.Location = new Point(192, 171);
            txtKategorija.Name = "txtKategorija";
            txtKategorija.Size = new Size(185, 27);
            txtKategorija.TabIndex = 7;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(192, 114);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(185, 27);
            txtPrezime.TabIndex = 8;
            // 
            // cbSediste
            // 
            cbSediste.FormattingEnabled = true;
            cbSediste.Location = new Point(192, 301);
            cbSediste.Name = "cbSediste";
            cbSediste.Size = new Size(185, 28);
            cbSediste.TabIndex = 9;
            // 
            // btnPromeni
            // 
            btnPromeni.Location = new Point(256, 369);
            btnPromeni.Name = "btnPromeni";
            btnPromeni.Size = new Size(121, 34);
            btnPromeni.TabIndex = 10;
            btnPromeni.Text = "Promeni";
            btnPromeni.UseVisualStyleBackColor = true;
            btnPromeni.Click += btnPromeni_Click;
            // 
            // Frm_PromeniPutnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 450);
            Controls.Add(btnPromeni);
            Controls.Add(cbSediste);
            Controls.Add(txtPrezime);
            Controls.Add(txtKategorija);
            Controls.Add(txtBrojPasosa);
            Controls.Add(txtIme);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Frm_PromeniPutnik";
            Text = "Promeni putnika";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtIme;
        private TextBox txtBrojPasosa;
        private TextBox txtKategorija;
        private TextBox txtPrezime;
        private ComboBox cbSediste;
        private Button btnPromeni;
    }
}