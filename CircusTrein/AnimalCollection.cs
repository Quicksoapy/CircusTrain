namespace CircusTrein;

public class AnimalCollection
{
    public readonly List<Animal> LargeHerbivores = new();
    public readonly List<Animal> MediumHerbivores = new();
    public readonly List<Animal> SmallHerbivores = new();
    public readonly List<Animal> LargeCarnivores = new();
    public readonly List<Animal> MediumCarnivores = new();
    public readonly List<Animal> SmallCarnivores = new();

    public void AddAnimals(List<Animal> animals)
    {
        foreach (var animal in animals)
        {
            switch (animal.AnimalType, animal.AnimalSize)
            {
                case (AnimalType.Carnivore, AnimalSize.Large):
                    LargeCarnivores.Add(animal);
                    break;
                case (AnimalType.Carnivore, AnimalSize.Medium):
                    MediumCarnivores.Add(animal);
                    break;
                case (AnimalType.Carnivore, AnimalSize.Small):
                    SmallCarnivores.Add(animal);
                    break;
                case (AnimalType.Herbivore, AnimalSize.Large):
                    LargeHerbivores.Add(animal);
                    break;
                case (AnimalType.Herbivore, AnimalSize.Medium):
                    MediumHerbivores.Add(animal);
                    break;
                case (AnimalType.Herbivore, AnimalSize.Small):
                    SmallHerbivores.Add(animal);
                    break;
            }
        }
    }
}