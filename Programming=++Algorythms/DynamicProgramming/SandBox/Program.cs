using System.Collections;

namespace SandBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            //byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5 };
            int[] myBytes = new int[2] { 5, -4 };
            Console.WriteLine((myBytes[0]));
            BitArray myBA3 = new BitArray(myBytes);
        }
    }
}