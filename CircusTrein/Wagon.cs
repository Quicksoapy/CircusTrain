namespace CircusTrein;

public class Wagon
{
    public int Points { get; set; } = 10;

    public List<Animal> Animals { get; set; }

    public bool CheckPoints(Animal animal)
    {
        if (Points >= animal.AnimalSizeInt())
        {
            return true;
        }
        
        return false;
    }
}