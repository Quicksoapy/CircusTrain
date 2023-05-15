namespace CircusTrein;

public class Generator
{
    public List<Animal> GenerateAnimalList(int iterations, Random rand)
    {
        List<Animal> output = new List<Animal>();
        for (int i = 0; i < iterations; i++)
        {
            AnimalType[] animalTypes = (AnimalType[])Enum.GetValuesAsUnderlyingType(typeof(AnimalType));
            AnimalSize[] animalSizes = (AnimalSize[])Enum.GetValuesAsUnderlyingType(typeof(AnimalSize));

            output.Add(new Animal(animalTypes[rand.Next(0, 2)], animalSizes[rand.Next(0, 3)]));
        }
        return output;
    }
}