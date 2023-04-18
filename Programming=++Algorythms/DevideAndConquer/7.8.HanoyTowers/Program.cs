using System.Reflection;

namespace _7._8.HanoyTowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var disksCount = 5;
            Console.WriteLine($"Number of disks: {disksCount}");
            Hanoy('A', 'C', 'B', disksCount);
        }

        private static void DiscMoved(int n, char a, char b) =>        
            Console.WriteLine($"Move disk {n} from {a} to {b}.");
        

        private static void Hanoy(char a, char c, char b, int numb)
        {
            if (numb == 1)
            {
                DiscMoved(1, a, c);
            }
            else 
            {
                Hanoy(a, b, c, numb - 1);
                DiscMoved(numb, a, c);
                Hanoy(b, c, a, numb - 1);
            }
        }
    }
}