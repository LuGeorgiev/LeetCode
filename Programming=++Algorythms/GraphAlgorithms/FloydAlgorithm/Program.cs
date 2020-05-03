using System;

namespace FloydAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Floyd.CalculateMinimumPathLengths();
            //Floyd.PrintMinimumLengths();

            //FloydSystemRelayability.CalculatePathRelayability();
            //FloydSystemRelayability.PrintVertexRelayability();

            FloydMaxFlow.CalculateMaxFlows();
            FloydMaxFlow.PrintMaxFlows();
        }
    }
}
