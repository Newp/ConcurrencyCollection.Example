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
         아래 코드의 주석을 사용하여 ConcurrentDictionary와 Dictionary를 번갈아 사용해보세요.
         */
        static readonly ConcurrentDictionary<string, string> dictionary = new();
        //static readonly Dictionary<string, string> dictionary = new();
    
        static void Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(1500);

            Task.WaitAll(
                Add(cancellationTokenSource.Token),
                Read(cancellationTokenSource.Token)
            );

            Console.WriteLine(dictionary.Count);
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

                foreach (var item in dictionary) { } //아무것도 안하고 반복자만 수행해도 동시성 보장이 안되면 문제가 생김.
            }
        }

        static readonly Random random = new();
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

                var time = DateTime.Now.ToString("yyyyMMddHHmmss.ffffffzzz") + random.Next();
                while (true)
                {
                    if (dictionary.TryAdd(time, time)) break;
                    else
                    {
                        Console.WriteLine($"fail : {time}");
                    }
                }
            }
        }
    }
}
