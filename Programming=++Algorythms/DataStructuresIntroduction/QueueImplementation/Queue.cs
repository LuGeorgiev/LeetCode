using System;
using System.Collections.Generic;
using System.Text;

namespace QueueImplementation
{
    public class Queue<T>
    {
        private const int INITIAL_SIZE = 4;
        private T[] queue;
        private int frontIndex;
        private int rearIndex;
        private bool isEmpty;

        public Queue()
        {
            this.queue = new T[INITIAL_SIZE];
            this.frontIndex = 0;
            this.rearIndex = 0;
            this.isEmpty = true;
        }

        public bool IsEmpty
            => this.isEmpty;

        public void EnQueue(T element)
        {
            this.isEmpty = false;
            this.queue[frontIndex] = element;
            this.frontIndex++;

            if (this.frontIndex >= this.queue.Length)
            {
                if (this.rearIndex > 0)
                {
                    this.frontIndex = 0;
                }
                else
                {
                    EnlargeQueue();
                }
            }
            else if (this.frontIndex == this.rearIndex)
            {
                EnlargeQueue();
            }
        }

        public T DeQueue()
        {
            if (this.isEmpty)
            {
                throw new IndexOutOfRangeException();
            }

            var value = this.queue[rearIndex];
            this.rearIndex++;


            if (this.frontIndex == this.rearIndex)
            {
                this.isEmpty = true;
            }

            if (this.rearIndex >= this.queue.Length)
            {
                if (this.frontIndex == 0)
                {
                    this.isEmpty = true;
                    this.rearIndex = 0;
                }
                else
                {
                    this.rearIndex = 0;
                }
            }

            return value;
        }

        private void EnlargeQueue()
        {
            var newQueue = new T[this.queue.Length * 2];
            if (this.frontIndex == this.rearIndex)
            {
                //the front has reached the rear index
                for (int i = this.frontIndex; i < this.queue.Length; i++)
                {
                    newQueue[i] = this.queue[i];
                }
                for (int i = 0; i < this.frontIndex; i++)
                {
                    newQueue[i] = this.queue[i];
                }
                this.rearIndex = 0;
            }
            else
            {
                //rear is inthe begining and front is out of range
                for (int i = 0; i < this.queue.Length; i++)
                {
                    newQueue[i] = this.queue[i];
                }
            }

            this.queue = newQueue;
        }
    }
}
