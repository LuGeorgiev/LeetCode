using System;

namespace KruskalAlgorithm
{
    public class Edge : IComparable
    {
        public Edge(int a, int b, int weight)
        {
            this.VertA = a;
            this.VertB = b;
            this.Weight = weight;
        }

        public int VertA { get; set; }
        public int VertB { get; set; }
        public int Weight { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Edge otherEdge = obj as Edge;

            int compare = 0;

            if (otherEdge != null)
            {

                if (this.Weight < otherEdge.Weight)
                {
                    compare = -1;
                }
                else if (this.Weight > otherEdge.Weight)
                {
                    compare = 1;
                }
                else
                {
                    if (this.VertA < otherEdge.VertA)
                    {
                        compare = -1;
                    }
                    else if (this.VertA > otherEdge.VertA)
                    {
                        compare = 1;
                    }
                    else
                    {
                        if (this.VertB < otherEdge.VertB)
                        {
                            compare = -1;
                        }
                        else if (this.VertB > otherEdge.VertB)
                        {
                            compare = 1;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException();
            }

            return compare;
        }

        public override string ToString()
        => $"({this.VertA}, {this.VertB}) ";
    }
}
