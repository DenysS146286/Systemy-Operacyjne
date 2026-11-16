namespace SO_L4
{
    internal class Program
    {
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

            for (int i = 0; i < n; i++) {
                watki[i] = new Thread(Praca);
                watki[i].Name = "Auto-" + (i + 1);
                watki[i].Start();
            }

            for (int i = 0; i < n; i++) {
                watki[i].Join();
            }
            Console.WriteLine("Main ended");
        }
        static void Praca() {
            Thread me = Thread.CurrentThread;
            Console.WriteLine(me.Name + " id =" + me.ManagedThreadId);
        }
    }
}
