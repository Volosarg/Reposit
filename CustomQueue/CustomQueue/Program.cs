using System;
using System.Threading;

namespace CustomQueue
{
    class Program
    {
        static CustomQueue<string> q = new CustomQueue<string>();
        /// <summary>
        /// Проверка очереди на 10 извлекающих потоках
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(Go));
                t.Name = i.ToString();
                t.Start();

            }
            Thread.Sleep(1000);
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Push" + i.ToString());
                q.Push(i.ToString());
            }
            Console.ReadLine();
        }

        static void Go()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Pop" + Thread.CurrentThread.Name + " " + q.Pop());
            }
        }
    }
}
