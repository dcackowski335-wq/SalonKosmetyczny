using System;

namespace Salon_kosmetyczny.Models
{
    public class Usluga
    {
        public int UslugaID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        public int CzasTrwania { get; set; }
        public string Kategoria { get; set; }
        public bool IsActive { get; set; }

        public string CzasTrwaniaText => $"{CzasTrwania} min";
        public string CenaText => $"{Cena:F2} zł";
    }
}