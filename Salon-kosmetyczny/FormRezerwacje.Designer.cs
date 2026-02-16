namespace Salon_kosmetyczny
{
    partial class FormRezerwacje
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

        private void InitializeComponent()
        {
            comboBoxKlientki = new ComboBox();
            comboBoxPracownicy = new ComboBox();
            comboBoxPlacowki = new ComboBox();
            comboBoxUslugi = new ComboBox();
            dateTimePickerCzas = new DateTimePicker();
            dateTimePickerData = new DateTimePicker();
            buttonZapisz = new Button();
            buttonAnuluj = new Button();
            SuspendLayout();
          
            comboBoxKlientki.FormattingEnabled = true;
            comboBoxKlientki.Location = new Point(383, 159);
            comboBoxKlientki.Name = "comboBoxKlientki";
            comboBoxKlientki.Size = new Size(121, 23);
            comboBoxKlientki.TabIndex = 0;
            comboBoxKlientki.Text = "Lista klientek";
            
            comboBoxPracownicy.FormattingEnabled = true;
            comboBoxPracownicy.Location = new Point(383, 106);
            comboBoxPracownicy.Name = "comboBoxPracownicy";
            comboBoxPracownicy.Size = new Size(121, 23);
            comboBoxPracownicy.TabIndex = 1;
            comboBoxPracownicy.Text = "Lista pracowników";
            
            comboBoxPlacowki.FormattingEnabled = true;
            comboBoxPlacowki.Location = new Point(142, 106);
            comboBoxPlacowki.Name = "comboBoxPlacowki";
            comboBoxPlacowki.Size = new Size(121, 23);
            comboBoxPlacowki.TabIndex = 2;
            comboBoxPlacowki.Text = "Lista placówek";
           
            comboBoxUslugi.FormattingEnabled = true;
            comboBoxUslugi.Location = new Point(142, 159);
            comboBoxUslugi.Name = "comboBoxUslugi";
            comboBoxUslugi.Size = new Size(121, 23);
            comboBoxUslugi.TabIndex = 3;
            comboBoxUslugi.Text = "Lista usług";
        
            dateTimePickerCzas.Format = DateTimePickerFormat.Time;
            dateTimePickerCzas.Location = new Point(342, 46);
            dateTimePickerCzas.Name = "dateTimePickerCzas";
            dateTimePickerCzas.Size = new Size(200, 23);
            dateTimePickerCzas.TabIndex = 4;
            
            dateTimePickerData.Location = new Point(116, 46);
            dateTimePickerData.Name = "dateTimePickerData";
            dateTimePickerData.Size = new Size(200, 23);
            dateTimePickerData.TabIndex = 5;
           
            buttonZapisz.Location = new Point(205, 258);
            buttonZapisz.Name = "buttonZapisz";
            buttonZapisz.Size = new Size(75, 23);
            buttonZapisz.TabIndex = 6;
            buttonZapisz.Text = "Zapisz";
            buttonZapisz.UseVisualStyleBackColor = true;
            buttonZapisz.Click += buttonZapisz_Click;
           
            buttonAnuluj.Location = new Point(399, 258);
            buttonAnuluj.Name = "buttonAnuluj";
            buttonAnuluj.Size = new Size(75, 23);
            buttonAnuluj.TabIndex = 7;
            buttonAnuluj.Text = "Anuluj";
            buttonAnuluj.UseVisualStyleBackColor = true;
            buttonAnuluj.Click += buttonAnuluj_Click;
         
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 450);
            Controls.Add(buttonAnuluj);
            Controls.Add(buttonZapisz);
            Controls.Add(dateTimePickerData);
            Controls.Add(dateTimePickerCzas);
            Controls.Add(comboBoxUslugi);
            Controls.Add(comboBoxPlacowki);
            Controls.Add(comboBoxPracownicy);
            Controls.Add(comboBoxKlientki);
            Name = "FormRezerwacje";
            Text = "FormRezerwacje";
            Load += FormRezerwacje_Load;
            ResumeLayout(false);
        }

        private ComboBox comboBoxKlientki;
        private ComboBox comboBoxPracownicy;
        private ComboBox comboBoxPlacowki;
        private ComboBox comboBoxUslugi;
        private DateTimePicker dateTimePickerCzas;
        private DateTimePicker dateTimePickerData;
        private Button buttonZapisz;
        private Button buttonAnuluj;
    }
}