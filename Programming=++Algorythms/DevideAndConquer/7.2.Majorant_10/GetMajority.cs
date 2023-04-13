namespace _7._2.Majorant_10
{
    internal class GetMajority
    {
        static void Main(string[] args)
        {
            char[] array = { 'A', 'A', 'A', 'C', 'C', 'B', 'B', 'C', 'C', 'C', 'B', 'C', };

            Console.WriteLine(ExtractMajority(array));
        }

        private static T ExtractMajority<T>(T[] input)
           where T : struct
        {
            var size = input.Length;

            do
            {
                var currentCount = 0;
                
                for (int i = 1; i < size; i += 2)
                    if (input[i - 1].Equals(input[i]))
                        input[currentCount++] = input[i];

                if ((currentCount & 1) == 0)
                    input[currentCount++] = input[size -1];

                size = currentCount;

            } while (size > 1);

            return input[0];
        }
    }
}