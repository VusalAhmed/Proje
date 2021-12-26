using System;

namespace Extensions
{
  public  class Program
    {
        static public void  Main(string[] args)
        {
            string str1 = "Hello world";
            string str2 = "Hello world";
            
            
            bool a, b;

            a = str1.EndsWith("world");
            Console.WriteLine(a.ToString());
             
            b = str2.EndsWith("Hello");
            Console.WriteLine(b.ToString());
           


        }
    }
}
