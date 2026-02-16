namespace Salon_kosmetyczny
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

   
        /// <param name="disposing">
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            buttonDodajRezerwacje = new Button();
            buttonZarzadzajKlientkami = new Button();
            buttonCennik = new Button();
            buttonPlacowki = new Button();
            buttonOdswiez = new Button();
            monthCalendar1 = new MonthCalendar();
            dataGridViewRezerwacje = new DataGridView();
            buttonAnulujRezerwacje = new Button();
            labelData = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezerwacje).BeginInit();
            SuspendLayout();
         
            buttonDodajRezerwacje.Location = new Point(130, 49);
            buttonDodajRezerwacje.Name = "buttonDodajRezerwacje";
            buttonDodajRezerwacje.Size = new Size(133, 23);
            buttonDodajRezerwacje.TabIndex = 0;
            buttonDodajRezerwacje.Text = "Dodaj rezerwację";
            buttonDodajRezerwacje.UseVisualStyleBackColor = true;
            buttonDodajRezerwacje.Click += buttonDodajRezerwacje_Click;
        
            buttonZarzadzajKlientkami.Location = new Point(314, 49);
            buttonZarzadzajKlientkami.Name = "buttonZarzadzajKlientkami";
            buttonZarzadzajKlientkami.Size = new Size(75, 23);
            buttonZarzadzajKlientkami.TabIndex = 1;
            buttonZarzadzajKlientkami.Text = "Klientki";
            buttonZarzadzajKlientkami.UseVisualStyleBackColor = true;
            buttonZarzadzajKlientkami.Click += buttonZarzadzajKlientkami_Click;
       
            buttonCennik.Location = new Point(451, 49);
            buttonCennik.Name = "buttonCennik";
            buttonCennik.Size = new Size(75, 23);
            buttonCennik.TabIndex = 2;
            buttonCennik.Text = "Cennik";
            buttonCennik.UseVisualStyleBackColor = true;
            buttonCennik.Click += buttonCennik_Click;
       
            buttonPlacowki.Location = new Point(582, 49);
            buttonPlacowki.Name = "buttonPlacowki";
            buttonPlacowki.Size = new Size(75, 23);
            buttonPlacowki.TabIndex = 3;
            buttonPlacowki.Text = "Placówki";
            buttonPlacowki.UseVisualStyleBackColor = true;
            buttonPlacowki.Click += buttonPlacowki_Click;
          
            buttonOdswiez.Location = new Point(695, 49);
            buttonOdswiez.Name = "buttonOdswiez";
            buttonOdswiez.Size = new Size(75, 23);
            buttonOdswiez.TabIndex = 4;
            buttonOdswiez.Text = "Odśwież";
            buttonOdswiez.UseVisualStyleBackColor = true;
            buttonOdswiez.Click += buttonOdswiez_Click;
        
            monthCalendar1.Location = new Point(18, 137);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 5;
        
            dataGridViewRezerwacje.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRezerwacje.Location = new Point(383, 147);
            dataGridViewRezerwacje.Name = "dataGridViewRezerwacje";
            dataGridViewRezerwacje.Size = new Size(805, 313);
            dataGridViewRezerwacje.TabIndex = 6;
          
            buttonAnulujRezerwacje.Location = new Point(794, 49);
            buttonAnulujRezerwacje.Name = "buttonAnulujRezerwacje";
            buttonAnulujRezerwacje.Size = new Size(144, 23);
            buttonAnulujRezerwacje.TabIndex = 7;
            buttonAnulujRezerwacje.Text = "Anuluj rezerwację";
            buttonAnulujRezerwacje.UseVisualStyleBackColor = true;
            buttonAnulujRezerwacje.Click += buttonAnulujRezerwacje_Click;
        
            labelData.AutoSize = true;
            labelData.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelData.Location = new Point(582, 113);
            labelData.Name = "labelData";
            labelData.Size = new Size(115, 15);
            labelData.TabIndex = 8;
            labelData.Text = "Rezerwacje na dzień:";
         
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1358, 527);
            Controls.Add(labelData);
            Controls.Add(buttonAnulujRezerwacje);
            Controls.Add(dataGridViewRezerwacje);
            Controls.Add(monthCalendar1);
            Controls.Add(buttonOdswiez);
            Controls.Add(buttonPlacowki);
            Controls.Add(buttonCennik);
            Controls.Add(buttonZarzadzajKlientkami);
            Controls.Add(buttonDodajRezerwacje);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezerwacje).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDodajRezerwacje;
        private Button buttonZarzadzajKlientkami;
        private Button buttonCennik;
        private Button buttonPlacowki;
        private Button buttonOdswiez;
        private MonthCalendar monthCalendar1;
        private DataGridView dataGridViewRezerwacje;
        private Button buttonAnulujRezerwacje;
        private Label labelData;
    }
}
