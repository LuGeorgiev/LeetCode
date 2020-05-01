using System;
using System.Collections.Generic;
using System.Text;

namespace DepthFirstSearch
{
    public class DFS
    {
        private class GraphNode
        {
            public int Value { get; set; }
            public int Level { get; set; }

            public override string ToString()
            => $"{new string('-', this.Level)} {this.Value + 1}";
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

        public static void DfsTraversal(int startNode)
        {
            var node = new GraphNode() { Value = startNode, Level = 0 };
            DfsPrint(node);
        }

        private static void DfsPrint(GraphNode node)
        {
            visited[node.Value] = true;
            Console.WriteLine(node);

            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[node.Value, i] && !visited[i])
                {
                    DfsPrint(new GraphNode() { Value = i, Level = node.Value + 1 });
                }
            }
        }
    }
}
