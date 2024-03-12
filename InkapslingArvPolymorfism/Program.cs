// See https://aka.ms/new-console-template for more information

// Inkaspling:
try
{
    /* Person person = new Person 
    {
        Age = 1,
        FName = "Sven",
        LName = "Svensson",
        Height = 170,
        Weight = 80,
    };*/
    PersonHandler handler = new PersonHandler();
    Person person1 = handler.CreatePerson(55, "Anders", "Andersson", 170, 55);
    Console.WriteLine("Created person1:");
    Console.WriteLine($"{person1.FName} {person1.LName}, age: {person1.Age}, height: {person1.Height}, weight: {person1.Weight}");
    Console.WriteLine("SetAge person1:");
    handler.SetAge(person1, 65);
    Console.WriteLine($"{person1.FName} {person1.LName}, age: {person1.Age}, height: {person1.Height}, weight: {person1.Weight}");
    Person person2 = handler.CreatePerson(50, "Sven", "Karlsson", 180, 90);
    Console.WriteLine("Created person2:");
    Console.WriteLine($"{person2.FName} {person2.LName}, age: {person2.Age}, height: {person2.Height}, weight: {person2.Weight}");
    Console.WriteLine("ChangeName person2:");
    handler.ChangeName(person2, "Karl", "Svensson"); 
    Console.WriteLine($"{person2.FName} {person2.LName}, age: {person2.Age}, height: {person2.Height}, weight: {person2.Weight}");
   
    // Polymorfism:
    
    List<UserError> errors = new List<UserError>
        {
            new NumericInputError(),
            new TextInputError(),
            new ProfanityInputError(),
            new NoInputError(),
            new RedundantUserErrorMessageError()
        };
    Console.WriteLine("\nUserErrors:");
    foreach (var error in errors)
    {
        Console.WriteLine(error.UEMessage());
    }
    
    // Arv + mer polymorfism:
    var animals = new List<Animal>
    {
        new Horse("Polle", 10, 200),
        new Pelican("Pelle", 5, 3),
        new Bird("Pippi Flyglös", 5, 1, false),
        new Hedgehog("Mister Tagg", 5, 1, 5000),
        new Dog("Doris", 4, 5),
        new Wolfman("Wolverine", 50, 300),
    };

    Console.WriteLine("\nAnimals:");
    foreach (var animal in animals)
    {
        Console.WriteLine($"Name: {animal.Name}, Type: {animal.GetType()}, Age: {animal.Age}, Weight: {animal.Weight}");
        Console.Write("Sound:");
        animal.DoSound();
        
        // Safe cast:
        if (animal is IPerson animalCastedToIPerson)
        {
            Console.WriteLine($"Person detected of type: {animal.GetType()}");
            Console.Write("It speaks: ");
            animalCastedToIPerson.Talk();
        }
    }


    var dogs = new List<Dog>
    {
        new Dog("Fido", 4, 10),
        new Dog("Svante", 3, 5),
        // 3.4.9: Detta fungerar ej då arv endast fungerar uppåt i hirearkien inte parallellt:
        // new Horse("Polle", 10, 200) 
        // 3.4.10: Listan behöver vara av typen Animal alternativt en Interfacetyp som samtliga djur implementerar.
    };

    Console.WriteLine("\nStats() for animals:");
    foreach (var animal in animals)
    {
        // 3.4.13: Här skriver vi ut varje animals Stats. Jag valde att göra en generell metod i Animal som använder reflection
        // hade också kunnat göra overrides i varje klass men det hade inneburit mycket repeterande kod.
        Console.WriteLine($"Name:{animal.Name}, Type: {animal.GetType()}, {animal.Stats()}");
    }

    foreach (var animal in animals)
    {
        // Console.WriteLine(animal.DogString()); fungerar ej F17: Kommer endast åt metoder tillgängliga för samtliga Animals här
        if (animal.GetType() == typeof(Dog))
        {
            // Console.WriteLine(animal.DogString()); 3.4.17: Detta fungerar ej då type är Animal och endast metoder gemensamma 
            // för samtlig Animals går att använda.
            Console.WriteLine("Stats for dogs only:");
            Console.WriteLine(animal.Stats());
            // 3.4.18: Unsafe cast fungerar bra här då vi redan gjort en check i ifsatsen ovan och vet att animal är Dog
            Dog animalDog = (Dog)animal;
            Console.WriteLine(animalDog.DogString());
        }
    }
}
catch (ArgumentException exception)
{
    Console.WriteLine(exception.Message);
}

