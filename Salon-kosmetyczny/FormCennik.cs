using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Salon_kosmetyczny
{
    public partial class FormCennik : Form
    {
        private DatabaseHelper dbHelper;

        public FormCennik()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadCennik();
        }

        private void LoadCennik()
        {
            // Pobierz wszystkie usługi
            DataTable dt = dbHelper.GetAllUslugi(false);
            dataGridViewCennik.DataSource = dt;

            // Formatowanie kolumn
            if (dataGridViewCennik.Columns.Count > 0)
            {
                // Ukryj niepotrzebne kolumny
                if (dataGridViewCennik.Columns.Contains("UslugaID"))
                    dataGridViewCennik.Columns["UslugaID"].Visible = false;

                if (dataGridViewCennik.Columns.Contains("IsActive"))
                    dataGridViewCennik.Columns["IsActive"].Visible = false;

                if (dataGridViewCennik.Columns.Contains("Opis"))
                    dataGridViewCennik.Columns["Opis"].Visible = false;

                // Nazwy kolumn po polsku
                if (dataGridViewCennik.Columns.Contains("Nazwa"))
                    dataGridViewCennik.Columns["Nazwa"].HeaderText = "Nazwa usługi";

                if (dataGridViewCennik.Columns.Contains("Kategoria"))
                    dataGridViewCennik.Columns["Kategoria"].HeaderText = "Kategoria";

                if (dataGridViewCennik.Columns.Contains("Cena"))
                {
                    dataGridViewCennik.Columns["Cena"].HeaderText = "Cena (zł)";
                    dataGridViewCennik.Columns["Cena"].DefaultCellStyle.Format = "F2";
                }

                if (dataGridViewCennik.Columns.Contains("CzasTrwania"))
                    dataGridViewCennik.Columns["CzasTrwania"].HeaderText = "Czas (min)";
            }

            // Wypełnij listę kategorii
            WypelnijKategorie();
        }

        private void WypelnijKategorie()
        {
            try
            {
                // Pobierz wszystkie usługi
                DataTable dt = dbHelper.GetAllUslugi(false);

                // Wyciągnij unikalne kategorie
                var kategorie = dt.AsEnumerable()
                    .Select(row => row["Kategoria"].ToString())
                    .Where(k => !string.IsNullOrEmpty(k))
                    .Distinct()
                    .OrderBy(k => k)
                    .ToList();

                // Wyczyść i wypełnij ComboBox
                comboBoxKategoria.Items.Clear();
                comboBoxKategoria.Items.Add("Wszystkie");

                foreach (string kategoria in kategorie)
                {
                    comboBoxKategoria.Items.Add(kategoria);
                }

                // Wybierz domyślnie "Wszystkie"
                if (comboBoxKategoria.Items.Count > 0)
                    comboBoxKategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania kategorii: {ex.Message}");
            }
        }

        private void comboBoxKategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxKategoria.SelectedItem == null)
                    return;

                string wybranaKategoria = comboBoxKategoria.SelectedItem.ToString();

                if (wybranaKategoria == "Wszystkie")
                {
                    // Pokaż wszystkie usługi
                    dataGridViewCennik.DataSource = dbHelper.GetAllUslugi(false);
                }
                else
                {
                    // Filtruj po kategorii
                    DataTable dt = dbHelper.GetAllUslugi(false);
                    dt.DefaultView.RowFilter = $"Kategoria = '{wybranaKategoria}'";
                    dataGridViewCennik.DataSource = dt.DefaultView;
                }

                // Odśwież formatowanie kolumn
                if (dataGridViewCennik.Columns.Contains("Cena"))
                    dataGridViewCennik.Columns["Cena"].DefaultCellStyle.Format = "F2";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas filtrowania: {ex.Message}");
            }
        }
    }
}