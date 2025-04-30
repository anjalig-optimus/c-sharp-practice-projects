using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Class1
    {
        public static async Task<int> GetDataAsync()
        {
            await Task.Delay(2000); 

            return 42;  
        }
        public static async Task Main2()
        {
            Console.WriteLine("Fetching data asynchronously...");
            int result = await GetDataAsync();
            Console.WriteLine($"Fetched result: {result}");
        }
    }
}
