public class Person
{
    private int age;
    private string fName;
    private string lName;
    private int height;
    private int weight;

    public int Age
    {
        get => age; set
        {
            if (value == 0)
            {
                throw new ArgumentException("Age must be more than 0");
            }
            age = value;
        }
    }
    public string FName
    {
        get => fName; set
        {
            if (value.Length < 2 || value.Length > 10)
                throw new ArgumentException("First name must be between 2 and 10 characters.");
            fName = value;
        }
    }
    public string LName
    {
        get => lName; set
        {
            if (value.Length < 3 || value.Length > 15)
                throw new ArgumentException("Last name must be between 3 and 15 characters.");
            lName = value;
        }
    }
    public int Height { get => height; set => height = value; }
    public int Weight { get => weight; set => weight = value; }

}
