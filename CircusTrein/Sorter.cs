namespace CircusTrein;

public class Sorter
{
    List<Wagon> train = new List<Wagon>();
    List<Animal> carnivores = new List<Animal>();
    List<Animal> largeHerbivores = new List<Animal>();
    List<Animal> mediumHerbivores = new List<Animal>();
    List<Animal> smallHerbivores = new List<Animal>();
    int smallHerbivoresCount = 0;
    int mediumHerbivoresCount = 0;
    
    public List<Wagon> Sort(List<Animal> animals)
    {
        foreach (var animal in animals)
        {
            if (animal.AnimalType == AnimalType.Carnivore)
            {
                carnivores.Add(animal);
                continue;
            }

            switch (animal.AnimalSize)
            {
                case AnimalSize.Large:
                    largeHerbivores.Add(animal);
                    break;
                case AnimalSize.Medium:
                    mediumHerbivores.Add(animal);
                    break;
                case AnimalSize.Small:
                    smallHerbivores.Add(animal);
                    break;
            }
        }

        foreach (var animal in carnivores)
        {
            Wagon wagon = new Wagon();
            wagon.Animals.Add(animal);
            train.Add(wagon);
        }

        //True => is even number, else is odd number
        if (largeHerbivores.Count % 2 == 0)
        {
            for (int i = 0; i < largeHerbivores.Count/2; i++)
            {
                Wagon wagon = new Wagon();
                wagon.Animals.Add(largeHerbivores[i]);
                wagon.Animals.Add(largeHerbivores[i + 1]);
                wagon.Points -= 10;
                train.Add(wagon);
            }
        }
        else
        {
            Wagon wagonOdd = new Wagon();
            wagonOdd.Animals.Add(largeHerbivores[0]);
            wagonOdd.Animals.Add(mediumHerbivores[0]);
            wagonOdd.Animals.Add(smallHerbivores[0]);
            wagonOdd.Animals.Add(smallHerbivores[1]);
            wagonOdd.Points -= 10;
            train.Add(wagonOdd);
            
            for (int i = 1; i < largeHerbivores.Count/2; i++)
            {
                Wagon wagon = new Wagon();
                wagon.Animals.Add(largeHerbivores[i]);
                wagon.Animals.Add(largeHerbivores[i + 1]);
                wagon.Points -= 10;
                train.Add(wagon);
            }
        }

        //TODO Fix medium herbivores stuff
        if (mediumHerbivoresCount < mediumHerbivores.Count && mediumHerbivores.Count < 2)
        {
            Wagon extraWagonMedium = new Wagon();
            for (int i = mediumHerbivoresCount; i < mediumHerbivores.Count; i++)
            {
                extraWagonMedium.Animals.Add(mediumHerbivores[i]);
                mediumHerbivoresCount += 1;
            }
            
            for (int i = extraWagonMedium.Points; i < 10; i++)
            {
                extraWagonMedium.Animals.Add(smallHerbivores[smallHerbivoresCount]);
                smallHerbivoresCount += 1;
            }
            train.Add(extraWagonMedium);
        }

        for (int i = 0; i < mediumHerbivores.Count/3; i++)
        {
            Wagon wagon = new Wagon();
            wagon.Animals.Add(mediumHerbivores[i]);
            wagon.Animals.Add(mediumHerbivores[i + 1]);
            wagon.Animals.Add(mediumHerbivores[i + 2]);
            mediumHerbivoresCount += 3;
            
            wagon.Animals.Add(smallHerbivores[smallHerbivoresCount]);
            smallHerbivoresCount += 1;
            train.Add(wagon);
        }

        for (int i = smallHerbivoresCount; i < smallHerbivores.Count; i++)
        {
            if (smallHerbivores.Count - smallHerbivoresCount < 10)
            {
                Wagon wagon = new Wagon();
                for (int n = 0; n < 10; n++)
                {
                    wagon.Animals.Add(smallHerbivores[i]);  
                }
                train.Add(wagon);
            }
            else
            {
                Wagon wagon = new Wagon();
                for (int n = 0; n < smallHerbivores.Count - smallHerbivoresCount; n++)
                {
                    wagon.Animals.Add(smallHerbivores[i]);  
                }
                train.Add(wagon);
            }
        }

        return train;
    }
}