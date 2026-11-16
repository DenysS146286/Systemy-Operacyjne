using System.Diagnostics;

namespace SO_L4
{
    internal class Program
    {
        static List<string> log = new List<string>();
        static object blokada = new object();

        static void Main(string[] args) {
            int n;
            if (args.Length > 0)
            {
                n = int.Parse(args[0]);
            }
            else {
                Console.WriteLine("Podaj N = ");
                n = int.Parse (Console.ReadLine()!);
            }
            Thread[] watki = new Thread[n];
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < n; i++) {
                watki[i] = new Thread(Praca);
                watki[i].Name = "Auto-" + (i + 1);
                watki[i].Start();
            }

            for (int i = 0; i < n; i++) {
                watki[i].Join();
            }
            stopWatch.Stop();
            Console.WriteLine("Main koniec, czas: " + stopWatch.ElapsedMilliseconds + "ms");

            Console.Write("Numer urochomiena (1-5): ");
            string nr = Console.ReadLine();
            string path = @"D:\146286\So_Lista4\SO-L4\SO-L4\result1.csv";
            StreamWriter sr = new StreamWriter(path);
            sr.WriteLine();
            sr.WriteLine("czas_ms;" + stopWatch.ElapsedMilliseconds);
            sr.Close();
        }
        static void Praca() {
            Thread me = Thread.CurrentThread;
            string s = me.Name + ";" + me.ManagedThreadId + ";start";
            lock (blokada) { log.Add(s); }
            Console.WriteLine(s);

            for (int k = 1; k <= 5; k++) {
                s = me.Name + ";" + me.ManagedThreadId + ";krok" + k;
                lock (blokada) { log.Add(s); }
                Console.WriteLine(s);
                Thread.Sleep(10);
            }
            s = me.Name + ";" + me.ManagedThreadId + ";KONIEC";
            lock (blokada) { log.Add(s); }
            Console.WriteLine(s);
        }
        static void Dodaj(string wiersz) {
            lock (wiersz) {
                log.Add(wiersz);
                Console.WriteLine(wiersz);
            }
        }
    }
}
