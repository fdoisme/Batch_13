// See https://aka.ms/new-console-template for more information
Transportation mobil = new Transportation(1990, "Volkswagen");

public class Transportation
{
    private int _age;
    private string _brand;
    // public Transportation(){}
    // public Transportation(int age)
    // {
    //     Age = age;
    // }

    public Transportation(int age, string brand)
    {
        Console.WriteLine("Constructor "+" "+age+" "+brand +" "+_age+" "+_brand);
        _age = age;
        _brand = brand;
        Console.WriteLine("Constructor "+" "+age+" "+brand +" "+_age+" "+_brand);
        // Age = age;
        // Brand = brand;
    }
    
}