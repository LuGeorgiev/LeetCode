using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy
{
    //155. Min Stack
    public class MinStack
    {
        private List<int> stack;
        private int minimum;

        public MinStack()
        {
            this.stack = new List<int>(128);
            this.minimum = int.MaxValue;
        }

        public void Push(int x)
        {
            stack.Add(x);
            if (x < minimum)
            {
                this.minimum = x;
            }
        }

        public void Pop()
        {
            if (stack.Count == 0)
            {
                return ;
            }
            bool toReorder = stack[stack.Count - 1]==this.minimum;
            stack.RemoveAt(stack.Count - 1);

            if (toReorder)
            {
                this.minimum = stack
                    .OrderBy(x => x)
                    .First();
            }
        }

        public int? Top()
        {
            if (stack.Count == 0)
            {
                return null;
            }
            return stack[stack.Count - 1];
        }

        public int? GetMin()
        {
            if (stack.Count==0)
            {
                return null;
            }
            return this.minimum;
        }
    }
}
