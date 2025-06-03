// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.Write("Masukkan angka: ");
int number = int.Parse(Console.ReadLine());
API api = new API { rangeNumber = number };
while (true)
{
    Console.WriteLine("1. GetAll ");
    Console.WriteLine("2. GetById ");
    Console.WriteLine("3. PostRule ");
    Console.Write("Pilih Request: ");
    int rest = int.Parse(Console.ReadLine());
    Response responseAPI;
    switch (rest)
    {
        case 1:
            responseAPI = api.GetAll();
            Console.WriteLine(JsonSerializer.Serialize(responseAPI));
            break;
        case 2:
            Console.Write("Masukkan id: ");
            int byId = int.Parse(Console.ReadLine());
            responseAPI = api.GetById(byId);
            Console.WriteLine(JsonSerializer.Serialize(responseAPI));
            break;
        case 3:
            Console.Write("Masukkan angka rule: ");
            int ruleNumber = int.Parse(Console.ReadLine());
            Console.Write("Masukkan output rule: ");
            string ruleOutput = Console.ReadLine();
            responseAPI = api.PostRule(ruleNumber, ruleOutput);
            Console.WriteLine(JsonSerializer.Serialize(responseAPI));
            break;
        default:
            Console.WriteLine("Invalid request");
            break;
    }
}
public class API
{
    public int rangeNumber { get; set; }
    private static List<Dictionary<int, string>> _rules =
        new List<Dictionary<int, string>>()
        {
            new Dictionary<int, string> { { 3, "foo" } },
            new Dictionary<int, string> { { 4, "baz" } },
            new Dictionary<int, string> { { 5, "bar" } },
            new Dictionary<int, string> { { 7, "jazz" } },
            new Dictionary<int, string> { { 9, "huzz" } }
        };
    public Response GetAll()
    {
        return new Response
        {
            Status = "Success",
            Message = LogicGenerator(this.rangeNumber)
        };
    }
    public Response GetById(int number)
    {
        return new Response
        {
            Status = "Success",
            Message = LogicGenerator(this.rangeNumber, number)
        };
    }
    public Response PostRule(int number, string rule)
    {
        _rules.Add(new Dictionary<int, string> { { number, rule } });
        return new Response
        {
            Status = "Success",
            Message = $"Rule {rule} added for number {number}."
        };
    }
    public static string LogicGenerator(int number, int byId = 0)
    {
        string result = "";
        for (int i = 1; i <= number; i++)
        {
            bool flag = false;
            string temp = "";
            foreach (Dictionary<int, string> rule in _rules)
            {
                foreach (var kvp in rule)
                {
                    if (i % kvp.Key == 0)
                    {
                        flag = true;
                        temp += kvp.Value;
                    }
                }
            }
            if (!flag) temp = i.ToString();
            if (i != number) temp += ", ";
            result += temp;
        }
        if (byId != 0)
        {
            string[] resultArray = result.Split(", ");
            // Console.WriteLine(JsonSerializer.Serialize(resultArray));
            return resultArray[byId - 1];
        }
        return result;
    }
}
public class Response
{
    public string Status { get; set; }
    public string Message { get; set; }
}