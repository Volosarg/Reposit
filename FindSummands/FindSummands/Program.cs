using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindSummands
{
    class Program
    {
        /// <summary>
        /// Тест нахождения пар на случайном числе и коллекции из 1000 случайных чисел
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ICollection<int> col = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
                col.Add(rnd.Next(-1000, 1000));
            int x = rnd.Next(-1000, 1000);
            Dictionary<int, int> result = FindSummands(x, col);

            StringBuilder sb = new StringBuilder();

            if (result.Count == 0)
                sb.Append("Пары слагаемых не найдены для " + x.ToString());
            else
            {
                sb.Append("Найдено " + result.Count + " пар слагаемых для " + x.ToString() + ":");
                foreach (KeyValuePair<int, int> pare in result)
                {
                    sb.Append("[");
                    sb.Append(pare.Key.ToString());
                    if (pare.Value >= 0)
                        sb.Append("+");
                    sb.Append(pare.Value.ToString());
                    sb.Append("]");
                }
            }

            Console.WriteLine(sb.ToString());

            Console.ReadLine();
        }

        /// <summary>
        /// Выводит все пары чисел, которые в сумме равны заданному x.В случае, если в коллекции не числа, возвращает null
        /// </summary>
        /// <typeparam name="T">Тип чисел</typeparam>
        /// <param name="x">Число</param>
        /// <param name="col">Коллекция чисел</param>
        /// <returns></returns>
        public static Dictionary<T, T> FindSummands<T>(T x, ICollection<T> col) where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {
            try
            {
                Dictionary<T, T> result = new Dictionary<T, T>();
                T[] mass = col.Distinct().OrderBy(i => i).ToArray();
                for (int i = 0; i < mass.Length - 1 && ( i >= mass.Length-2 || (dynamic)mass[i] + (dynamic)mass[i+1] <= x); i++)
                {
                    for (int j = i + 1; j < mass.Length && (dynamic)mass[i] + (dynamic)mass[j] <= x; j++)
                    {
                        if ((dynamic)mass[i] + (dynamic)mass[j] == x)
                            result.Add(mass[i], mass[j]);
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
