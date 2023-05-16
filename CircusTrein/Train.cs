namespace CircusTrein;

public class Train
{
    private readonly List<Wagon> _train = new List<Wagon>();
    private readonly List<Animal> _carnivores = new List<Animal>();
    private readonly List<Animal> _largeHerbivores = new List<Animal>();
    private readonly List<Animal> _mediumHerbivores = new List<Animal>();
    private readonly List<Animal> _smallHerbivores = new List<Animal>();
    private int _smallHerbivoresCount = 0;
    private int _mediumHerbivoresCount = 0;
    
    public List<Wagon> Sort(List<Animal> animals)
    {
        var animalCollection = new AnimalCollection(animals);
        foreach (var animal in animalCollection.GetAllCarnivores())
        {
            _carnivores.Add(animal);
        }
        foreach (var animal in animalCollection.GetLargeHerbivores())
        {
            _largeHerbivores.Add(animal);
        }
        foreach (var animal in animalCollection.GetMediumHerbivores())
        {
            _mediumHerbivores.Add(animal);
        }
        foreach (var animal in animalCollection.GetSmallHerbivores())
        {
            _smallHerbivores.Add(animal);
        }

        foreach (var animal in _carnivores)
        {
            Wagon wagon = new Wagon();
            wagon.Animals.Add(animal);
            _train.Add(wagon);
        }

        //True => is even number, else is odd number
        if (_largeHerbivores.Count % 2 == 0)
        {
            for (int i = 0; i < _largeHerbivores.Count/2; i++)
            {
                Wagon wagon = new Wagon();
                wagon.Animals.Add(_largeHerbivores[i]);
                wagon.Animals.Add(_largeHerbivores[i + 1]);
                wagon.Points -= 10;
                _train.Add(wagon);
            }
        }
        else
        {
            Wagon wagonOdd = new Wagon();
            wagonOdd.Animals.Add(_largeHerbivores[0]);
            wagonOdd.Animals.Add(_mediumHerbivores[0]);
            wagonOdd.Animals.Add(_smallHerbivores[0]);
            wagonOdd.Animals.Add(_smallHerbivores[1]);
            wagonOdd.Points -= 10;
            _train.Add(wagonOdd);
            
            for (int i = 1; i < _largeHerbivores.Count/2; i++)
            {
                Wagon wagon = new Wagon();
                wagon.Animals.Add(_largeHerbivores[i]);
                wagon.Animals.Add(_largeHerbivores[i + 1]);
                wagon.Points -= 10;
                _train.Add(wagon);
            }
        }

        if (_mediumHerbivoresCount < _mediumHerbivores.Count && _mediumHerbivores.Count < 2)
        {
            Wagon extraWagonMedium = new Wagon();
            for (int i = _mediumHerbivoresCount; i < _mediumHerbivores.Count; i++)
            {
                extraWagonMedium.Animals.Add(_mediumHerbivores[i]);
                _mediumHerbivoresCount += 1;
            }
            
            for (int i = extraWagonMedium.Points; i < 10; i++)
            {
                extraWagonMedium.Animals.Add(_smallHerbivores[_smallHerbivoresCount]);
                _smallHerbivoresCount += 1;
            }
            _train.Add(extraWagonMedium);
        }

        for (int i = 0; i < _mediumHerbivores.Count/3; i++)
        {
            Wagon wagon = new Wagon();
            wagon.Animals.Add(_mediumHerbivores[i]);
            wagon.Animals.Add(_mediumHerbivores[i + 1]);
            wagon.Animals.Add(_mediumHerbivores[i + 2]);
            _mediumHerbivoresCount += 3;
            
            wagon.Animals.Add(_smallHerbivores[_smallHerbivoresCount]);
            _smallHerbivoresCount += 1;
            _train.Add(wagon);
        }

        for (int i = _smallHerbivoresCount; i < _smallHerbivores.Count; i++)
        {
            if (_smallHerbivores.Count - _smallHerbivoresCount < 10)
            {
                Wagon wagon = new Wagon();
                for (int n = 0; n < 10; n++)
                {
                    wagon.Animals.Add(_smallHerbivores[i]);  
                }
                _train.Add(wagon);
            }
            else
            {
                Wagon wagon = new Wagon();
                for (int n = 0; n < _smallHerbivores.Count - _smallHerbivoresCount; n++)
                {
                    wagon.Animals.Add(_smallHerbivores[i]);  
                }
                _train.Add(wagon);
            }
        }

        return _train;
    }
}