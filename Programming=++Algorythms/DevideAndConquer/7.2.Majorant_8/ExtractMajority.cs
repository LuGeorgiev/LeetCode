namespace _7._2.Majorant_8
{
    internal class ExtractMajority
    {
        static void Main(string[] args)
        {
            char[] array = { 'A', 'A', 'A', 'C', 'C', 'B', 'B', 'C', 'C', 'C', 'B', 'C', };

            Console.WriteLine(ExtractMajorityElement(array));
        }

        private static T ExtractMajorityElement<T>(T[] input)
            where T : struct
        {
            var size = input.Length;
            var part = false;

            do
            {
                var currentCount = 0;
                int i = 1;
                for (; i < size; i += 2)
                    if (input[i - 1].Equals(input[i]))
                        input[currentCount++] = input[i];

                if (i == size)
                {
                    input[currentCount++] = input[i - 1];
                    part = true;
                }
                else if (part || input[size - 2].Equals(input[size - 1]))
                {
                    input[currentCount] = input[size - 2];
                }
                else
                {
                    currentCount--;
                }

                size = currentCount;

            } while (size > 1);

            return input[0];
        }
    }
}