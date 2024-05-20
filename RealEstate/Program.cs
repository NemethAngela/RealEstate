
using RealEstate.Models;
using System.Globalization;

List<Ad> adLista = Ad.LoadFromJson(); //lista az Ad-hoz

FoldszintAlapterulet();
GetLegkozelebbiTehermentesIngatlan(47.4164220114023, 19.066342425796986);

void FoldszintAlapterulet()
{
    var atlagosAlapterulet = adLista.Where(x => x.Floors == 0).Average(x => x.Area);
    Console.WriteLine($"6. A földszinti ingatlanok átlagos alapterülete: {atlagosAlapterulet:F2} m^2"); //két tizedes jegy pontossággal adja vissza az alapterületet
}

double DistanceTo(Ad ad, double lat, double lng) //GPS koordinátától legközelebbi ingatlan távolsága
{
    string[] splittedLatLng = ad.LatLong.Split(",");
    double adLat = double.Parse(splittedLatLng[0], CultureInfo.InvariantCulture);
    double adLng = double.Parse(splittedLatLng[1], CultureInfo.InvariantCulture);

    // a^2 + b^2 = c^2
    var a_square = (adLat - lat) * (adLat - lat);
    var b_square = (adLng - lng) * (adLng - lng);
    double tavolsag = Math.Sqrt(a_square + b_square);

    return tavolsag;
}

void GetLegkozelebbiTehermentesIngatlan(double lat, double lng) //legközelebbi eladó ingatlan adatai
{
    var tehermentesek = adLista.Where(x => x.FreeOfCharge);
    double minimumTav = double.MaxValue;
    Ad legkozelebbiAd = null;
    foreach (var ad in tehermentesek)
    {
        var tavolsag = DistanceTo(ad, lat, lng);
        if (tavolsag < minimumTav)
        {
            minimumTav = tavolsag;
            legkozelebbiAd = ad;
        }
    }

    Console.WriteLine($"8. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai: {legkozelebbiAd}");
}

