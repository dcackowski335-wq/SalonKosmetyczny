using System;
using System.Data;
using System.Windows.Forms;

namespace Salon_kosmetyczny
{
    public partial class FormPlacowki : Form
    {
        private DatabaseHelper dbHelper;

        public FormPlacowki()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadPlacowki(); // Ładuje listę placówek przy starcie
        }

        // Ładuje wszystkie placówki z bazy do tabeli
        private void LoadPlacowki()
        {
            try
            {
                DataTable dt = dbHelper.GetAllPlacowki();
                dataGridViewPlacowki.DataSource = dt;

                if (dataGridViewPlacowki.Columns.Count > 0)
                {
                    // Ukryj ID (niepotrzebne użytkownikowi)
                    if (dataGridViewPlacowki.Columns.Contains("PlacowkaID"))
                        dataGridViewPlacowki.Columns["PlacowkaID"].Visible = false;

                    // Zmiana nazw kolumn na czytelne dla użytkownika
                    if (dataGridViewPlacowki.Columns.Contains("Nazwa"))
                        dataGridViewPlacowki.Columns["Nazwa"].HeaderText = "Nazwa placówki";

                    if (dataGridViewPlacowki.Columns.Contains("Adres"))
                        dataGridViewPlacowki.Columns["Adres"].HeaderText = "Adres";

                    if (dataGridViewPlacowki.Columns.Contains("Miasto"))
                        dataGridViewPlacowki.Columns["Miasto"].HeaderText = "Miasto";

                    if (dataGridViewPlacowki.Columns.Contains("Telefon"))
                        dataGridViewPlacowki.Columns["Telefon"].HeaderText = "Telefon";

                    // Dopasowuje szerokość kolumn do zawartości
                    dataGridViewPlacowki.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }

                // Wyświetla liczbę placówek
                labelIlosc.Text = $"Liczba placówek: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania: {ex.Message}");
            }
        }

        // Odświeża listę placówek
        private void buttonOdswiez_Click(object sender, EventArgs e)
        {
            LoadPlacowki();
        }
    }
}