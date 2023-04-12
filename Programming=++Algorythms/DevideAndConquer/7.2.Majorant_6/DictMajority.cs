namespace _7._2.Majorant_6
{
    internal class DictMajority
    {
        static void Main(string[] args)
        {
            //var input = "AAACCBBCCCBCC";
            int[] input = { 1, 2, 3, 5, 6 };
            var result = TryFindMajority(input.ToArray());
            if (result.hasMajority)
            {
                Console.WriteLine($"Array has maojrity: {result.value}");
            }
            else 
            {
                Console.WriteLine("No majority");
            }

        }

        private static (bool hasMajority, T value) TryFindMajority<T>(T[] input)
            where T :  struct
        {
            var elementByCount = new Dictionary<T, int>();
            
            for (var i = 0; i < input.Length; i++)
            {
                var element = input[i];
                if (!elementByCount.ContainsKey(element))
                    elementByCount[element] = 0;

                elementByCount[element]++;
            }

            var halfLength = input.Length / 2;
            foreach (var kvp in elementByCount)            
                if (kvp.Value > halfLength)                
                    return (true, kvp.Key);               
                       
            return (false, default(T));
        }
        
    }
}