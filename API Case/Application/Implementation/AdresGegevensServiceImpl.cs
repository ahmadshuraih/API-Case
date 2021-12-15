using API_Case.Application.Service;
using API_Case.Model;
using API_Case.Persistence.Context;
using API_Case.Application.SqlFilter;
using Microsoft.EntityFrameworkCore;

namespace API_Case.Application.Implementation
{
    //Dit klasse implementeerd de service klasse AdresGegevensService, wordt gebruikt door de controller
    public class AdresGegevensServiceImpl : AdresGegevensService
    {
        //Haal alle adresgegevens uit de database
        public dynamic GetAll()
        {
            using (SqliteDBContext dBContext = new())
            {
                List<AdresGegevens> adresGegevens = dBContext.AdresGegevens.ToList();
                
                if (adresGegevens.Any())
                {
                    return adresGegevens;
                }

                return "Er bestaan geen Adresgegevens in de database";
            }
        }

        //Haal EEN adresgegevens uit de database op basis van de id
        public dynamic Get(int id)
        {
            using (SqliteDBContext dBContext = new())
            {
                AdresGegevens adresGegevens = dBContext.AdresGegevens.FirstOrDefault(a => a.Id == id);

                if (adresGegevens != null)
                {
                    return adresGegevens;
                }

                return "Adresgegevens met id " + id + " bestaat niet";
            }
        }

        //Maak een nieuwe adresgegevens in de database
        public string Save(AdresGegevens adresGegevens)
        {
            using (SqliteDBContext dBContext = new())
            {
                dBContext.AdresGegevens.Add(adresGegevens);

                if (dBContext.SaveChanges() == 1)
                {
                    return "Adresgegevens is succesvol opgeslagen";
                }

                return "Er is een fout opgetreden";
            }
        }

        //Wijzig een bestaande adresgegevens in database op basis van de id
        public string Update(int id, AdresGegevens adresGegevens)
        {
            using (SqliteDBContext dBContext = new())
            {
                AdresGegevens adressGegevensToSave = dBContext.AdresGegevens.FirstOrDefault(a => a.Id == id);

                if (adressGegevensToSave == null)
                {
                    return "Adresgegevens met id " + id + " bestaat niet";
                }

                adressGegevensToSave.Straat = adresGegevens.Straat;
                adressGegevensToSave.Huisnummer = adresGegevens.Huisnummer;
                adressGegevensToSave.Postcode = adresGegevens.Postcode;
                adressGegevensToSave.Plaats = adresGegevens.Plaats;
                adressGegevensToSave.Land = adresGegevens.Land;

                if (dBContext.SaveChanges() == 1)
                {
                    return "Adresgegevens met id " + id + " is succesvol gewijzigd";
                } 

                return "Er is een fout opgetreden";
            }
        }

        //Verwijder een bestaande adresgegevens uit de database op basis van de id
        public string Delete(int id)
        {
            using (SqliteDBContext dBContext = new())
            {
                AdresGegevens adressGegevens = dBContext.AdresGegevens.FirstOrDefault(a => a.Id == id);

                if (adressGegevens == null)
                {
                    return "Adresgegevens met id " + id + " bestaat niet";
                }

                dBContext.Remove(adressGegevens);

                if (dBContext.SaveChanges() == 1)
                {
                    return "Adresgegevens met id " + id + " is succesvol verwijderd";
                }

                return "Er is een fout opgetreden";
            }
        }

        //Bereken het afstand tussen twee adressen op basis van de id daarvan
        public string GetAfstand(int vertrekId, int bestemmingId)
        {
            using (SqliteDBContext dBContext = new())
            {
                //Haal beide adressen uit de database en check of ze wel bestaan
                AdresGegevens vertrekAdres = dBContext.AdresGegevens.FirstOrDefault(a => a.Id == vertrekId);

                if (vertrekAdres == null)
                {
                    return "Adresgegevens met id " + vertrekId + " bestaat niet in de database";
                }

                AdresGegevens bestemmingAdres = dBContext.AdresGegevens.FirstOrDefault(a => a.Id == bestemmingId);

                if (bestemmingAdres == null)
                {
                    return "Adresgegevens met id " + bestemmingId + " bestaat niet in de database";
                }

                //Bereken het afstand en returneer het resultaat
                return vertrekAdres.AfstandRekenen(bestemmingAdres);
            }
        }

        //Haal adresgegevens lijst uit de database op basis van SEQLFilter
        public dynamic GetFiltered(SQLFilter sqlFilter)
        {
            using (SqliteDBContext dBContext = new())
            {
                //De normale querystring zonder condities voorbereiden
                string queryString = "select * from Adresgegevens";

                //Als de filter niet null is
                if (sqlFilter != null)
                {
                    //Maak een filterstring en voeg die naar de querystring toe
                    queryString += sqlFilter.CreateFiltersAndSortString();
                }

                List<AdresGegevens> adresGegevens = dBContext.AdresGegevens.FromSqlRaw(queryString).ToList();

                if (adresGegevens.Any())
                {
                    return adresGegevens;
                }

                return "Er bestaan geen passend Adresgegevens in de database";
            }
        }
    }
}
