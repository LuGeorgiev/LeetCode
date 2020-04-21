using System;

namespace HashTebleImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable<int, string>();
            hashTable.Add(1, "11");
            hashTable.Add(2, "22");
            hashTable.Add(3, "33");
            hashTable.Add(4, "44");
            hashTable.Add(5, "55");
            hashTable.Remove(3);
            hashTable[6] = "66";

            Console.WriteLine(hashTable[5]);
            foreach (var key in hashTable)
            {
                Console.WriteLine(key);
            }
        }
    }
}
