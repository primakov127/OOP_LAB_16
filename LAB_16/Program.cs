using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace LAB_16
{
    class Program
    {
        static void Main(string[] args)
        {
            #region First
            //Eratosfen first = new Eratosfen();

            //Task task1 = new Task(() => first.EratosfenT(500000));
            //var sw = Stopwatch.StartNew();
            //task1.Start();
            ////Thread.Sleep(4000);
            ////Console.WriteLine(task.Status);
            //task1.Wait();
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed);

            ////foreach (var item in first.Simple)
            ////{
            ////    Console.Write($"{item} ");
            ////}

            #endregion First

            #region Second

            //CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            //CancellationToken token = cancelTokenSource.Token;

            //Task task2 = new Task(() => first.EratosfenT(500000, ref token));
            //task2.Start();

            //Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            //string s = Console.ReadLine();
            //if (s == "Y")
            //    cancelTokenSource.Cancel();

            //task2.Wait();


            #endregion Second

            #region Third

            //Task<int> task1 = Task.Run(() => 5 * 2);
            //Task<int> task2 = Task.Run(() => 13 * 3);
            //Task<int> task3 = Task.Run(() => 3 * 7);
            //Task task4 = new Task(() => Task4(task1.Result, task2.Result, task3.Result));
            //task4.Start();

            //task4.Wait();

            #endregion Third

            #region Fourth

            //Task task1 = new Task(() => Console.WriteLine("First task"));
            //Task task2 = new Task(() => Console.WriteLine("Second task"));
            //Task task3 = Task.WhenAll(task1, task2).ContinueWith(t => Console.WriteLine("Third task which was started after first two"));
            //task1.Start();
            //task2.Start();

            //task3.Wait();

            //Task<int> what = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            //var awaiter = what.GetAwaiter();
            //awaiter.OnCompleted(() => { int res = awaiter.GetResult(); Console.WriteLine(res); });

            //what.Wait();

            #endregion Fourth

            #region Fifth

            //int[] arr1 = new int[10000000];
            //int[] arr2 = new int[10000000];
            //int[] arr3 = new int[10000000];
            //int[] arr4 = new int[10000000];
            //var sw = Stopwatch.StartNew();
            //Parallel.For(0, arr1.Length, i => { arr1[i] = i; arr2[i] = i; });
            //sw.Stop();
            //Console.WriteLine($"Parallel.For: {sw.Elapsed}");

            //sw.Restart();
            //Parallel.ForEach<int>(arr2, i => { arr2[i] = i; arr3[i] = i; });
            //sw.Stop();
            //Console.WriteLine($"Parallel.ForEach: {sw.Elapsed}");

            //sw.Restart();
            //for (int i = 0; i < arr3.Length; i++)
            //{
            //    arr3[i] = i;
            //    arr4[i] = i;
            //}
            //sw.Stop();
            //Console.WriteLine($"For: {sw.Elapsed}");

            #endregion Fifth

            #region Sixth

            //Parallel.Invoke(()=>Console.WriteLine("Task1"), ()=>Console.WriteLine("Task2"));

            #endregion Sixth

            #region Seventh

            //stock = new BlockingCollection<string>();

            //Task task1 = new Task(startBuyer);
            //Task task2 = new Task(startProvider);
            //task2.Start();
            //task1.Start();
            //Task.WaitAll(task1, task2);

            #endregion Seventh

            #region Eighth

            FactorialAsync();
            Console.ReadLine();

            #endregion
        }

        static BlockingCollection<string> stock;

        public static void Task4(int a, int b, int c)
        {
            Console.WriteLine($"Результат = {a + b + c}");
        }

        public static void startBuyer()
        {
            var mans = new[]
            {
                new Buyer("Max"),
                new Buyer("Andrey"),
                new Buyer("Anton"),
                new Buyer("Diana"),
                new Buyer("Vadim"),
                new Buyer("Katya"),
                new Buyer("Dasha"),
                new Buyer("Danil"),
                new Buyer("Nikita"),
                new Buyer("Julia")
            };
        
            
            while (!stock.IsCompleted)
            {
                foreach (var i in mans)
                {
                    i.Take(stock);
                }
                
            }
            Console.WriteLine("Товар закончен");
        }

        public static void startProvider()
        {
            var providers = new[]
            {
                new Provider("First Provider", 500),
                new Provider("Second Provider", 1100),
                new Provider("Third Provider", 300),
                new Provider("Fourth Provider", 100),
                new Provider("Fiveth Provider", 760)
            };

            for (int i = 0; i < 10;)
            {
                foreach (var prov in providers)
                {
                    if (i == 10)
                        break;
                    prov.Add(stock);
                    i++;
                    
                }

            }
            stock.CompleteAdding();
        }

        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial());                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }

        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"Факториал равен {result}");
        }
    }
}
