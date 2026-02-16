using System;
using System.Data;
using System.Windows.Forms;
using Salon_kosmetyczny.Models;

namespace Salon_kosmetyczny
{
    public partial class FormKlientki : Form
    {
        private DatabaseHelper dbHelper;

        public FormKlientki()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadKlientki(); // Ładuje listę klientek przy starcie
        }

        // Ładuje wszystkie klientki z bazy do tabeli
        private void LoadKlientki()
        {
            dataGridViewKlientki.DataSource = dbHelper.GetAllKlientki();

            // Formatowanie wyglądu tabeli
            dataGridViewKlientki.Columns["KlientkaID"].Visible = false; // Ukryj ID
            dataGridViewKlientki.Columns["DataRejestracji"].Visible = false; // Ukryj datę rejestracji
            dataGridViewKlientki.Columns["Imie"].HeaderText = "Imię";
            dataGridViewKlientki.Columns["Nazwisko"].HeaderText = "Nazwisko";
            dataGridViewKlientki.Columns["Email"].HeaderText = "E-mail";
            dataGridViewKlientki.Columns["Telefon"].HeaderText = "Telefon";
            dataGridViewKlientki.Columns["Uwagi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Uwagi na całą szerokość
        }

        // Dodawanie nowej klientki
        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            // Sprawdź czy wymagane pola są wypełnione
            if (string.IsNullOrWhiteSpace(textBoxImie.Text) ||
                string.IsNullOrWhiteSpace(textBoxNazwisko.Text))
            {
                MessageBox.Show("Imię i nazwisko są wymagane.");
                return;
            }

            // Tworzy nowy obiekt klientki z danych z formularza
            Klientka klientka = new Klientka
            {
                Imie = textBoxImie.Text,
                Nazwisko = textBoxNazwisko.Text,
                Email = textBoxEmail.Text,
                Telefon = textBoxTelefon.Text,
                Uwagi = textBoxUwagi.Text
            };

            dbHelper.AddKlientka(klientka); // Zapis do bazy

            // Czyści pola formularza
            textBoxImie.Clear();
            textBoxNazwisko.Clear();
            textBoxEmail.Clear();
            textBoxTelefon.Clear();
            textBoxUwagi.Clear();

            LoadKlientki(); // Odświeża listę
            MessageBox.Show("Klientka dodana!");
        }

        // Wyszukiwanie klientek
        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            DataTable dt = dbHelper.GetAllKlientki();
            // Filtrowanie po imieniu, nazwisku lub telefonie
            dt.DefaultView.RowFilter = string.Format("Imie LIKE '%{0}%' OR Nazwisko LIKE '%{0}%' OR Telefon LIKE '%{0}%'",
                textBoxSzukaj.Text);
            dataGridViewKlientki.DataSource = dt.DefaultView;
        }

        private void FormKlientki_Load(object sender, EventArgs e)
        {
            // Tutaj kod który ma się wykonać przy ładowaniu formularza
        }

        // Odświeża listę klientek
        private void buttonOdswiez_Click(object sender, EventArgs e)
        {
            LoadKlientki();
            textBoxSzukaj.Clear(); // Czyści pole wyszukiwania
        }

        // Usuwanie zaznaczonej klientki
        private void buttonUsun_Click(object sender, EventArgs e)
        {
            // Sprawdza czy coś jest zaznaczone
            if (dataGridViewKlientki.SelectedRows.Count > 0)
            {
                // Pobiera dane zaznaczonej klientki
                int klientkaID = Convert.ToInt32(dataGridViewKlientki.SelectedRows[0].Cells["KlientkaID"].Value);
                string imie = dataGridViewKlientki.SelectedRows[0].Cells["Imie"].Value.ToString();
                string nazwisko = dataGridViewKlientki.SelectedRows[0].Cells["Nazwisko"].Value.ToString();

                // Pyta o potwierdzenie
                DialogResult result = MessageBox.Show($"Czy na pewno usunąć {imie} {nazwisko}?",
                    "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dbHelper.DeleteKlientka(klientkaID); // Usuwa z bazy
                    LoadKlientki(); // Odświeża listę
                }
            }
            else
            {
                MessageBox.Show("Zaznacz klientkę do usunięcia.");
            }
        }
    }
}