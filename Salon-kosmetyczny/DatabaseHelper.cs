using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Salon_kosmetyczny.Models;

namespace Salon_kosmetyczny
{
    public class DatabaseHelper
    {
        // Połączenie z bazą danych SQL Server
        private string connectionString = @"Data Source=DESKTOP-3FU7HIB\SQLEXPRESS;Initial Catalog=SalonKosmetyczny;Integrated Security=True";

        // Tworzy nowe połączenie z bazą
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // ==================== KLIENTKI ====================

        // Pobiera wszystkie klientki
        public DataTable GetAllKlientki()
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Klientki ORDER BY Nazwisko, Imie";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Dodaje nową klientkę
        public void AddKlientka(Klientka klientka)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"INSERT INTO Klientki (Imie, Nazwisko, Email, Telefon, Uwagi) 
                                VALUES (@Imie, @Nazwisko, @Email, @Telefon, @Uwagi)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Imie", klientka.Imie);
                cmd.Parameters.AddWithValue("@Nazwisko", klientka.Nazwisko);
                cmd.Parameters.AddWithValue("@Email", klientka.Email ?? ""); // ?? = jeśli null, daj ""
                cmd.Parameters.AddWithValue("@Telefon", klientka.Telefon ?? "");
                cmd.Parameters.AddWithValue("@Uwagi", klientka.Uwagi ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ==================== USŁUGI ====================

        // Pobiera wszystkie usługi (onlyActive = true = tylko aktywne)
        public DataTable GetAllUslugi(bool onlyActive = true)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Uslugi";
                if (onlyActive)
                    query += " WHERE IsActive = 1";
                query += " ORDER BY Kategoria, Nazwa";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // ==================== USUWANIE ====================

        // Usuwa klientkę i jej rezerwacje
        public void DeleteKlientka(int klientkaID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // Najpierw usuń rezerwacje (klucze obce w bazie)
                string deleteRezerwacje = "DELETE FROM Rezerwacje WHERE KlientkaID = @KlientkaID";
                SqlCommand cmdRez = new SqlCommand(deleteRezerwacje, conn);
                cmdRez.Parameters.AddWithValue("@KlientkaID", klientkaID);
                cmdRez.ExecuteNonQuery();

                // Potem usuń klientkę
                string deleteKlientka = "DELETE FROM Klientki WHERE KlientkaID = @KlientkaID";
                SqlCommand cmdKlientka = new SqlCommand(deleteKlientka, conn);
                cmdKlientka.Parameters.AddWithValue("@KlientkaID", klientkaID);
                cmdKlientka.ExecuteNonQuery();
            }
        }

        // ==================== PLACÓWKI ====================

        // Pobiera wszystkie placówki z miastami
        public DataTable GetAllPlacowki()
        {
            using (SqlConnection conn = GetConnection())
            {
                // Łączy tabelę Placowki z Miasta (JOIN)
                string query = @"SELECT p.PlacowkaID, p.Nazwa, p.Adres, m.Nazwa AS Miasto, p.Telefon 
                                FROM Placowki p 
                                JOIN Miasta m ON p.MiastoID = m.MiastoID 
                                WHERE p.IsActive = 1 
                                ORDER BY m.Nazwa, p.Nazwa";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // ==================== PRACOWNICY ====================

        // Pobiera pracowników (ID + pełne imię i nazwisko)
        public DataTable GetAllPracownicy()
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT PracownikID, Imie + ' ' + Nazwisko AS PelneImie FROM Pracownicy WHERE IsActive = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // ==================== REZERWACJE ====================

        // Pobiera rezerwacje na konkretny dzień
        public DataTable GetRezerwacje(DateTime data)
        {
            using (SqlConnection conn = GetConnection())
            {
                // Łączy 5 tabel: Rezerwacje, Klientki, Pracownicy, Placowki, Uslugi
                string query = @"SELECT r.RezerwacjaID, k.Imie + ' ' + k.Nazwisko AS Klient, 
                                p.Imie + ' ' + p.Nazwisko AS Pracownik, 
                                pl.Nazwa AS Placowka, u.Nazwa AS Usluga, u.Cena,
                                r.DataRezerwacji, r.Status, r.Uwagi
                                FROM Rezerwacje r
                                JOIN Klientki k ON r.KlientkaID = k.KlientkaID
                                JOIN Pracownicy p ON r.PracownikID = p.PracownikID
                                JOIN Placowki pl ON r.PlacowkaID = pl.PlacowkaID
                                JOIN Uslugi u ON r.UslugaID = u.UslugaID
                                WHERE CAST(r.DataRezerwacji AS DATE) = @Data
                                ORDER BY r.DataRezerwacji";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Data", data.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Dodaje nową rezerwację
        public void AddRezerwacja(Rezerwacja rezerwacja)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"INSERT INTO Rezerwacje (KlientkaID, PracownikID, PlacowkaID, UslugaID, DataRezerwacji, Uwagi) 
                                VALUES (@KlientkaID, @PracownikID, @PlacowkaID, @UslugaID, @DataRezerwacji, @Uwagi)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@KlientkaID", rezerwacja.KlientkaID);
                cmd.Parameters.AddWithValue("@PracownikID", rezerwacja.PracownikID);
                cmd.Parameters.AddWithValue("@PlacowkaID", rezerwacja.PlacowkaID);
                cmd.Parameters.AddWithValue("@UslugaID", rezerwacja.UslugaID);
                cmd.Parameters.AddWithValue("@DataRezerwacji", rezerwacja.DataRezerwacji);
                cmd.Parameters.AddWithValue("@Uwagi", rezerwacja.Uwagi ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Zmienia status rezerwacji (np. na "Anulowana")
        public void UpdateRezerwacjaStatus(int rezerwacjaID, string status)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE Rezerwacje SET Status = @Status WHERE RezerwacjaID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@ID", rezerwacjaID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}