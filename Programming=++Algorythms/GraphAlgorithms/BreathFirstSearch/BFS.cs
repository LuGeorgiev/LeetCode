using System;
using System.Collections.Generic;
using System.Text;

namespace BreathFirstSearch
{
    public class BFS
    {
        private class GraphNode
        {
            public int Value { get; set; }
            public int Level { get; set; }

            public override string ToString()
            => $"{new string('-',this.Level)} {this.Value + 1}";
        }

        const int VERTECES_COUNT = 14;

        static readonly bool[,] graph = new bool[VERTECES_COUNT, VERTECES_COUNT] 
        {
            {false, true, false, false, false, false, false, false, false, false, false, false, false, false},
            {true, false, true, true, true, false, false, false, false, false, false, false, false, false},
            {false, true, false, false, false, true, false, false, false, false, false, false, false, false},
            {false, true, false, false, false, false, false, false, false, false, false, true, false, false},
            {false, true, false, false, false, false, true, false, false, false, false, false, false, false},
            {false, false, true, false, false, false, true, false, false, false, false, true, false, false},
            {false, false, false, false, true, true, false, false, false, true, false, false, false, false},
            {false, false, false, false, false, false, false, false, true, false, false, false, false, false},
            {false, false, false, false, false, false, false, true, false, false, false, false, true, true},
            {false, false, false, false, false, false, true, false, false, false, true, false, false, false},
            {false, false, false, false, false, false, false, false, false, true, false, false, false, false},
            {false, false, false, true, false, true, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, true, false, false, false, false, true},
            {false, false, false, false, false, false, false, false, true, false, false, false, true, false}
        };

        static readonly bool[] visited = new bool[VERTECES_COUNT];

        public static void BfsGraphTraversal(int startNode)
        {
            var queue = new Queue<GraphNode>();
            queue.Enqueue(new GraphNode {Value = startNode, Level = 0 });
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                var currentLevel = currentNode.Level;
                Console.WriteLine(currentNode);

                for (int i = 0; i < graph.GetLength(1); i++)
                {
                    if (graph[currentNode.Value, i] && !visited[i])
                    {
                        queue.Enqueue(new GraphNode { Value = i, Level = currentLevel + 1 });
                        visited[i] = true;
                    }
                }
            }

        }
    }
}
