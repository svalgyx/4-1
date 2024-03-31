﻿using System;
using System.Diagnostics.SymbolStore;
using HW3_4.Implementings;

namespace HW3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            SingleArray<int> single_ar = new SingleArray<int>(0);
            for (int i = 0; i < 11; i++)
            {
                single_array.Add(rnd.Next(1, 100));
            }
            single_ary.ForEach((x) => Console.WriteLine(x));
            Console.WriteLine(single_array.All((x) => x >= 5));
            int[] array = single_ar.Where((x) => x >= 25);
            foreach (int n in array)
            {
                Console.WriteLine(n);
            }
            single_ar.Reverse();
            single_ar.ForEach((x) => Console.WriteLine(x));
            Console.WriteLine(single_ar.Min());
            Console.Write("Press enter to exit: ");
            Console.ReadLine();
        }
    }
}