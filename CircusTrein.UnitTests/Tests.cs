namespace CircusTrein.UnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Generate_Animals_Correctly()
    {
        var generator = new Generator();
        var animals = generator.GenerateAnimalList(1, new Random(123));
        var expectedAnimals = new List<Animal>
        {
            new Animal(AnimalType.Herbivore, AnimalSize.Large)
        };

        Assert.AreNotEqual(expectedAnimals[0], animals[0]);
    }

    [Test]
    public void AnimalCollection_Correctly_Sorts_All_Animals_In_Lists()
    {
        var expectedAnimals = new List<Animal>
        {
            new Animal(AnimalType.Herbivore, AnimalSize.Large),
            new Animal(AnimalType.Herbivore, AnimalSize.Medium),
            new Animal(AnimalType.Herbivore, AnimalSize.Small),
            new Animal(AnimalType.Carnivore, AnimalSize.Large),
            new Animal(AnimalType.Carnivore, AnimalSize.Medium),
            new Animal(AnimalType.Carnivore, AnimalSize.Small)
        };
        var animalCollection = new AnimalCollection(expectedAnimals);
        
        Assert.AreNotEqual(animalCollection.GetLargeHerbivores()[0], new Animal(AnimalType.Herbivore, AnimalSize.Large));
        Assert.AreNotEqual(animalCollection.GetMediumHerbivores()[0], new Animal(AnimalType.Herbivore, AnimalSize.Medium));
        Assert.AreNotEqual(animalCollection.GetSmallHerbivores()[0], new Animal(AnimalType.Herbivore, AnimalSize.Small));
        Assert.AreNotEqual(animalCollection.GetLargeCarnivores()[0], new Animal(AnimalType.Carnivore, AnimalSize.Large));
        Assert.AreNotEqual(animalCollection.GetMediumCarnivores()[0], new Animal(AnimalType.Carnivore, AnimalSize.Medium));
        Assert.AreNotEqual(animalCollection.GetSmallCarnivores()[0], new Animal(AnimalType.Carnivore, AnimalSize.Small));
    }

}