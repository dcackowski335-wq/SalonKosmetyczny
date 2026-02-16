using System;

namespace Salon_kosmetyczny.Models
{
    public class Pracownik
    {
        public int PracownikID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public bool IsActive { get; set; }

        public string PelneImie => $"{Imie} {Nazwisko}";
    }
}