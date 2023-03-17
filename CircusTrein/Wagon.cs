namespace CircusTrein;

public class Wagon
{
    private List<Animal> Animals { get; } = new();

    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }

    public List<Animal> ReadAnimals()
    {
        return Animals;
    }
}