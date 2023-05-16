namespace CircusTrein;

public class AnimalCollection
{
    private readonly List<Animal> _largeHerbivores = new();
    private readonly List<Animal> _mediumHerbivores = new();
    private readonly List<Animal> _smallHerbivores = new();
    private readonly List<Animal> _largeCarnivores = new();
    private readonly List<Animal> _mediumCarnivores = new();
    private readonly List<Animal> _smallCarnivores = new();
    private readonly List<Animal> _allCarnivores = new();
    
    public AnimalCollection(List<Animal> animals)
    {
        foreach (var animal in animals)
        {
            switch (animal.AnimalType, animal.AnimalSize)
            {
                case (AnimalType.Carnivore, AnimalSize.Large):
                    _largeCarnivores.Add(animal);
                    _allCarnivores.Add(animal);
                    break;
                case (AnimalType.Carnivore, AnimalSize.Medium):
                    _mediumCarnivores.Add(animal);
                    _allCarnivores.Add(animal);
                    break;
                case (AnimalType.Carnivore, AnimalSize.Small):
                    _smallCarnivores.Add(animal);
                    _allCarnivores.Add(animal);
                    break;
                case (AnimalType.Herbivore, AnimalSize.Large):
                    _largeHerbivores.Add(animal);
                    break;
                case (AnimalType.Herbivore, AnimalSize.Medium):
                    _mediumHerbivores.Add(animal);
                    break;
                case (AnimalType.Herbivore, AnimalSize.Small):
                    _smallHerbivores.Add(animal);
                    break;
            }
        }
    }

    public List<Animal> GetLargeHerbivores()
    {
        return _largeHerbivores;
    }
    public List<Animal> GetMediumHerbivores()
    {
        return _mediumHerbivores;
    }
    public List<Animal> GetSmallHerbivores()
    {
        return _smallHerbivores;
    }
    public List<Animal> GetAllCarnivores()
    {
        return _allCarnivores;
    }
    public List<Animal> GetLargeCarnivores()
    {
        return _largeCarnivores;
    }
    public List<Animal> GetMediumCarnivores()
    {
        return _mediumCarnivores;
    }
    public List<Animal> GetSmallCarnivores()
    {
        return _smallCarnivores;
    }

    

}