
using System.Text.Json;

namespace RealEstate.Models
{ 
    public class Ad
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set;}
        public string ImageUrl { get; set;}
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        
        public static List<Ad> LoadFromJson()
        {
            string jsonContent = File.ReadAllText("realestates.json");  //teljes text fájl beolvasása
            //figyelni a json és az osztály paraméter neveinek egyezésére! akkor ez nem kell:
            var options = new JsonSerializerOptions     //kis-nagybetű különbségek figyelmen kívül hagyása az osztály property-jei és a json változónevek között
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<Ad>>(jsonContent, options);  //Ad objektum listává alakítja a json text-et
        }

        public override string ToString() //a legközelebbi eladó adatainak kiiratása
        {
            return $"{Environment.NewLine}\tEladó neve: {Seller.Name}{Environment.NewLine}\tEladó telefonszáma: {Seller.Phone}{Environment.NewLine}\tAlapterület: {Area}{Environment.NewLine}\tSzobák száma: {Rooms}";
        }
    }
}
