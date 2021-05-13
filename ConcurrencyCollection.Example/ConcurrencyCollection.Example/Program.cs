using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DictionaryExample
{
    class Program
    {
        /*
         아래 코드의 주석을 사용하여 ConcurrentBag과 List를 번갈아 사용해보세요.
         */
        static readonly ConcurrentBag<string> bag = new ConcurrentBag<string>();
        //static readonly List<string> bag = new List<string>();

        static void Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(1500);

            Task.WaitAll(
                Add(cancellationTokenSource.Token),
                Read(cancellationTokenSource.Token)
            );

            var msg = string.Join(string.Empty, bag.ToArray());
            Console.WriteLine(msg.Length);
         }

        static async Task Read(CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("cancel requested");
                    break;
                }

                foreach (var item in bag) { } //아무것도 안하고 반복자만 수행해도 동시성 보장이 안되면 문제가 생김.
            }
        }

        static async Task Add(CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("cancel requested");
                    break;
                }

                bag.Add("!");
                //await Task.Delay(1);
            }
        }
    }
}
