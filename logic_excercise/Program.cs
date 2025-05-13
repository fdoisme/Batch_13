// See https://aka.ms/new-console-template for more information
using System;

namespace login_exercise
{
 class Program
   {
       static void Main(string[] args)
       {
        Console.Write("Input Number : ");
        int n = Convert.ToInt32(Console.ReadLine());
          for (int i = 1; i <= n; i++)
          {
            if (i%5 == 0 && i%3 == 0)
                {
          Console.Write("foobar");
                    }else if (i%3 == 0)
                {
          Console.Write("foo");
                    }else if (i%5 == 0)
                {
          Console.Write("bar");
                    }else{
                        Console.Write(i);
                    }
                    if (i != n )
                    {
          Console.Write(", ");
                        
                    }
          }
       }
   }
}