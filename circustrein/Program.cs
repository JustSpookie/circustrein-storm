using circustrein;

Random rand = new Random();
List<dier> alle_dieren = new List<dier>();
List<dier> le_dieren = new List<dier>();
List<dier> le_dieren1 = new List<dier>();
List<wagon> circustrein = new List<wagon>();
int i = 1;


/// <summary>
/// Maakt een willekeurige lijst met dieren
/// Die later gebruikt wordt voor het sorteren
/// </summary>
void maak_dieren()
{
    for (int i = 1; i <= (int)rand.Next(10, 100); i++)
    {
        int grote1 = rand.Next(1, 4);
        int grote = 0;
        if(grote1 == 1)
        {
            grote = 1;
        }
        if(grote1 == 2)
        {
            grote = 3;
        }
        if(grote1 == 3)
        {
            grote = 5;
        }
        bool carnivoor = false;
        int Carnivoor = rand.Next(1,3);
        if(Carnivoor == 1)
        {
            carnivoor = true;
        }
        alle_dieren.Add(new dier(i, grote, carnivoor));
    }
}

/// <summary>
/// Dit is de eerste methode die dieren sorteert
/// Heb daarna een nieuwe methode gemaakt die beter werkt
/// Deze methode controlleert de dieren
/// Door een nieuwe wagon te maken en dan daar zoveel dieren mogelijk in te doen
/// En als er geen dieren meer in kunnen er dan meer dieren in te doen
/// </summary>
void sortdieren()
{
    foreach(dier dier in alle_dieren)
    {
        le_dieren.Add(dier);
    }
    while(le_dieren.Count > 0)
    {
        wagon wagon = new wagon();
        foreach (dier dier in le_dieren)
        {

            bool kantoevoegn = wagon.kan_toevoegen(dier);
            if (kantoevoegn)
            {
                wagon.kan_toevoegen(dier);
            }
        }
        List<dier> wagondieren = new List<dier>();
        wagondieren = wagon.getdieren();
        foreach (dier dier in wagondieren)
        {
            le_dieren.Remove(dier);
        }
        circustrein.Add(wagon);
    }

}

/// <summary>
/// Dit sorteert dieren
/// Dit doet die door bij elk dier door alle wagons heen te gaan te gaan
/// Als het dier in een wagon kan doet die hem erin en gaat die door naar het volgende dier
/// Als een dier niet in een enkele wagon kan dan maakt die een nieuw wagon en doet hem er daar in
/// </summary>
void sortdieren1()
{
    foreach(dier dieren in alle_dieren)
    {
        bool placed = false;
        foreach (wagon wagon in circustrein)
        {
            if (!placed && wagon.kan_toevoegen(dieren))
            {
                placed = true;
            }
        }
        if (!placed)
        {
            circustrein.Add(new wagon());
            if(!circustrein[circustrein.Count - 1].kan_toevoegen(dieren))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ER IS IETS FOUT");
                Console.BackgroundColor = ConsoleColor.Black;
                Environment.Exit(0);

                
            }
        }
    }
}

/// <summary>
/// Print de lijst met ongesorteerde en daarna de lijst met wagonnen en dieren die erin zitten
/// Hoe doet dit in het console en in een kladblok bestand
/// </summary>
void PrintAnimals()
{
    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string path = desktopPath + @"\circustrein" + ".txt";

    using (StreamWriter sw = File.CreateText(path))
    {
        sw.WriteLine("Dieren: ");
        sw.WriteLine("------------------------------------------------------------------");
        Console.WriteLine("Dieren: ");
        Console.WriteLine("------------------------------------------------------------------");
        foreach (dier dieren in alle_dieren)
        {
            Console.WriteLine("id: " + dieren.naam + " grootte: " + dieren.grootte + " carnivoor: " + dieren.carnivoor);

            sw.WriteLine("id: " + dieren.naam + " grootte: " + dieren.grootte + " carnivoor: " + dieren.carnivoor);
        }
        sw.WriteLine("\n");
        Console.WriteLine("\n");

        sw.WriteLine("dieren in wagons: ");
        sw.WriteLine("------------------------------------------------------------------");
        Console.WriteLine("dieren in wagons: ");
        Console.WriteLine("------------------------------------------------------------------");



        foreach (wagon wagon in circustrein)
        {
            sw.WriteLine("wagon: " + i);
            Console.WriteLine("wagon: " + i);
            foreach (dier dier in wagon.getdieren())
            {
                sw.WriteLine("id: " + dier.naam + " carnivoor: " + dier.carnivoor + " grote: " + dier.grootte);
                Console.WriteLine("id: " + dier.naam + " carnivoor: " + dier.carnivoor + " grote: " + dier.grootte);


            }
            i++;
            sw.WriteLine("\n");
            Console.WriteLine("\n");
        }
    }
}

maak_dieren();
sortdieren1();
PrintAnimals();