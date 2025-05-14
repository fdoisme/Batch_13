// See https://aka.ms/new-console-template for more information

/* 
Top Level Statement
Semua top-level statements harus muncul sebelum deklarasi namespace, class, struct, atau interface.
*/
// Implement SOLID, OOP

Transportation mobil = new Transportation(1990, "Volkswagen");
// Transportation mobil1 = new Transportation();
// Transportation perahu = new Transportation(1990);
// Transportation perahu1 = new Transportation();
Transportation angkutanUmum = new Public(1994, "Mitsubishi", 5000);
Transportation mobil2 = new Transportation{Age = 2005, Brand = "Toyota"};
Transportation mobil3 = new Private(2025, "Mustang", "Fernando");
Private myCar = (Private)mobil3;
Public angkutanUmum1 = (Public)angkutanUmum;

Console.WriteLine(mobil.Age);
Console.WriteLine(mobil.Brand);
Console.WriteLine(mobil2.Age);
Console.WriteLine(mobil2.Brand);
// mobil.Age = 2000;
Console.WriteLine(mobil.Age +"\t"+ mobil.Brand);
// Console.WriteLine(perahu.Age);
// Console.WriteLine(perahu.Brand);
// perahu.Brand = "Yacht";
Console.WriteLine(angkutanUmum);
Console.WriteLine(angkutanUmum.Age);
Console.WriteLine(angkutanUmum.Brand);
Console.WriteLine(angkutanUmum1.Price);
Console.WriteLine(angkutanUmum1.Brand);
Console.WriteLine(myCar.GetOwner());
Console.WriteLine(myCar.Age);
Console.WriteLine(myCar.Brand);
// Console.WriteLine(perahu.Brand);
Console.WriteLine("End Of Program");
public class Transportation
{
    private int _age;
    private string _brand;
    public Transportation(){}
    public Transportation(int age)
    {
        Age = age;
    }

    public Transportation(int age, string brand)
    {
        Console.WriteLine("Constructor "+" "+age+" "+brand +" "+_age+" "+_brand);
        // _age = age;
        // _brand = brand;
        Age = age;
        Brand = brand;
    }
    
    public int Age{get;  set;}
    public string Brand{get;  set;}
}

public class @Public:Transportation{
    private int _price;
    public int Price{get;set;}
    public Public(int age, string brand, int price): base(age, brand){
        Price = price;
    }
}
public class @Private:Transportation{
    private string _owner;

    public Private(int age, string brand, string owner): base(age,brand){
        _owner = owner;
    }
    public string GetOwner(){return _owner;}
    public void SetOwner(string owner){_owner = owner;}
}

