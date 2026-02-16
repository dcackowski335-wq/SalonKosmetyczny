using System;

namespace Salon_kosmetyczny.Models
{
    public class Klientka
    {
        public int KlientkaID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DataRejestracji { get; set; }
        public string Uwagi { get; set; }

        public string PelneNazwisko => $"{Imie} {Nazwisko}";
    }
}