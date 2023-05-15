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

        Assert.AreEqual(expectedAnimals[0], animals[0]);
    }
}