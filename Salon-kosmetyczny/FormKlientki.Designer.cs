namespace Salon_kosmetyczny
{
    partial class FormKlientki
    {
        private System.ComponentModel.IContainer components = null;
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
            dataGridViewKlientki = new DataGridView();
            textBoxEmail = new TextBox();
            buttonSzukaj = new Button();
            textBoxTelefon = new TextBox();
            textBoxUwagi = new TextBox();
            textBoxNazwisko = new TextBox();
            textBoxImie = new TextBox();
            textBoxSzukaj = new TextBox();
            buttonOdswiez = new Button();
            buttonDodaj = new Button();
            buttonUsun = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKlientki).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewKlientki
            // 
            dataGridViewKlientki.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKlientki.Location = new Point(209, 53);
            dataGridViewKlientki.Name = "dataGridViewKlientki";
            dataGridViewKlientki.Size = new Size(554, 220);
            dataGridViewKlientki.TabIndex = 0;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(12, 191);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 23);
            textBoxEmail.TabIndex = 1;
            textBoxEmail.Text = "Email";
            // 
            // buttonSzukaj
            // 
            buttonSzukaj.Location = new Point(492, 312);
            buttonSzukaj.Name = "buttonSzukaj";
            buttonSzukaj.Size = new Size(75, 23);
            buttonSzukaj.TabIndex = 2;
            buttonSzukaj.Text = "Szukaj";
            buttonSzukaj.UseVisualStyleBackColor = true;
            buttonSzukaj.Click += buttonSzukaj_Click;
            // 
            // textBoxTelefon
            // 
            textBoxTelefon.Location = new Point(12, 141);
            textBoxTelefon.Name = "textBoxTelefon";
            textBoxTelefon.Size = new Size(100, 23);
            textBoxTelefon.TabIndex = 3;
            textBoxTelefon.Text = "Telefon";
            // 
            // textBoxUwagi
            // 
            textBoxUwagi.Location = new Point(12, 253);
            textBoxUwagi.Name = "textBoxUwagi";
            textBoxUwagi.Size = new Size(100, 23);
            textBoxUwagi.TabIndex = 4;
            textBoxUwagi.Text = "Uwagi";
            // 
            // textBoxNazwisko
            // 
            textBoxNazwisko.Location = new Point(12, 101);
            textBoxNazwisko.Name = "textBoxNazwisko";
            textBoxNazwisko.Size = new Size(100, 23);
            textBoxNazwisko.TabIndex = 5;
            textBoxNazwisko.Text = "Nazwisko";
            // 
            // textBoxImie
            // 
            textBoxImie.Location = new Point(12, 53);
            textBoxImie.Name = "textBoxImie";
            textBoxImie.Size = new Size(100, 23);
            textBoxImie.TabIndex = 6;
            textBoxImie.Text = "Imię";
            // 
            // textBoxSzukaj
            // 
            textBoxSzukaj.Location = new Point(12, 312);
            textBoxSzukaj.Name = "textBoxSzukaj";
            textBoxSzukaj.Size = new Size(100, 23);
            textBoxSzukaj.TabIndex = 7;
            textBoxSzukaj.Text = "Szukaj";
            // 
            // buttonOdswiez
            // 
            buttonOdswiez.Location = new Point(615, 312);
            buttonOdswiez.Name = "buttonOdswiez";
            buttonOdswiez.Size = new Size(75, 23);
            buttonOdswiez.TabIndex = 8;
            buttonOdswiez.Text = "Odśwież";
            buttonOdswiez.UseVisualStyleBackColor = false;
            buttonOdswiez.Click += buttonOdswiez_Click;
            // 
            // buttonDodaj
            // 
            buttonDodaj.Location = new Point(242, 312);
            buttonDodaj.Name = "buttonDodaj";
            buttonDodaj.Size = new Size(75, 23);
            buttonDodaj.TabIndex = 9;
            buttonDodaj.Text = "Dodaj";
            buttonDodaj.UseVisualStyleBackColor = true;
            buttonDodaj.Click += buttonDodaj_Click;
            // 
            // buttonUsun
            // 
            buttonUsun.ForeColor = Color.Tomato;
            buttonUsun.Location = new Point(366, 312);
            buttonUsun.Name = "buttonUsun";
            buttonUsun.Size = new Size(75, 23);
            buttonUsun.TabIndex = 10;
            buttonUsun.Text = "Usuń";
            buttonUsun.UseVisualStyleBackColor = true;
            buttonUsun.Click += buttonUsun_Click;
            // 
            // FormKlientki
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 462);
            Controls.Add(buttonUsun);
            Controls.Add(buttonDodaj);
            Controls.Add(buttonOdswiez);
            Controls.Add(textBoxSzukaj);
            Controls.Add(textBoxImie);
            Controls.Add(textBoxNazwisko);
            Controls.Add(textBoxUwagi);
            Controls.Add(textBoxTelefon);
            Controls.Add(buttonSzukaj);
            Controls.Add(textBoxEmail);
            Controls.Add(dataGridViewKlientki);
            Name = "FormKlientki";
            Text = "FormKlientki";
            Load += FormKlientki_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewKlientki).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewKlientki;
        private TextBox textBoxEmail;
        private Button buttonSzukaj;
        private TextBox textBoxTelefon;
        private TextBox textBoxUwagi;
        private TextBox textBoxNazwisko;
        private TextBox textBoxImie;
        private TextBox textBoxSzukaj;
        private Button buttonOdswiez;
        private Button buttonDodaj;
        private Button buttonUsun;
    }
}