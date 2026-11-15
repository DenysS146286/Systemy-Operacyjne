namespace SO_Lista3
{
    static class Zad2
    {
        static int adresat = 1;
        static string wiadomosc = "start";
        static object zamek = new object();
        static bool dziala = true;

        static void Watek(int id)
        {
            Random rnd = new Random(id);
            while (dziala)
            {
                lock (zamek)
                {
                    if (adresat == id)
                    {
                        Console.WriteLine("Watek " + id + " dostal: " + wiadomosc);
                        wiadomosc = "hej od " + id;
                        adresat = rnd.Next(1, 7);
                    }
                }
                Thread.Sleep(rnd.Next(10, 31));
            }
        }

        public static void Run()
        {
            Thread[] watki = new Thread[6];
            for (int i = 0; i < 6; i++)
            {
                int id = i + 1;
                watki[i] = new Thread(() => Watek(id));
                watki[i].Start();
            }

            Thread.Sleep(3000);
            dziala = false;
        }
    }
}