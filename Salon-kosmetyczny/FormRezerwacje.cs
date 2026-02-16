using Salon_kosmetyczny.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Salon_kosmetyczny
{
    public partial class FormRezerwacje : Form
    {
        private DatabaseHelper dbHelper;

        public FormRezerwacje()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        // Ładowanie danych do list rozwijanych przy starcie
        private void FormRezerwacje_Load(object sender, EventArgs e)
        {
            try
            {
                // Wypełnianie ComboBoxów danymi z bazy
                DataTable klientki = dbHelper.GetAllKlientki();
                comboBoxKlientki.DataSource = klientki;
                comboBoxKlientki.DisplayMember = "PelneNazwisko"; // Pokazuje imię + nazwisko
                comboBoxKlientki.ValueMember = "KlientkaID"; // Przechowuje ID

                DataTable pracownicy = dbHelper.GetAllPracownicy();
                comboBoxPracownicy.DataSource = pracownicy;
                comboBoxPracownicy.DisplayMember = "PelneImie";
                comboBoxPracownicy.ValueMember = "PracownikID";

                DataTable placowki = dbHelper.GetAllPlacowki();
                comboBoxPlacowki.DataSource = placowki;
                comboBoxPlacowki.DisplayMember = "Nazwa";
                comboBoxPlacowki.ValueMember = "PlacowkaID";

                DataTable uslugi = dbHelper.GetAllUslugi();
                comboBoxUslugi.DataSource = uslugi;
                comboBoxUslugi.DisplayMember = "Nazwa";
                comboBoxUslugi.ValueMember = "UslugaID";

                // Ustawienia daty i godziny (domyślnie jutro 10:00)
                dateTimePickerData.Value = DateTime.Now.AddDays(1);
                dateTimePickerCzas.Format = DateTimePickerFormat.Time;
                dateTimePickerCzas.ShowUpDown = true; // Strzałki zamiast kalendarza
                dateTimePickerCzas.Value = DateTime.Today.AddHours(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania: {ex.Message}");
            }
        }

        // Zapis nowej rezerwacji
        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                // Sprawdzenie czy wszystkie pola są wybrane
                if (comboBoxKlientki.SelectedValue == null ||
                    comboBoxPracownicy.SelectedValue == null ||
                    comboBoxPlacowki.SelectedValue == null ||
                    comboBoxUslugi.SelectedValue == null)
                {
                    MessageBox.Show("Wypełnij wszystkie pola!");
                    return;
                }

                // Połączenie daty i godziny w jeden obiekt DateTime
                DateTime data = dateTimePickerData.Value.Date;
                TimeSpan czas = dateTimePickerCzas.Value.TimeOfDay;
                DateTime dataCzas = data.Add(czas);

                // Tworzenie obiektu rezerwacji z danych z formularza
                Rezerwacja rezerwacja = new Rezerwacja
                {
                    KlientkaID = Convert.ToInt32(comboBoxKlientki.SelectedValue),
                    PracownikID = Convert.ToInt32(comboBoxPracownicy.SelectedValue),
                    PlacowkaID = Convert.ToInt32(comboBoxPlacowki.SelectedValue),
                    UslugaID = Convert.ToInt32(comboBoxUslugi.SelectedValue),
                    DataRezerwacji = dataCzas,
                    Status = "Zaplanowana" // Domyślny status nowej rezerwacji
                };

                // Zapis do bazy danych
                dbHelper.AddRezerwacja(rezerwacja);

                MessageBox.Show("Rezerwacja dodana pomyślnie!");
                DialogResult = DialogResult.OK; // Informacja dla form1 że sukces
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu: {ex.Message}");
            }
        }

        // Anulowanie - zamyka okno bez zapisu
        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}