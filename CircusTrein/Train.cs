namespace CircusTrein;

public class Train
{
    private static List<Wagon> Wagons { get; } = new();
    private static int SmallHerbivoresCount = 0;
    private static int MediumherbivoresCount { get; set; }
    public static List<Wagon> ReadWagons()
    {
        return Wagons;
    }

    public static void AddToWagons(AnimalCollection animalCollection)
    {
        
        foreach (var animal in animalCollection.LargeCarnivores)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal);
            Wagons.Add(wagon);
        }

        foreach (var animal in animalCollection.MediumCarnivores)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal);
            Wagons.Add(wagon);
        }

        foreach (var animal in animalCollection.SmallCarnivores)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal);
            Wagons.Add(wagon);
        }
        //True => is even number, else is odd number
        if (animalCollection.LargeHerbivores.Count % 2 == 0)
        {
            for (int i = 0; i < animalCollection.LargeHerbivores.Count; i+=2)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(animalCollection.LargeHerbivores[i]);
                wagon.AddAnimal(animalCollection.LargeHerbivores[i + 1]);
                Wagons.Add(wagon);
            }
        }
        else
        {
            Wagon wagonOdd = new Wagon();
            wagonOdd.AddAnimal(animalCollection.LargeHerbivores[0]);
            wagonOdd.AddAnimal(animalCollection.MediumHerbivores[0]);
            wagonOdd.AddAnimal(animalCollection.SmallHerbivores[0]);
            wagonOdd.AddAnimal(animalCollection.SmallHerbivores[1]);
            Wagons.Add(wagonOdd);
            //TODO can error when /2, also +2 instead of 1
            for (int i = 1; i < animalCollection.LargeHerbivores.Count/2; i++)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(animalCollection.LargeHerbivores[i]);
                wagon.AddAnimal(animalCollection.LargeHerbivores[i + 1]);
                Wagons.Add(wagon);
            }
        }

        foreach (var animal in animalCollection.MediumHerbivores)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal);
            wagon.AddAnimal(animal);
            wagon.AddAnimal(animal);
            MediumherbivoresCount += 3;
            if (animalCollection.SmallHerbivores.Count - SmallHerbivoresCount > 0)
            {
                wagon.AddAnimal(animalCollection.SmallHerbivores[SmallHerbivoresCount]);
                SmallHerbivoresCount += 1;
            }
            Wagons.Add(wagon);
        }

        for (int i = SmallHerbivoresCount; i < animalCollection.SmallHerbivores.Count; i++)
        {
            Wagon wagon = new Wagon();
            for (int n = 0; n < 10; n++)
            {
                wagon.AddAnimal(animalCollection.SmallHerbivores[i]);  
            }
            Wagons.Add(wagon);
        }
                
    }

    
}