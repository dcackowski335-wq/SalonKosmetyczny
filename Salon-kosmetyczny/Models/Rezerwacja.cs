using System;

namespace Salon_kosmetyczny.Models
{
    public class Rezerwacja
    {
        public int RezerwacjaID { get; set; }
        public int KlientkaID { get; set; }
        public int PracownikID { get; set; }
        public int PlacowkaID { get; set; }
        public int UslugaID { get; set; }
        public DateTime DataRezerwacji { get; set; }
        public string Status { get; set; }
        public string Uwagi { get; set; }

       
        public string KlientkaNazwa { get; set; }
        public string PracownikNazwa { get; set; }
        public string PlacowkaNazwa { get; set; }
        public string UslugaNazwa { get; set; }
    }
}