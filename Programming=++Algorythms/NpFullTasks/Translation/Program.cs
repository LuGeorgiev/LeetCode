using System;

namespace Translation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            BgMorseCode.Decode();
        }
    }
}
