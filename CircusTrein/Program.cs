using CircusTrein;

List<Wagon> train = new List<Wagon>();
List<Animal> Carnivores = new List<Animal>();
List<Animal> LargeHerbivores = new List<Animal>();
List<Animal> MediumHerbivores = new List<Animal>();
List<Animal> SmallHerbivores = new List<Animal>();
int SmallHerbivoresCount = 0;

var animals = GenerateAnimalList(100);

foreach (var animal in animals)
{
    if (animal.AnimalType == AnimalType.Carnivore)
    {
        Carnivores.Add(animal);
        continue;
    }

    switch (animal.AnimalSize)
    {
        case AnimalSize.Large:
            LargeHerbivores.Add(animal);
            break;
        case AnimalSize.Medium:
            MediumHerbivores.Add(animal);
            break;
        case AnimalSize.Small:
            SmallHerbivores.Add(animal);
            break;
    }
}

foreach (var animal in Carnivores)
{
    Wagon wagon = new Wagon();
    wagon.Animals.Add(animal);
    train.Add(wagon);
}
//True => is even number, else is odd number
if (LargeHerbivores.Count % 2 == 0)
{
    for (int i = 0; i < LargeHerbivores.Count/2; i++)
    {
        Wagon wagon = new Wagon();
        wagon.Animals.Add(LargeHerbivores[i]);
        wagon.Animals.Add(LargeHerbivores[i + 1]);
        train.Add(wagon);
    }
}
else
{
    Wagon wagonOdd = new Wagon();
    wagonOdd.Animals.Add(LargeHerbivores[0]);
    wagonOdd.Animals.Add(MediumHerbivores[0]);
    wagonOdd.Animals.Add(SmallHerbivores[0]);
    wagonOdd.Animals.Add(SmallHerbivores[1]);
    train.Add(wagonOdd);
    
    for (int i = 1; i < LargeHerbivores.Count/2; i++)
    {
        Wagon wagon = new Wagon();
        wagon.Animals.Add(LargeHerbivores[i]);
        wagon.Animals.Add(LargeHerbivores[i + 1]);
        train.Add(wagon);
    }
}

foreach (var animal in MediumHerbivores)
{
    Wagon wagon = new Wagon();
    wagon.Animals.Add(animal);
    wagon.Animals.Add(animal);
    wagon.Animals.Add(animal);
    wagon.Animals.Add(SmallHerbivores[SmallHerbivoresCount]);
    SmallHerbivoresCount += 1;
}
//TODO fix smallherbivores thing
for (int i = SmallHerbivoresCount; i < SmallHerbivores.Count; i++)
{
    if (SmallHerbivores.Count - SmallHerbivoresCount < 10)
    {
        Wagon wagon = new Wagon();
        for (int n = 0; n < SmallHerbivoresCount; n++)
        {
            wagon.Animals.Add(SmallHerbivores[i]);  
        }
    }
}

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