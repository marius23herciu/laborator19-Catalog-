// See https://aka.ms/new-console-template for more information


using laborator19_Catalog_.Models;


/*
 Exercitiul 1
• Student este caracterizat de urmatoarele
• Nume
• Prenume
• Varsta
• Adresa

• Adresa este caracterizata de
• Oras:string
• Strada
• Numar

• Creeati un proiect de tip asp.net web api
• Creeati modelul, populati DB
• Adaugati PK, FK precum si relatiile necesare
• Adaugati controllerul necesar (vedeti slide-ul urmator)

• Adaugati endpoint-uri pentru
• Obtinerea tuturor studentilor
• Obtinerea unui student dupa ID
• Creeare student
• Stergere student
• Modificare date student
• Modificare adresa student
      • In cazul in care studentul nu are adresa, aceasta va fi creeata
• Stergerea unui student
      • Cu un parametru care va specifica daca adresa este la randul ei
stearsa


• Suplimentar
• Adaugati XML comments pentru endpoint-urile create
• Folositi “Enable xml comments in swagger”
• Folositi DTO-uri.
• Folositi extension methods pentru a creea dto-uri

 */


SeedDb();

 static void SeedDb()
{
    using var ctx = new CatalogueDbContext();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();


    if (ctx.Students.Count() != 0)
    {
        return;
    }

    ctx.Students.Add(new Student
    {
        FirstName = "Ionut",
        LastName = "Antonescu",
        Age = 20,
        Adresse=new Adresse
        {
            City="Bucuresti",
            Street="Obor",
            Number=12
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Ioana",
        LastName = "Popescu",
        Age = 20,
        Adresse = new Adresse
        {
            City = "Bucuresti",
            Street = "Mare",
            Number = 85
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Dan",
        LastName = "Bitman",
        Age = 45,
        Adresse = new Adresse
        {
            City = "Bucuresti",
            Street = "Revolutiei",
            Number = 44
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Crina",
        LastName = "Manea",
        Age = 30,
        Adresse = new Adresse
        {
            City = "Iasi",
            Street = "Pacurari",
            Number = 56
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "George",
        LastName = "Trifan",
        Age = 22,
        Adresse = new Adresse
        {
            City = "Timisoara",
            Street = "Bega",
            Number = 25
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Paul",
        LastName = "Dobre",
        Age = 18,
        Adresse = new Adresse
        {
            City = "Arad",
            Street = "Viilor",
            Number = 64
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Diana",
        LastName = "Velescu",
        Age = 25,
        Adresse = new Adresse
        {
            City = "Ramnicu Valcea",
            Street = "Oltulu",
            Number = 17
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "John",
        LastName = "Carpenter",
        Age = 21,
        Adresse = new Adresse
        {
            City = "Newcastle",
            Street = "Harbour",
            Number = 78
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Ionut",
        LastName = "Antonescu",
        Age = 22,
        Adresse = new Adresse
        {
            City = "Paris",
            Street = "Lumiere",
            Number = 7
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Lucian",
        LastName = "Coman",
        Age = 31,
        Adresse = new Adresse
        {
            City = "Constanta",
            Street = "Portului",
            Number = 12
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Andreea",
        LastName = "Caliman",
        Age = 35,
        Adresse = new Adresse
        {
            City = "Galati",
            Street = "Dunarii",
            Number = 21
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "George",
        LastName = "Antonescu",
        Age = 20,
        Adresse = new Adresse
        {
            City = "Cluj",
            Street = "Transilvaniei",
            Number = 55
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Andreea",
        LastName = "Coman",
        Age = 18,
        Adresse = new Adresse
        {
            City = "Craiova",
            Street = "Universitatii",
            Number = 14
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Razvan",
        LastName = "Florea",
        Age = 25,
        Adresse = new Adresse
        {
            City = "Suceava",
            Street = "Bucovinei",
            Number = 78
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Gheorghe",
        LastName = "Gherghel",
        Age = 42,
        Adresse = new Adresse
        {
            City = "Madrid",
            Street = "Huevos",
            Number = 88
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Izabela",
        LastName = "Popa",
        Age = 21,
        Adresse = new Adresse
        {
            City = "Roma",
            Street = "Pizzeria",
            Number = 22
        }
    });

    ctx.Students.Add(new Student
    {
        FirstName = "Sebi",
        LastName = "Popa",
        Age = 21,
        Adresse = new Adresse
        {
            City = "Brasov",
            Street = "Cerbului",
            Number = 24
        }
    });


    ctx.SaveChanges();
}