// See https://aka.ms/new-console-template for more information
Console.Write("Masukkan angka: ");
int number = int.Parse(Console.ReadLine());

// Console.WriteLine($"Angka yang dimasukkan adalah: {number}");
for (int i = 1; i <= number; i++)
{
    string result = "";
    bool flag = false;
    if (i % 3 == 0)
    {
        flag = true;
        result += "foo";
    }
    if (i % 4 == 0)
    {
        flag = true;
        result += "baz";
    }
    if (i % 5 == 0)
    {
        flag = true;
        result += "bar";
    }
    if (i % 7 == 0)
    {
        flag = true;
        result += "jazz";
    }
    if (i % 9 == 0)
    {
        flag = true;
        result += "huzz";
    }
    if (!flag) result = i.ToString();
    Console.Write(result);
    if (i != number) Console.Write(", ");
}