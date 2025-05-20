// See https://aka.ms/new-console-template for more information
var enumerator = "Formulatrix".GetEnumerator();
Console.WriteLine(enumerator.GetType());
while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}
foreach (var item in Utils.Foo(false))
{
    Console.WriteLine($"Item : {item}");
}
// foreach (var number in Utils.GenerateNumbersWithDelay(5))
// {
//     Console.WriteLine($"Mengambil angka: {number}");
// }
int? x = 7;
Console.WriteLine(x.HasValue);

ComplexNumber c1 = new ComplexNumber(2, 3);
ComplexNumber c2 = new ComplexNumber(4, 5);

ComplexNumber resultComplexNumber = c1 + c2;
Console.WriteLine($"result operator overload : {resultComplexNumber}");
int retry = 3;
while (retry < 3)
{
    try
    {
        int rand = new Random().Next(0, 9);
        if (rand != 2)
        {
            Console.WriteLine("Nilai Random: " + rand);
            throw new CustomExceptionRandomError("Ini adalah pesan kesalahan kustom.", new Exception("Inner exception"));
        }
        Console.WriteLine("Nilai Random: " + rand);
        break;
    }
    catch (CustomExceptionRandomError ex)
    {
        retry++;
        if (retry < 3)
        {
            Console.WriteLine($"Error: {ex.Message}. Silakan coba lagi. Kesempatan tersisa: {3 - retry}");
        }
        else
        {
            Console.WriteLine("Kesempatan habis. Proses dihentikan.");
        }
    }
}
try
{
    int a = 10;
    int b = 0;
    {
        
    }
    // throw new Exception("Ini adalah kesalahan umum.");
    // throw new Exception("typo");
    // throw new CustomExceptionRandomError("Ini adalah pesan kesalahan kustom.", new Exception("Inner exception"));
    if (a == 0 || b == 0)
    {
        throw new Exception("Nilai a atau b tidak boleh nol.");
    }
    int result = a / b;
    Console.WriteLine(result);

}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Error: Argument tidak boleh null: {ex}");
}
catch (FormatException ex)
{
    Console.WriteLine($"Error: Format tidak valid: {ex}");
}
catch (OverflowException ex)
{
    Console.WriteLine($"Error: Terjadi overflow: {ex}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: Pembagian dengan nol tidak diperbolehkan: {ex}");
}
catch (Exception ex) when (ex is CustomExceptionRandomError)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex) when (ex.Message == "typo" ||ex is CustomExceptionRandomError)
{
    Console.WriteLine($"Error exception filter: {ex.Message}");
}
catch (CustomExceptionRandomError ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Terjadi kesalahan: " + ex.Message);
}
finally
{
    Console.WriteLine("Proses selesai.");
}

public class @Utils
{
    public static IEnumerable<string> Foo(bool breakEarly)
    {
        yield return "One";
        Console.WriteLine("Yielding One");
        yield return "Two";
        Console.WriteLine("Yielding Two");
        if (breakEarly)
            yield break;
        yield return "Three";
        Console.WriteLine("Yielding Three");
    }
    public static IEnumerable<int> GenerateNumbersWithDelay(int max)
    {
        for (int i = 1; i <= max; i++)
        {
            System.Threading.Thread.Sleep(3000);
            yield return i;
            Console.WriteLine($"Yielding {i}");
        }
    }
}
public class @ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public @ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Meng-overload operator +
    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

public class CustomExceptionRandomError : Exception
{
    public CustomExceptionRandomError() { }

    // Konstruktor dengan pesan kustom
    public CustomExceptionRandomError(string message) : base(message) { }

    // Konstruktor dengan pesan kustom dan inner exception
    public CustomExceptionRandomError(string message, Exception inner) : base(message, inner)
    {
        // Logika tambahan untuk menangani inner exception
        Console.WriteLine("Inner exception: " + inner.Message);
    }
}