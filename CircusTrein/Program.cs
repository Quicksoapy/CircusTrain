using CircusTrein;

int wagonCount = 1;
var generator = new Generator();

var animals = generator.GenerateAnimalList(100, new Random());
var sorter = new Sorter();
var train = sorter.Sort(animals);

foreach (var wagon in train)
{
    string output = "Wagon number " + wagonCount + ": ";
    foreach (var animal in wagon.Animals)
    {
        output += animal.AnimalSize + " " + animal.AnimalType + " // ";
    }
    Console.WriteLine(output);
    wagonCount += 1;
}

Console.WriteLine("\nAmount of wagons: " + train.Count);
