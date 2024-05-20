namespace RealEstate_NA_Backend.Models
{
    public class Ingatlan
    {
        public int Id { get; set; }
        public int KategoriaId { get; set; }
        public string Leiras { get; set; }
        public DateTime HirdetesDatuma { get; set;}
        public bool Tehermentes { get; set; }
        public int Ar { get; set; }
        public string KepUrl { get; set; }

        public string? KategoriaNev { get; set; }

        // Konstruktor, ami az alapértelmezett értéket az aktuális dátumra állítja
        public Ingatlan()
        {
            HirdetesDatuma = DateTime.Now;
        }

        // Segédfüggvény, ami beállítja a dátumot, és ellenőrzi, hogy üres-e
        public void SetDate(DateTime date)
        {
            HirdetesDatuma = date != DateTime.MinValue ? date : DateTime.Now;
        }
    }
}
