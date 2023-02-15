using CircusTrein;

List<Wagon> Train = new List<Wagon>();

var animals = GenerateAnimalList(100);

foreach (var animal in animals)
{
    Wagon wagon = new Wagon();
    if (wagon.Points >= (int)animal.AnimalSize)
    {
        wagon.Animals.Add(animal);
        wagon.Points -= (int)animal.AnimalSize;
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

        Animal animal = new Animal(animalTypes[rand.Next(0,2)], animalSizes[rand.Next(0,3)]);
    }
    return output;
}