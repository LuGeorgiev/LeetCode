namespace _7._2.Majorant_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = "AAACCBBCCCBCC";
            var input = new int[] { 1, 2, 3, 4, 5, 3, 3, 3, 3 };
            var majorant = FindMajority(input);
            if (majorant == default)
                Console.WriteLine("Array has no majorant");
            else
                Console.WriteLine($"the majorant is: {majorant}");
        }

        private static T FindMajority<T>(T[] input)
        {
            var result = default(T);
            var halfSize = input.Length / 2;
            for (int i = 0; i < halfSize; i++)
            {
                var count = 0;
                for (int j = i; j < input.Length; j++)
                {
                    if (input[i].Equals(input[j]))
                    {
                        count++;
                    }
                }

                if (count > halfSize)
                    result = input[i];
            }

            return result;
        }
    }
}