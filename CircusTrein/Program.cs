using CircusTrein;

Train train = new Train();
int smallHerbivoresCount = 0;
int mediumherbivoresCount = 0;

AnimalCollection animalCollection = new AnimalCollection();
animalCollection.AddAnimals(GenerateAnimalList(100));



int wagonCount = 1;
foreach (var wagon in train)
{
    Console.WriteLine("Wagon number: " + wagonCount);
    foreach (var animal in wagon.Animals) 
    {
        Console.WriteLine(animal.AnimalSize + " " + animal.AnimalType);
    }

    wagonCount += 1;
}

Console.WriteLine("Wagons: " + train.Count);


List<Animal> GenerateAnimalList(int iterations)
{
    Random rand = new Random();
    List<Animal> output = new List<Animal>();
    for (int i = 0; i < iterations; i++)
    {
        AnimalType[] animalTypes = (AnimalType[])Enum.GetValuesAsUnderlyingType(typeof(AnimalType));
        AnimalSize[] animalSizes = (AnimalSize[])Enum.GetValuesAsUnderlyingType(typeof(AnimalSize));

        output.Add(new Animal(animalTypes[rand.Next(0, 2)], animalSizes[rand.Next(0, 3)]));
    }
    return output;
}