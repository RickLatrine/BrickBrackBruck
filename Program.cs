using System;
using System.Collections.Generic;

namespace BrickBrackBruck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] data = {"aaa", "bbb"};
            var names = new List<string>(data);

            var tup = (harry:1, stefan:2, derrick:3);

            Console.WriteLine("Tuple 1: " + tup.derrick);                
            Console.WriteLine("Tuple 2: " + tup.harry);                
            Console.WriteLine("Tuple 3: " + tup.stefan);                

            foreach (var name in names) {
                Console.WriteLine("Name: " + name);
            }

        }
    }
}
