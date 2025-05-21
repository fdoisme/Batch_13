// See https://aka.ms/new-console-template for more information
Console.Write("Masukkan angka: ");
int number = int.Parse(Console.ReadLine());

// Console.WriteLine($"Angka yang dimasukkan adalah: {number}");
for (int i = 0; i <= number; i++)
{
    string result = "";
    if (i % 7 == 0)
    {
        result += "jazz";
    }
    if (i % 3 == 0 && i % 5 == 0)
    {
        result = "foobar" + result;
    }
    else if (i % 3 == 0)
    {
        result = "foo" + result;
    }
    else if (i % 5 == 0)
    {
        result = "bar" + result;
    }
    else
    {
        result = i.ToString();
    }
    if (i != number)
    {
        result += ", ";
    }
    Console.Write(result);
}