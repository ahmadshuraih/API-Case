# API-Case
Een stage toegangsopdracht

Deze opdracht is bedoeld om mijn kennis in C# te laten zien aan het stagebedrijf Social Brothers. Dit opdracht bestaat uit drie delen:
## Deel 1: API algemeen
In dit deel moest ik een simpele entiteit te maken en de database met de CRUD functies daarvan waar uitgeroepen moeten worden door een 
API controller. Om de API te kunnen tesetn, moest ik Swagger gebruiken.Ik heb dit deel netjes gemaakt waar alles werkend opgeleverd en 
tot behoren is. Om het project te testen moeten er niks extra's gedaan worden. gewoon clonen, opennen en runnen. <br>
Het project werd in framework .NET 6.0 aangemaakt. <br>

Voor de database gebruikte ik de volgende packages:<br>
-Microsoft.EntityFrameworkCore.Relational (6.0.1)<br>
-Microsoft.EntityFrameworkCore.Sqlite (6.0.1)<br>
-Microsoft.EntityFrameworkCore.Tools (6.0.1)<br>

Voor SWagger heb ik de volgende package gebruikt:
Swashbuckle.AspNetCore (6.2.3)

<br>
Ik vind ORM's makkelijker, sneller en netter om ermee te werken bij het communiceren met de database. Daarom heb ik voor gekozen om dit 
opdracht door middel van EntityFramework te maken. En omdat ik met het model begonnen ben, heb hiervoor gekozen om 
(Code first) methode te gebruiken bij het migreren.<br>
Ik ben trots op in wat ik gemaakt heb in dit deel.

## Deel 2: Filters
Het was heel lastig voor mij om te weten hoe ver de filters gebruikt gaan worden en hoe flexiebel de filters moeten zijn. Ik heb onderzocht op 
een goede manier of naar een package hiervoor, maar helaas kon ik zelf dat niet vinden. Omdat ik geen genoeg tijd vanwege mijn studie heb, 
heb ik uiteindelijk de filter zelfgemaakt. Dit filter bouwt de filterstring gedeelte stuk voor stuk op basis van de ingevoerde waarden in de filter. 
Hij werkt prima, maar hij kan helaas niet tegen SQL-Injection. Dus ik vind hem niet veilig. Daarom ben ik niet helemaal tevreden in dit deel. Om 
de filter te kunnen gebruiken, kijk eerst naar het lijstje Operations binnen de klasse API_Case.Application.SqlFilter.Filter.

## Deel 3: Afstanden
In dit deel moest ik door geolocation API de afstand tussen twee adressen tonen (in kilometers). Hiervoor heb ik een gratis API gevonden door 
TomTom. Omdat het adres in meerdere plaatsen hetzelfde kan zijn. Heb ik hiervoor gezorgd dat de latitude en longitude waarden van het adres 
gehaald kunnen worden op basis van Straat, Huisnummer, Postcode, Plaats en LandCode. Daarom om een accurate afstand te kunnen krijgen, 
moeten de adresgegevens accuraat ook zijn. Dit deel werkt prima, ik vind hem goed functioneren en ik ben erop trots.

Alles verder werd uitgelegd in commentaren binnen de klassen van het project.

Ik hoor graag uw mening in mijn oplevering.
