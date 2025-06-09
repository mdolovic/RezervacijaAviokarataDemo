namespace Forme
{
    partial class Frm_UbaciDestinacija
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
            txtNaziv = new TextBox();
            btnDodaj = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 57);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(154, 54);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(201, 27);
            txtNaziv.TabIndex = 1;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(154, 112);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(94, 29);
            btnDodaj.TabIndex = 2;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // Frm_UbaciDestinacija
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 194);
            Controls.Add(btnDodaj);
            Controls.Add(txtNaziv);
            Controls.Add(label1);
            Name = "Frm_UbaciDestinacija";
            Text = "Dodaj destinaciju";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNaziv;
        private Button btnDodaj;
    }
}