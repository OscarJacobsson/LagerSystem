#Övning 11: MVC - Lagersystem
Denna uppgift är relativt enkelt att följa, men ta god tid vid varje steg och se till att ni förstår! I denna applikation skall vi inte lägga stor vikt på effektivitet, optimering eller databasstruktur utan helt fokusera på MVC och hur det fungerar. 

###Applikationen
Innan vi börjar måste vi ha något att arbeta i. Skapa ett nytt MVC5 projekt genom File -> New -> Project -> Installed -> Visual C# -> Web -> Döp projektet -> OK -> Välj MVC

####Modellen:
Det första ni skall göra är en modell för applikationen, den kommer vara relativt enkel och spegla en vara eller ett föremål i lagret.
Skapa en klass i mappen Models som ni döper till “StockItem”
Lägg till “using System.ComponentModel.DataAnnotations;” bland de andra using statements som finns i .cs filen.
Skapa nu följande properties:
int ItemID
string Nameq
decimal Price
string Shelf
string Description
Sätt nu “[Key]” raden ovanför ItemID som kommer göra den till primary key när vi sedan genererar databasen.

####Data access, Context
Efter vi har vår modell måste vi skapa en data-access via en databaskontext. 
Skapa mappen DataAccessLayer via SolutionExplorer i Visual Studio.
Skapa klassen ItemContext i den nya mappen.
I ItemContext.cs lägg till “using System.Data.Entity;” (Om denna saknas så får du manuellt lägga till den i projektet genom att högerklicka ‘References’  i er solution explorer. Om detta händer kan det även vara värt att kontrollera att ni har Entity Framework installerat i Nuget Package Manager)
Gör sedan så ItemContext att klassen ärver från “DbContext”
Gör en publik konstruktor för ItemContext som anropar baskonstruktorn med inputsträngen “DefaultConnection”
Skapa sedan propertyn “public DbSet<Models.StockItem> Items { get;  set; }”

###Generera Databasen med Entity Framework
Nu är det hög tid att generera databasen!
Öppna package-manager-console (PMC) via Tools -> Nuget/Library package manager -> Package Manager Console
Skriv därefter in “Enable-Migrations”
Gå in i den genererade Migrations.Configuration-klassen
I seed metoden skall vi fylla på med lite grund-data som vi vill ska finnas i databasen redan från början. Gör detta genom att ta inspiration från den kod som finns i de genererade kommentarerna fast applicera det på era egna Klasser och DbSet (Glöm inte att lägga till er modell som using statement).
När vi är nöjda med seed-metoden skall vi använda oss av kommandot “Add-Migration Namn” där namn är ett godtyckligt namn. Förslagsvis använder ni Initial vid en första migration.
Därefter kör vi direkt Update-Database kommandot för att uppdatera och skapa vår databas.

####Skapa våra kontroller
Nu när vi har allt bakomliggande vi behöver så bör vi, innan vi skapar front-end, ha ett sätt att kommunicera mellan back-end och front-end, alltså en kontroller.
Högerklicka på Controllers-mappen
Välj Add-Controller
Välj  “MVC5 Controller with views using Entity Framework”
Välj er StockItem klass som modellklass
Välj er ItemContext som Contextklass
Controllern bör ha fått namnet StockItemsController.

###Ändra routing
Innan vi går in på det sista steget att börja skapa egna views genom Controllern. Så skall vi ändra routingen så att den faktiskt startar i vår egna controller och inte Home som tidigare.
Expandera mappen “App_Start”
Öppna .cs filen RouteConfig
I raden defaults: new {...} ändra “Controller = Home” till namnet för er Controller. Notera att ni inte har med ‘controller’ i namnet.

####Views
För att skapa egna views går ni till väga på följande sätt:
Gå till er Controller i koden.
På valfri plats, efter “public ActionResult Index (){...}” lägger ni till en egen ActionResult. “public ActionResult Test() { return View();} “
Högerclicka på Test och välj AddView
I wizzarden får ni en mängd val, välj det som passar, i detta fallet List.
Skriv in namnet på viewn och klicka på add. En .cshtml fil kommer genereras i views-mappen för controllern.
Skriv in en LINQ sats och skicka med till vyn som modell, exempelvis 
“var testmodel = db.items.Where(i => i.Name == “Potato”).ToList();
return View(testmodel);”
Gör om detta på lika olika vis för att skapa tre egna views, med olika LINQ-satser för att ge olika listor.

