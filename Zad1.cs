using System;
using System.Collections.Generic;
using System.Text;

namespace SO_Lista3
{
    static class Zad1
    {
        const int N = 100, PROBY = 10000;
        static int[] tab = new int[N];

        static void Praca(int delta, int seed) { 
            var rnd = new Random(seed);
            for (int i = 0; i < PROBY; i++) tab[rnd.Next(N)] += delta;
        }

        public static void Run() {
            var T1 = new Thread(() => Praca(+1, 1));
            var T2 = new Thread(() => Praca(-1, 2));
            string[] LOL=new string[N];
            T1.Start(); T2.Start();
            T1.Join(); T2.Join();
            string path = @"D:\146286\SO_Lista3\SO_Lista3\dupa.csv";
            StreamWriter sr = new StreamWriter(path);
           
            for (int i = 0; i < N; i++) {
                Console.WriteLine($"{i} \t {tab[i],5}" + ((i + 1) % 10 == 0 ? "\n" : ""));
                LOL[i] = tab[i].ToString();
                sr.WriteLine(LOL[i]);
            }
            Console.WriteLine($"\nSuma: {tab.Sum()}");
            Console.WriteLine($"Min: {tab.Min()}, Max: {tab.Max()}, Avg: {tab.Average()}");
            //File.WriteAllLines(path, tab.Select((v, i) => $"{i};{v}"));
            //Console.WriteLine($"Zapisano: {Path.GetFullPath(path)}");
            sr.Close();

        }
    }
}