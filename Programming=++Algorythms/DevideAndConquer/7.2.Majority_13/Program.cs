namespace _7._2.Majority_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = "A A A A C B B C C C B C C".ToCharArray().Where(x => !x.Equals(' ')).ToArray();
            
            Console.WriteLine(CheckMajority(array));
        }

        private static (bool hasMajorant, T value) CheckMajority<T>(T[] input)
          where T : struct
        {
            var count = 0;
            T element= default;

            for (int i = 0; i < input.Length; i++)
            {
                if (count == 0)
                {
                    element = input[i];
                    count++;
                }
                else if (element.Equals(input[i]))
                {
                    count++;
                }
                else
                {
                    count--;
                }                
            }

            if (count == 0)
                return (false, default);

            count = 0;
            for (int i = 0; i < input.Length; i++)            
                if (element.Equals(input[i]))                
                    count++;
                
            if (count > input.Length / 2)
                return (true, element);

            return (false, default);
        }
    }
}