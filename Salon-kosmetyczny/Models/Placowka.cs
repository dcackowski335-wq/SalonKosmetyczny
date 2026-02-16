namespace Salon_kosmetyczny.Models
{
    public class Placowka
    {
        public int PlacowkaID { get; set; }
        public string Nazwa { get; set; }
        public string Adres { get; set; }
        public int MiastoID { get; set; }
        public string Telefon { get; set; }
        public bool IsActive { get; set; }

        
        public string MiastoNazwa { get; set; }
        public string PelnaNazwa => $"{Nazwa} - {Adres}";
    }
}