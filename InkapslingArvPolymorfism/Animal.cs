public abstract class Animal(string name, int age, int weight)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public int Weight { get; set; } = weight;

    public abstract void DoSound();

    // Testade lite reflection istället för att upprepa overwrites i varje klass.
    public string Stats(){
        var instanceProperties = this.GetType().GetProperties();
        var animalPropertyNames = new List<String>{"Name", "Weight", "Age"};
        var uniqueProperties = new List<string>();
        foreach (var property in instanceProperties)
        {
            // Lista alla properties som är unika, har såklart också möjligeheten att
            // bara lista samtliga attribut här också.
            if (!animalPropertyNames.Contains(property.Name))
            {
                uniqueProperties.Add(property.Name + ": " + property.GetValue(this));
            }
        }
        return $"Unique Properties: {string.Join(", ", uniqueProperties)}";
    }

}

public class Horse : Animal
{
    public Horse(string name, int age, int weight) : base(name, age, weight)
    {
        IsFast = true;
    }

    public bool IsFast { get; set; }

    public override void DoSound()
    {
        Console.WriteLine("Neigh!");
    }
}
public class Dog : Animal
{
    public Dog(string name, int age, int weight) : base(name, age, weight)
    {
        IsHungry = true;
    }

    public bool IsHungry { get; set; }

    public override void DoSound()
    {
        Console.WriteLine("Woof!");
    }

    public string DogString()
    {
        return "Dogstring!";
    }
}
public class Hedgehog : Animal
{
    public Hedgehog(string name, int age, int weight, int nrOfSpikes) : base(name, age, weight)
    {
        NrOfSpikes = nrOfSpikes;
    }

    public int NrOfSpikes { get; set; }

    public override void DoSound()
    {
        Console.WriteLine("Neigh!");
    }
}

public class Worm : Animal
{
    public Worm(string name, int age, int weight, bool isHiddenInSoil) : base(name, age, weight)
    {
        IsHiddenInSoil = true;
    }

    public bool IsHiddenInSoil { get; set; }

    public override void DoSound()
    {
        Console.WriteLine("Kind of noiseless...");
    }
}
public class Bird : Animal
{
    // Testar defaultvärden
    public Bird(string name, int age, int weight, bool canFly = true) : base(name, age, weight)
    {
        CanFly = canFly;
    }


    public bool CanFly { get; set; }
    
    // 3.3.13: Om alla fåglar behöver ett nytt attribut lägger man det lämpligen här i Birdklassen.
    // 3.3.14: Om alla djur behöver ett nytt attribut läggs det lämpligen i Animalklassen alternativt i ett
    // Interface som samtliga djur implementerar.
    public override void DoSound()
    {
        Console.WriteLine("Tweet!");
    }
}
public class Pelican : Bird
{
    public Pelican(string name, int age, int weight, bool canFly = true, bool bigBeak = true) : base(name, age, weight, canFly)
    {
        BigBeak = bigBeak;
    }

    public bool BigBeak { get; set; }
}

public class Flamingo : Bird
{
    public Flamingo(string name, int age, int weight, bool canFly = true, bool isPink = true) : base(name, age, weight, canFly)
    {
        IsPink = isPink;
    }

    public bool IsPink { get; set; }
}

public class Swan : Bird
{
    public Swan(string name, int age, int weight, bool canFly = true, bool isAggressiveSometimes = true) : base(name, age, weight, canFly)
    {
        IsAggressiveSometimes = isAggressiveSometimes;
    }

    public bool IsAggressiveSometimes { get; set; }
}

public class Wolf : Animal
{
    public Wolf(string name, int age, int weight) : base(name, age, weight)
    {
        EatsRaindeer = true;
    }

    public bool EatsRaindeer { get; set; }

    public override void DoSound()
    {
        Console.WriteLine("Howl!");
    }
}

public class Wolfman : Animal, IPerson
{
    public Wolfman(string name, int age, int weight) : base(name, age, weight)
    {
        EatsRaindeer = true;
    }

    public bool EatsRaindeer { get; set; }

    public override void DoSound()
    {
        Console.WriteLine("Howl!");
    }
    public void Talk()
    {
        Console.WriteLine("Howltalk!");
    }
}

public interface IPerson
{
    void Talk();
}
