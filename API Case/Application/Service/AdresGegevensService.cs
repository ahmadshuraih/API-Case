using API_Case.Application.SqlFilter;
using API_Case.Model;

namespace API_Case.Application.Service
{
    public interface AdresGegevensService
    {
        //Haal alle adresgegevens uit de database
        dynamic GetAll();

        //Haal EEN adresgegevens uit de database op basis van de id
        dynamic Get(int id);

        //Maak een nieuwe adresgegevens in de database
        string Save(AdresGegevens adresGegevens);

        //Wijzig een bestaande adresgegevens in database op basis van de id
        string Update(int id, AdresGegevens adresGegevens);

        //Verwijder een bestaande adresgegevens uit de database op basis van de id
        string Delete(int id);

        //Bereken het afstand tussen twee adressen op basis van de id daarvan
        string GetAfstand(int vertrekId, int bestemmingId);

        //Haal adresgegevens lijst uit de database op basis van SEQLFilter
        dynamic GetFiltered(SQLFilter sqlFilter);
    }
}
