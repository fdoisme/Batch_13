// See https://aka.ms/new-console-template for more information

// Implementasi struct yang mengimplementasikan interface
// Ketika polymorphism digunakan pada struct maka akan kembali menjadi reference type
using System.Collections;
using System.Text.Json;

ILength len = new Vector2D { X = 3, Y = 4 };
Console.WriteLine(len.GetLength());
ILength len2 = len;
Vector2D len3 = (Vector2D)len;
len2.SetLength(1, 2);
len3.X = 5;
Console.WriteLine(len.GetLength());
Console.WriteLine(len2.GetLength());
Console.WriteLine(len3.GetLength());


// Generics
ArrayList list = new ArrayList();
list.Add(5);
list.Add("Hello");
list.Add(len3);
// Console.WriteLine(list.Count);
Console.WriteLine(JsonSerializer.Serialize(list));
for (int i = 0; i < list.Count; i++)
{
    // int x = (int)list[i];
    // Console.WriteLine(x);
}
List<Vector2D> list2 = new List<Vector2D>();
list2.Add((Vector2D)len);
list2.Add((Vector2D)len2);
list2.Add(len3);
for (int i = 0; i < list.Count; i++)
{
    Vector2D x = (Vector2D)list2[i];
    Console.WriteLine(JsonSerializer.Serialize(x));
}

BorderSide side = BorderSide.Left;
Console.WriteLine(side);
Console.WriteLine(side.ToString()+ " " + side.GetType());
byte b = (byte)BorderSide.Right;
Console.WriteLine(b);
BorderSide side2 = (BorderSide)2;
Console.WriteLine(side2);
public enum BorderSide : byte
{
    Left,
    Right,
    Top,
    Bottom
}
interface ILength
{
    void SetLength(double x, double y);
    string GetLength();
}
struct Vector2D : ILength
{
    public double X{get; set;}
    public double Y{get; set;}

    public string GetLength()
    {
        return "X: " + X + ", Y: " + Y;
    }

    public void SetLength(double x, double y)
    {
        X = x;
        Y = y;
    }
}
