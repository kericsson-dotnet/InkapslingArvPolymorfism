class PersonHandler
{
    public void SetAge(Person pers, int age)
    {
        pers.Age = age;
    }
    public Person CreatePerson(int age, string fname, string lname, int height, int weight)
    {
        return new Person
        {
            Age = age,
            FName = fname,
            LName = lname,
            Height = height,
            Weight = weight
        };
    }
    
    public void SetWeight(Person pers, int weight)
    {
        pers.Weight = weight;
    }
    
    public void ChangeName(Person pers, string fname, string lname)
    {
        pers.FName = fname;
        pers.LName = lname;
    }
}
