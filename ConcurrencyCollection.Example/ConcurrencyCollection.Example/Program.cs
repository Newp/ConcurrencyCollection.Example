using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyCollection.Example
{
    class Program
    {
        static readonly ConcurrentBag<string> bag = new ConcurrentBag<string>();
        
        static async Task Main(string[] args)
        {
            bag.Add("a");
            bag.Add("b");
            bag.Add("c"); ;
            bag.Add("d"); ;
            bag.Add("e");

            var cancellationTokenSource = new CancellationTokenSource();

            _ = ReadTest(cancellationTokenSource.Token);

            await Task.Delay(500);
            
            cancellationTokenSource.Cancel();
            await Task.Delay(3000);

        }

        static async Task ReadTest(CancellationToken cancellationToken)
        {
            while(true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("cancel requested");
                    break;
                }

                await Task.Delay(0, cancellationToken);

                var xx = string.Join(' ', bag.ToArray());

                Console.WriteLine($"{DateTime.Now:HH:mm.ss.fff}>>{xx}");
            }

        }
    }
}
