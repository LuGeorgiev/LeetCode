using System;

namespace NumberComposition
{
    class Program
    {
        //Number that have tp be devided
        private static uint number = 10;

        private static uint[] vector = new uint[number+1];

        static void Main(string[] args)
        {
            vector[0] = number + 1;
            DevideNumber(number,1);
        }

        private static void Print(uint length)
        {
            for (int i = 1; i < length; i++)
            {
                Console.Write(vector[i]+"+");
            }
            Console.WriteLine(vector[length]);
        }

        private static void DevideNumber(uint num, uint index)
        {
            if (num == 0)
            {
                Print(index - 1);
            }
            else
            {
                for (uint current = num; current >= 1; current--)
                {
                    vector[index] = current;
                    if (vector[index] <= vector[index-1])
                    {
                        DevideNumber(num - current, index + 1);
                    }
                }
            }
        }
    }
}
