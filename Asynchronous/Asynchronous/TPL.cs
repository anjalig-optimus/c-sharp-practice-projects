using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class TPL
    {

        public static void Func()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            // NO SEQUENCE IS FOLLOWED HERE
            Console.WriteLine("Parallel for loop");
            Parallel.For(1, 11, num =>
            {
                Console.WriteLine(num);
            });

            

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Parallel.ForEach(numbers, number =>
            {
                Console.WriteLine($"Processing number {number}");
            });

            // FOR SEQUENCE RUNNING OF FUNCTIONS
            Parallel.Invoke(
            Method2, 
            Method3   
        );

        }

        public static void Method2()
        {
            Console.WriteLine("Method 2 is running");
        }

        public static void Method3()
        {
            Console.WriteLine("Method 3 is running");
        }
    }
}