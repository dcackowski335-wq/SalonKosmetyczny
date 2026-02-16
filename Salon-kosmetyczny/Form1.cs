using System;
using System.Windows.Forms;
using Salon_kosmetyczny;

namespace Salon_kosmetyczny
{
    // G³ówny formularz aplikacji
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            // Ustaw kalendarz na dzisiejsz¹ datê
            monthCalendar1.SelectionStart = DateTime.Now;
            monthCalendar1.SelectionEnd = DateTime.Now;

            LoadRezerwacje(DateTime.Now);
        }

        // £aduje rezerwacje z bazy dla wybranej daty
        private void LoadRezerwacje(DateTime data)
        {
            try
            {
                dataGridViewRezerwacje.DataSource = dbHelper.GetRezerwacje(data);

                if (dataGridViewRezerwacje.Columns.Count > 0)
                {
                    // Ukryj ID (niepotrzebne u¿ytkownikowi)
                    if (dataGridViewRezerwacje.Columns.Contains("RezerwacjaID"))
                        dataGridViewRezerwacje.Columns["RezerwacjaID"].Visible = false;

                    // Polskie nazwy kolumn
                    if (dataGridViewRezerwacje.Columns.Contains("Klient"))
                        dataGridViewRezerwacje.Columns["Klient"].HeaderText = "Klientka";
                    if (dataGridViewRezerwacje.Columns.Contains("Pracownik"))
                        dataGridViewRezerwacje.Columns["Pracownik"].HeaderText = "Pracownik";
                    if (dataGridViewRezerwacje.Columns.Contains("Placowka"))
                        dataGridViewRezerwacje.Columns["Placowka"].HeaderText = "Placówka";
                    if (dataGridViewRezerwacje.Columns.Contains("Usluga"))
                        dataGridViewRezerwacje.Columns["Usluga"].HeaderText = "Us³uga";
                    if (dataGridViewRezerwacje.Columns.Contains("Cena"))
                    {
                        dataGridViewRezerwacje.Columns["Cena"].HeaderText = "Cena";
                        dataGridViewRezerwacje.Columns["Cena"].DefaultCellStyle.Format = "C2"; // Format waluty
                    }
                    if (dataGridViewRezerwacje.Columns.Contains("DataRezerwacji"))
                    {
                        dataGridViewRezerwacje.Columns["DataRezerwacji"].HeaderText = "Data i godzina";
                        dataGridViewRezerwacje.Columns["DataRezerwacji"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                    }
                    if (dataGridViewRezerwacje.Columns.Contains("Status"))
                        dataGridViewRezerwacje.Columns["Status"].HeaderText = "Status";
                    if (dataGridViewRezerwacje.Columns.Contains("Uwagi"))
                    {
                        dataGridViewRezerwacje.Columns["Uwagi"].HeaderText = "Uwagi";
                        dataGridViewRezerwacje.Columns["Uwagi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }

                labelData.Text = $"Rezerwacje na dzieñ: {data.ToShortDateString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d ³adowania rezerwacji: {ex.Message}");
            }
        }

        // Zmiana daty w kalendarzu
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            LoadRezerwacje(e.Start);
        }

        // Otwiera formularz dodawania rezerwacji
        private void buttonDodajRezerwacje_Click(object sender, EventArgs e)
        {
            FormRezerwacje formRezerwacje = new FormRezerwacje();
            if (formRezerwacje.ShowDialog() == DialogResult.OK)
            {
                LoadRezerwacje(monthCalendar1.SelectionStart); // Odœwie¿ po dodaniu
            }
        }

        // Otwiera formularz klientek
        private void buttonZarzadzajKlientkami_Click(object sender, EventArgs e)
        {
            FormKlientki formKlientki = new FormKlientki();
            formKlientki.ShowDialog();
        }

        // Otwiera formularz cennika
        private void buttonCennik_Click(object sender, EventArgs e)
        {
            FormCennik formCennik = new FormCennik();
            formCennik.ShowDialog();
        }

        // Otwiera formularz placówek
        private void buttonPlacowki_Click(object sender, EventArgs e)
        {
            FormPlacowki formPlacowki = new FormPlacowki();
            formPlacowki.ShowDialog();
        }

        // Odœwie¿a listê rezerwacji
        private void buttonOdswiez_Click(object sender, EventArgs e)
        {
            LoadRezerwacje(monthCalendar1.SelectionStart);
        }

        // Anuluje zaznaczon¹ rezerwacjê
        private void buttonAnulujRezerwacje_Click(object sender, EventArgs e)
        {
            if (dataGridViewRezerwacje.SelectedRows.Count > 0)
            {
                int rezerwacjaID = Convert.ToInt32(dataGridViewRezerwacje.SelectedRows[0].Cells["RezerwacjaID"].Value);
                string klient = dataGridViewRezerwacje.SelectedRows[0].Cells["Klient"].Value.ToString();

                DialogResult result = MessageBox.Show($"Czy na pewno anulowaæ rezerwacjê dla {klient}?",
                    "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dbHelper.UpdateRezerwacjaStatus(rezerwacjaID, "Anulowana");
                    LoadRezerwacje(monthCalendar1.SelectionStart);
                    MessageBox.Show("Rezerwacja anulowana!");
                }
            }
            else
            {
                MessageBox.Show("Zaznacz rezerwacjê do anulowania.");
            }
        }
    }
}