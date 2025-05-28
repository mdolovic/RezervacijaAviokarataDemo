namespace Forme
{
    partial class Frm_PretragaRezervacija
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
            btnPretraga = new Button();
            cbPutnik = new ComboBox();
            cbLet = new ComboBox();
            cbAviokompanija = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvRezervacija = new DataGridView();
            btnIzmeni = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacija).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPretraga);
            groupBox1.Controls.Add(cbPutnik);
            groupBox1.Controls.Add(cbLet);
            groupBox1.Controls.Add(cbAviokompanija);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(39, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(592, 168);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kriterijumi pretrage";
            // 
            // btnPretraga
            // 
            btnPretraga.Location = new Point(475, 116);
            btnPretraga.Name = "btnPretraga";
            btnPretraga.Size = new Size(94, 29);
            btnPretraga.TabIndex = 6;
            btnPretraga.Text = "Pretrazi";
            btnPretraga.UseVisualStyleBackColor = true;
            btnPretraga.Click += btnPretraga_Click;
            // 
            // cbPutnik
            // 
            cbPutnik.FormattingEnabled = true;
            cbPutnik.Location = new Point(418, 68);
            cbPutnik.Name = "cbPutnik";
            cbPutnik.Size = new Size(151, 28);
            cbPutnik.TabIndex = 5;
            // 
            // cbLet
            // 
            cbLet.FormattingEnabled = true;
            cbLet.Location = new Point(221, 68);
            cbLet.Name = "cbLet";
            cbLet.Size = new Size(151, 28);
            cbLet.TabIndex = 4;
            // 
            // cbAviokompanija
            // 
            cbAviokompanija.FormattingEnabled = true;
            cbAviokompanija.Location = new Point(18, 68);
            cbAviokompanija.Name = "cbAviokompanija";
            cbAviokompanija.Size = new Size(151, 28);
            cbAviokompanija.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(418, 36);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 2;
            label3.Text = "Putnik:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(221, 36);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 1;
            label2.Text = "Let:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 36);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 0;
            label1.Text = "Aviokompanija:";
            // 
            // dgvRezervacija
            // 
            dgvRezervacija.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRezervacija.Location = new Point(39, 237);
            dgvRezervacija.Name = "dgvRezervacija";
            dgvRezervacija.RowHeadersWidth = 51;
            dgvRezervacija.Size = new Size(592, 196);
            dgvRezervacija.TabIndex = 1;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(514, 459);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(94, 29);
            btnIzmeni.TabIndex = 2;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            // 
            // Frm_PretragaRezervacija
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 518);
            Controls.Add(btnIzmeni);
            Controls.Add(dgvRezervacija);
            Controls.Add(groupBox1);
            Name = "Frm_PretragaRezervacija";
            Text = "Rezervacija";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacija).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbPutnik;
        private ComboBox cbLet;
        private ComboBox cbAviokompanija;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnPretraga;
        private DataGridView dgvRezervacija;
        private Button btnIzmeni;
    }
}