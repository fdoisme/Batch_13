// See https://aka.ms/new-console-template for more information
using System;

public class Program
{
    public delegate void MyDelegate(string message);
    public delegate string DIdentic1(int a, int b);
    public delegate string DIdentic2(int a, int b);

    public static void Main()
    {
        // DELEGATE
        // MyDelegate del = SayHello;
        // del += SayGoodbye;
        // del("Dunia");
        // Callback("Dunia", del);

        // Action<string> print = WithoutReturn;
        // print("Halo! Ini adalah contoh penggunaan delegate with ACTION.");
        // // Func<int, int, int> add = (a, b) => a + b;
        // Func<int, int, string> add = WithReturn;
        // Console.WriteLine("Halo! Ini adalah contoh penggunaan delegate with FUNC : " + add(3, 5));

        // DIdentic1 add1 = WithReturn;
        // DIdentic2 multiply = new DIdentic2(add1);
        // // DIdentic2 multiply = (DIdentic2)(Delegate)add1; //Error gabisa di cast
        // DIdentic2 multiply2 = (DIdentic2)Multiply;
        // DIdentic2 multiply3 = new DIdentic2(Multiply);
        // Console.WriteLine("Add1: " + add1(3, 5));
        // Console.WriteLine("Multiply: " + multiply(3, 5));
        // Console.WriteLine("Multiply: " + multiply2(3, 5));
        // Console.WriteLine("Multiply: " + multiply3(3, 5));
        // END DELEGATE

        // EVENT HANDLER
        Lampu lampu = new Lampu();
        lampu.LampuMenyala += OnLampuBalkon;
        lampu.LampuMenyala += OnLampuRTamu;
        lampu.NyalakanLampu();

        Stock stock = new Stock();
        stock.PriceChanged += (sender, e) =>
        {
            Console.WriteLine($"Price changed from {e.LastPrice} to {e.NewPrice}");
        };
        stock.Price = 100;
        stock.Price = 150;
        stock.Price = 150;
        // END EVENT HANDLER
    }
    public static void OnLampuBalkon(string message)
    {
        Console.WriteLine("Handler OnLampuBalkon: " + message);
    }
    public static void OnLampuRTamu(string message)
    {
        Console.WriteLine("Handler OnLampuRTamu: " + message);
    }
    public static string WithReturn(int a, int b)
    {
        Console.WriteLine("Add method called");
        return (a + b).ToString();
    }
    public static string Multiply(int a, int b)
    {
        Console.WriteLine("Multiply method called");
        return (a * b).ToString();
    }
    public static void WithoutReturn(string param)
    {
        Console.WriteLine(param);
    }


    public static void Callback(string msg, MyDelegate callback)
    {
        Console.WriteLine("Callback");
        callback(msg);
    }
    public static void SayHello(string msg)
    {
        Console.WriteLine("Hello: " + msg);
    }

    public static void SayGoodbye(string msg)
    {
        Console.WriteLine("Goodbye: " + msg);
    }
    
}
public class Lampu
{
    public delegate void LampuMenyalaEventHandler(string message);
    public event LampuMenyalaEventHandler LampuMenyala;
    public void NyalakanLampu()
    {
        Console.WriteLine("Lampu menyala!");
        LampuMenyala?.Invoke("Lampu sudah menyala!");
    }
}
// public class Lampu2 : EventArgs
// {
//     public string Message { get; set; }
//     public Lampu2(string message)
//     {
//         Message = message;
//     }
//     public delegate void LampuMenyalaEventHandler(string message);
//     // public EventArgs e = new Lampu2();
//     public event EventHandler<Lampu2> LampuMenyala;
//     public void NyalakanLampuArgs()
//     {
//         Console.WriteLine("Lampu menyala!");
//         LampuMenyala?.Invoke(this, ("Lampu sudah menyala!"));
//     }
// }


// public class EventLampuArgs : EventArgs
// {
//     public string Message { get; set; }
//     public EventLampuArgs(string message)
//     {
//         Message = message;
//     }
// }
public class PriceChangedEventArgs : EventArgs
{
    public decimal LastPrice { get; }
    public decimal NewPrice { get; }

    public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
    {
        LastPrice = lastPrice;
        NewPrice = newPrice;
    }
}
public class Stock
{
    private decimal price;
    public event EventHandler<PriceChangedEventArgs> PriceChanged;

    public decimal Price
    {
        get => price;
        set
        {
            if (price != value)
            {
                var oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
            else
            {
                Console.WriteLine("Price is the same, no change event triggered.");
            }
        }
    }

    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }
}