using System;

//Reference
//http://www.rkinteractive.com/blogs/SoftwareDevelopment/post/2012/12/16/Algorithms-In-C-Red-Black-Trees.aspx

namespace RBTreeImplementation
{
    public class RBTree<T>
        where T : IComparable
    {
        private Node<T> root;

        private int elementsCount;
        public RBTree()
        {
            this.elementsCount = 0;
            this.root = null;
        }

        public int Count => this.elementsCount;

        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("empty tree!");
                return;
            }

            InOrderDisplay(this.root);
        }

        public Node<T> Find(T key)
        {
            return Find(this.root, key);
        }

        private Node<T> Find(Node<T> x, T key)
        {
            if (x == null || key.CompareTo(x.Value) == 0)
            {
                return x;
            }

            if (key.CompareTo(x.Value) < 0)
            {
                return this.Find(x.Left, key);
            }
            else
            {
                return this.Find(x.Right, key);
            }
        }

        public void Insert(T item)
        {
            var newNode = new Node<T>(item);
            if (this.root == null)
            {
                this.root = newNode;
                this.root.Color = Color.Black;
                return;
            }

            Node<T> y = null;
            Node<T> x = this.root;

            while (x != null)
            {
                y = x;
                if (newNode.Value.CompareTo(x.Value) <= 0)
                {
                    x = x.Left;
                }
                else
                {
                    x = x.Right;
                }
            }
            newNode.Parent = y; //TODO check

            if (y == null)
            {
                this.root = newNode;
            }
            else if (newNode.Value.CompareTo(y.Value) <= 0)
            {
                y.Left = newNode;
            }
            else
            {
                y.Right = newNode;
            }

            this.InsertFixUp(newNode);
        }

        public void Delete(T key)
        {
            var toDelete = this.Find(key);
           
            this.Delete(toDelete);
        }

        private void Delete(Node<T> z)
        {
            Node<T> x = null;
            Node<T> y = z;
            Color yOriginalColor = y.Color;

            if (z.Left == null)
            {
                x = z.Right;
                this.Transplant(z, z.Right);
            }
            else if (z.Right == null)
            {
                x = z.Left;
                this.Transplant(z, z.Left);
            }
            else
            {
                y = this.Minimum(z.Right);
                yOriginalColor = y.Color;
                x = y.Right;

                if (y.Parent == z)
                {
                    x.Parent = y;
                }
                else
                {
                    this.Transplant(y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }

                this.Transplant(z, y);
                y.Left = z.Left;
                y.Left.Parent = y;
                y.Color = z.Color;
            }

            if (yOriginalColor == Color.Black)
            {
                this.DeleteFixUp(x);
            }
        }

        private void Transplant(Node<T> u, Node<T> v)
        {
            if (u.Parent == null)
            {
                this.root = v;
            }
            else if (u == u.Parent.Left)
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }

            v.Parent = u.Parent;
        }


        private Node<T> DeleteNode(Node<T> root, T item, object p)
        {
            throw new NotImplementedException();
        }

        private void InOrderDisplay(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                InOrderDisplay(currentNode.Left);

                Console.WriteLine(currentNode);

                InOrderDisplay(currentNode.Right);
            }
        }

        private void InsertFixUp(Node<T> currentNode)
        {
            //Check R-B Tree properties
            while (currentNode != this.root && currentNode.Parent.Color == Color.Red)
            {
                if (currentNode.Parent == currentNode.Parent.Parent.Left)
                {
                    var y = currentNode.Parent.Parent.Right;
                    if (y != null && y.Color == Color.Red)//case 1 Uncle is red
                    {
                        currentNode.Parent.Color = Color.Black;
                        y.Color = Color.Black;
                        currentNode.Parent.Parent.Color = Color.Red;
                        currentNode = currentNode.Parent.Parent;
                    }
                    else //case 2 uncle is black
                    {
                        if (currentNode == currentNode.Parent.Right)
                        {
                            currentNode = currentNode.Parent;
                            this.LeftRotate(currentNode);
                        }

                        //case 3 recolor and rotate
                        currentNode.Parent.Color = Color.Black;
                        currentNode.Parent.Parent.Color = Color.Black; //this maight be wrong!!
                        this.RightRotate(currentNode.Parent.Parent);
                    }
                }
                else
                {
                    //mirror of code above
                    var x = currentNode.Parent.Parent.Left;
                    if (x != null && x.Color == Color.Red)//case 1  //changed to RED !!
                    {
                        currentNode.Parent.Color = Color.Black;  //col changed
                        x.Color = Color.Black;                  //col changed
                        currentNode.Parent.Parent.Color = Color.Red; //col
                        currentNode = currentNode.Parent.Parent;
                    }
                    else
                    {
                        if (currentNode == currentNode.Parent.Left)
                        {
                            currentNode = currentNode.Parent;
                            this.RightRotate(currentNode);
                        }

                        currentNode.Parent.Color = Color.Black;
                        currentNode.Parent.Parent.Color = Color.Red;
                        this.LeftRotate(currentNode.Parent.Parent);
                    }
                }

                root.Color = Color.Black;
            }
        }

        private void DeleteFixUp(Node<T> x)
        {
            Node<T> w = null;

            while (x != this.root && x.Color == Color.Black)
            {
                if (x == x.Parent.Left)
                {
                    w = x.Parent.Right;

                    if (w.Color == Color.Red)
                    {
                        w.Color = Color.Black; //case 1
                        x.Parent.Color = Color.Red; //case 1
                        LeftRotate(x.Parent); //case 1
                        w = x.Parent.Right; //case 1
                    }

                    if (w.Left.Color == Color.Black && w.Right.Color == Color.Black)
                    {
                        w.Color = Color.Red; //case 2
                        x = x.Parent; //case 2
                    }
                    else
                    {
                        if (w.Right.Color == Color.Black)
                        {
                            w.Left.Color = Color.Black; //case 3
                            w.Color = Color.Red; //case 3
                            RightRotate(w); //case 3
                            w = x.Parent.Right; //case 3                        
                        }

                        w.Color = x.Parent.Color; //case 4
                        x.Parent.Color = Color.Black; //case 4
                        w.Right.Color = Color.Black; //case 4
                        LeftRotate(x.Parent); //case 4
                        x = root; //case 4
                    }
                }
                else
                {
                    w = x.Parent.Left;

                    if (w.Color == Color.Red)
                    {
                        w.Color = Color.Black;
                        x.Parent.Color = Color.Red;
                        RightRotate(x.Parent);
                        w = x.Parent.Left;
                    }
                    if (w.Right.Color == Color.Black && w.Right.Color == Color.Black)
                    {
                        w.Color = Color.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.Left.Color == Color.Black)
                        {
                            w.Right.Color = Color.Black;
                            w.Color = Color.Red;
                            LeftRotate(w);
                            w = x.Parent.Left;
                        }

                        w.Color = x.Parent.Color;
                        x.Parent.Color = Color.Black;
                        w.Right.Color = Color.Black;
                        RightRotate(x.Parent);
                        x = root;
                    }
                }
            }

            x.Color = Color.Black;
        }

        private Node<T> Minimum(Node<T> x)
        {
            while (x.Left != null)
            {
                x = x.Left;
            }

            return x;
        }


        private void LeftRotate(Node<T> x)
        {
            var y = x.Right;
            x.Right = y.Left;// turn Y's left subtree into X's right subtree

            if (y.Left != null)
            {
                y.Left.Parent = x;
            }

            y.Parent = x.Parent;//link X's parent to Y

            if (x.Parent == null)
            {
                this.root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }

            y.Left = x;//put X on Y's left
            x.Parent = y;
        }

        private void RightRotate(Node<T> y)
        {
            // right rotate is simply mirror code from left rotate
            var x = y.Left;
            y.Left = x.Right;

            if (x.Right != null)
            {
                x.Right.Parent = y;
            }

            x.Parent = y.Parent;

            if (y.Parent == null)
            {
                this.root = x;
            }
            else if (y == y.Parent.Right)
            {
                y.Parent.Right = x;
            }
            else
            {
                y.Parent.Left = x;
            }

            x.Right = y;//put Y on X's right
            y.Parent = x;
        }


        public class Node<V>
            where V : IComparable
        {
            public Node(V value)
            {
                this.Value = value;
                this.Color = Color.Red;
                this.Left = null;
                this.Right = null;
                this.Parent = null;
            }

            public Node(V value, Node<V> parent)
            {
                this.Value = value;
                this.Parent = parent;
                this.Left = null;
                this.Right = null;
            }

            public Node() { }

            public Color Color { get; set; }

            public Node<V> Left { get; set; }

            public Node<V> Right { get; set; }

            public Node<V> Parent { get; set; }

            public V Value { get; set; }
            public override string ToString()
            => string.Format("{0} -> {1}", this.Value, this.Color == Color.Red ? "Red" : "Black");
        }
    }
}
