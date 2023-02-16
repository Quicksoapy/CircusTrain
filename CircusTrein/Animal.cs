namespace CircusTrein;

public class Animal
{
    public Animal(AnimalType animalType, AnimalSize animalSize)
    {
        AnimalType = animalType;
        AnimalSize = animalSize;
    }

    public AnimalSize AnimalSize { get; }

    public AnimalType AnimalType { get; }

    public int AnimalSizeInt()
    {
        return (int)AnimalSize;
    }
}