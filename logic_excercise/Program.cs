// See https://aka.ms/new-console-template for more information
using System;

namespace login_exercise
{
 class Program
   {
       static void Main(string[] args)
       {
        int n = 15;
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