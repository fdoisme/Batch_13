// See https://aka.ms/new-console-template for more information
using System;
using System.Text.Json;
// Passing by reference menggunakan class (mutable)
// Passing by value menggunakan struct (immutable)
PersonClass c = new PersonClass { Name = "PersonClass" };
Utils.Rename(c);
Console.WriteLine("Class name: " + c.Name);
PersonStruct s = new PersonStruct { Name = "PersonStruct" };
Utils.Rename(s);
Console.WriteLine("Struct name: " + s.Name);


// ENUM
Bank mandiri = Bank.Mandiri;
Console.WriteLine((int)mandiri);
int num = 77;
Bank bank = (Bank)num;
Bank bank2 = (Bank)99;
Console.WriteLine(bank + " " + bank.GetType());
Console.WriteLine(bank2 + " " + bank2.GetType());
Console.WriteLine(Enum.IsDefined(typeof(Bank), bank2) + " " + bank2.GetType());


// GENERICS
Treasury myWealth = new Treasury();
List<Inventory> myInventory = new List<Inventory>{};
Inventory goods = new Inventory{Id=1, Name="Laptop", Qty=2};
Inventory goods2 = new Inventory{Id=2, Name="Motorcycle", Qty=2};
myInventory.Add(goods);
myInventory.Add(goods2);
Transaction Setor = new Transaction{Debet=7_000_000};
Transaction Tarik = new Transaction{Credit=1_000_000};
Console.WriteLine("Wealth : " + JsonSerializer.Serialize(myWealth));
Console.WriteLine("Inventory : " + JsonSerializer.Serialize(myInventory));
myWealth.Add(Setor);
myWealth.Subtract(Tarik);
goods.Add(1);
goods2.Subtract(1);
Console.WriteLine("Wealth : " + JsonSerializer.Serialize(myWealth));
Console.WriteLine("Inventory : " + JsonSerializer.Serialize(myInventory));

public class @Utils{
    public static void Rename(PersonClass person) {
        person.Rename("PersonClass_Rename");
    }
    public static void Rename(PersonStruct person) {
        person.Rename("PeronStruct_Rename");
    }
}


public interface IRename
{
    void Rename(string newName);
}
public class PersonClass:IRename {
    public string Name = String.Empty;
    public void Rename(string newName)=>Name = newName;
}
public struct PersonStruct:IRename {
    public string Name;
    public void Rename(string newName)=>Name = newName;
}

// [Flags]
public enum Bank
{
    BCA = 1,
    Mandiri = 77,
    CIMB = 3,
}

public class Student<T>
{
    public T data;
    public Student(T data)
    {
        this.data = data;
        Console.WriteLine("Data passed: " + this.data);
    }
}

public interface IService<T>{
    void Add (T entity);
    void Subtract (T entity);
}
public class Treasury:IService<Transaction>{
    public double Balance{get;set;}
    public void Add(Transaction entity)
    {
        Balance += entity.Debet;
    }

    public void Subtract(Transaction entity)
    {
        Balance -= entity.Credit;
    }
}

public class Inventory: IService<int>{
    public int Id{get;set;}
    public string Name{get;set;} = String.Empty;
    public int Qty{get;set;}

    public void Add(int qty)
    {
        Qty += qty;
    }

    public void Subtract(int qty)
    {
        Qty -= qty;
    }
}
public class Transaction{
    public double Debet{get;set;}
    public double Credit{get;set;}
}