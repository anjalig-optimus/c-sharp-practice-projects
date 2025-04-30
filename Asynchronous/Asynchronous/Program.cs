using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Program
    {
        static async Task Task1()
        {
            Console.WriteLine("Task 1 started");
            Console.WriteLine($"task 1 started by {Thread.CurrentThread.ManagedThreadId}");
            
            await Task.Delay(8000); 

            Console.WriteLine($"task 1 completed by {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Task 1 completed!");
        }

        static async Task Task2()
        {
            Console.WriteLine("Task 2 started");
            
            await Task.Delay(5000);  

            //Task.delay(2000) then it will not wait and directly execute the below line
            Console.WriteLine("Task 2 completed!");
        }

        public  static async Task Main(string[] args)
        {
            TPL.Func();
            Class1.Main2();
           // Start both tasks asynchronously
            Task task1 = Task1();
            Task task2 = Task2();

            // Wait for both tasks to complete
            await Task.WhenAll(task1, task2);

            // CANCEL TOKEN
            //CancellationTokenSource cts = new CancellationTokenSource();
            //cts.CancelAfter(3000);

            Console.WriteLine("Both tasks are complete.");


        }
    }
}
