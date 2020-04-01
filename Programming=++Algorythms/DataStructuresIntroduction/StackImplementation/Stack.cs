using System;
using System.Collections;
using System.Collections.Generic;

namespace StackImplementation
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int INITIAL_SIZE = 8;
        private T[] stack;
        private int index;

        public Stack()
        {
            this.stack = new T[INITIAL_SIZE];
            this.index = 0;
        }

        public Stack(int size)
        {
            this.stack = new T[size];
            this.index = 0;
        }

        public bool IsEmpty
            => index == 0;

        public void Push(T element)
        {
            if (index == stack.Length)
            {
                EnlargeStack();
            }
            this.stack[this.index] = element;
            index++;
        }

        public int Count 
            => this.stack.Length;

        public T Pop()
        {
            if (index == 0)
            {
                throw new IndexOutOfRangeException();
            }
            return this.stack[--index];
        }

        private void EnlargeStack()
        {
            var newStack = new T[this.stack.Length * 2];
            for (int i = 0; i < this.stack.Length; i++)
            {
                newStack[i] = this.stack[i];
            }

            this.stack = newStack;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (! this.IsEmpty)
            {
                yield return this.Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
