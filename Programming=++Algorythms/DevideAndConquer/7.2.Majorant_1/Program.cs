namespace _7._2.Majorant_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var input = "AAACCBBCCCBCC";
            var input = new int?[]{ 1,2,3,null,5,3,3,3,3};
            var majorant = FindMajorant(input);
            if (majorant == default)
                Console.WriteLine("Array has no majorant");
            else
                Console.WriteLine($"the majorant is: {majorant}");
        }

        private static T FindMajorant<T>(T[] input)
        {
            var halfSize = input.Length / 2;

            for (var i = 0; i < input.Length; i++)
            {
                if(CountElements(input, input[i]) > halfSize)
                    return input[i];
            }

            return default(T);
        }

        private static int CountElements<T>(T[] input, T t)
        {
            var count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] is not null && input[i].Equals(t))
                {
                    count++;
                }
            }

            return count;
        }
    }
}