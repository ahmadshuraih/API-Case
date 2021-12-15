using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace API_Case.Model
{
    public class AdresGegevens
    {
        [Key]
        public int Id { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
        public string Land { get; set; }

        //Voor Nederland NLD
        public string LandCode { get; set; }

        //Api key voor GeoLocation bij TomTom website
        protected string GeoTomTomApi = "EuoIRV3YsxKHmzPOgqo41PSAnk7KcsW6";

        //Het afstand tussen dit adres (start) en een andere adres (bestemming) berekenen doormiddel van TomTom Web Api
        public string AfstandRekenen(AdresGegevens bestemming)
        {
            //De longitude en latitude waarden van beide posities aanvragen
            string startPositie = GetPosition(this);
            string bestemmingPositie = GetPosition(bestemming);

            //Als er een fout opgetreden is, returneer dat het adres niet juist is
            if (startPositie.Equals("Fout"))
            {
                return "Het opgegeven adres met id " + Id + " is fout";
            } else if (bestemmingPositie.Equals("Fout"))
            {
                return "Het opgegeven adres met id " + bestemming.Id + " is fout";
            }

            //Api url van TomTom om het afstand te aanvragen
            string url = "https://api.tomtom.com/routing/1/calculateRoute/" + startPositie + "%3A" + bestemmingPositie + "/json?avoid=unpavedRoads&key=" + GeoTomTomApi;
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //Haal het afstand uit de response
                WebHeaderCollection header = response.Headers;
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    string responseText = reader.ReadToEnd();
                    JObject json = JObject.Parse(responseText);

                    //Het afstand is in meters
                    int afstand = int.Parse(json["routes"][0]["summary"]["lengthInMeters"].ToString());
                    return "De afstand is " + (afstand / 1000) + "km";
                }
            }
        }

        //De longitude en latitude waarden aanvragen
        public string GetPosition(AdresGegevens bestemming)
        {
            //De url voorbereiden om de longitude en latitude waarden te kunnen aanvragen
            string volAdres = bestemming.Straat + bestemming.Huisnummer + ", " + bestemming.Postcode + " " + bestemming.Plaats;
            string url = "https://api.tomtom.com/search/2/geocode/" + volAdres + ".json?countrySet=" + bestemming.LandCode + "&key=" + GeoTomTomApi;
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //De longitude en latitude waarden uit de response halen
                WebHeaderCollection header = response.Headers;
                var encoding = Encoding.ASCII;
                using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    try
                    {
                        string responseText = reader.ReadToEnd();
                        JObject json = JObject.Parse(responseText);

                        //De latitude en longitude uithalen en als string returneren separated met %2C
                        string lat = json["results"][0]["position"]["lat"].ToString();
                        string lon = json["results"][0]["position"]["lon"].ToString();
                        return lat + "%2C" + lon;
                    }
                    catch
                    (ArgumentOutOfRangeException) //Dit exception betekent dat het adres klopt niet
                    {
                        return "Fout";
                    }
                }
            }
        }
    }
}
