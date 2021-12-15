using API_Case.Application.Implementation;
using API_Case.Application.Service;
using API_Case.Application.SqlFilter;
using API_Case.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Case.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdresGegevensController : ControllerBase
    {
        //Adresgegevens service
        private AdresGegevensService adresGegevensService = new AdresGegevensServiceImpl();

        // GET: AdresGegevens
        //Haal alle adresgegevens uit de database
        [HttpGet]
        public dynamic GetAll()
        {
            return adresGegevensService.GetAll();
        }

        // GET: AdresGegevens/5
        //Haal EEN adresgegevens uit de database op basis van de id
        [HttpGet("{id}")]
        public dynamic GetById(int id)
        {
            return adresGegevensService.Get(id);
        }

        // POST: AdresGegevens
        //Maak een nieuwe adresgegevens in de database
        [HttpPost]
        public string Post([FromBody] AdresGegevens adresGegevens)
        {
            return adresGegevensService.Save(adresGegevens);
        }

        // PUT: AdresGegevens/5
        //Wijzig een bestaande adresgegevens in database op basis van de id
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] AdresGegevens adresGegevens)
        {
            return adresGegevensService.Update(id, adresGegevens);
        }

        // DELETE: AdresGegevens/5
        //Verwijder een bestaande adresgegevens uit de database op basis van de id
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return adresGegevensService.Delete(id);
        }

        // GET: AdresGegevens/Afstand/1/2
        //Bereken het afstand tussen twee adressen op basis van de id daarvan
        [HttpGet("Afstand/{vertrekId}/{bestemmingId}")]
        public string GetAfstand(int vertrekId, int bestemmingId)
        {
            return adresGegevensService.GetAfstand(vertrekId, bestemmingId);
        }

        // PUT: AdresGegevens/Filter
        //Haal adresgegevens lijst uit de database op basis van SEQLFilter
        [HttpPut("Filter")]
        public dynamic GetFiltered([FromBody] SQLFilter sqlFilter)
        {
            return adresGegevensService.GetFiltered(sqlFilter);
        }
    }
}
