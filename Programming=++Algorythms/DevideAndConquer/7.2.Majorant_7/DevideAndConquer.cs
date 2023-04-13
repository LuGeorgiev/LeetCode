namespace _7._2.Majorant_7
{
    internal class DevideAndConquer
    {

        static void Main(string[] args)
        {
            int[] input = { 3, 2, 3, 3, 6 , 3 };
            if (FindMajority(input, 0, input.Length-1, out var result))
                Console.WriteLine($"Has majority: {result}");
            else
                Console.WriteLine("Do not has majority.");
        }

        private static int ElementCount(int[] input, int left, int right, int candidate)
        {
            var count = 0;
            for (int i = left; i <= right; i++)
            {
                if (input[i] == candidate)
                    count++;
            }

            return count;
        }

        private static bool FindMajority(int[] input, int left, int right, out int candidate)
        {
            candidate = 0;
            var mid = ( left + right ) / 2;

            if (left == right)
            {
                candidate = input[left];
                return true;
            }

            if (FindMajority(input, left, mid, out candidate))
                if (ElementCount(input, left, right, candidate) > (right - left + 1) / 2)
                    return true;

            if(FindMajority(input, mid + 1, right, out candidate))
                if(ElementCount(input, left, right, candidate) > (right - left + 1) / 2)
                    return true;

            return false; 
        }
    }
}