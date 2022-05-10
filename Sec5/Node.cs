using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sec5
{
    class Node
    {
        public int[,] State { get; set; }
        public int Depth { get; set; }
        public int PathCost { get; set; }
        public Node Parent { get; set; }

        // root constructor
        public Node(int[,] level)
        {
            this.State = level.Clone() as int[,];
            this.Depth = 0;
            this.PathCost = 0;
            this.Parent = null;
        }
        // child constructor
        public Node(Node current)
        {
            this.State = current.State.Clone() as int[,];
            this.Depth = current.Depth + 1;
            this.PathCost = current.PathCost + 1;
            this.Parent = current;
        }

        
        public List<Node> AddChildren()
        {
            List<Node> Childrens = new List<Node>();

            for (byte row = 0; row < 9; row++)
            {
                for (byte col = 0; col < 9; col++)
                {   
                    // if this box is not empty
                    if (this.State[row, col] ==  0)
                    {
                        for (byte value = 1; value < 10; value++)
                        {
                            // Check that this value is a valid value for this cell
                            if (isValidValue(value, row, col))
                            {
                                Childrens.Insert(0, new Node(this));
                                Childrens[0].State[row, col] = value;

                            }

                        }
                        return Childrens;
                    }
                }
            }
            return Childrens;
        }
        private bool isValidValue(int value, int i, int j)
        {

            for (int x = 0; x < 9; x++)
            {
                if (x != i && this.State[x, j] == value)
                    return false;
                if (x != j && this.State[i, x] == value)
                    return false;
            }

            for (int x = i - (i % 3); x < i - (i % 3) + 3; x++)
            {
                for (int y = j - (j % 3); y < j - (j % 3) + 3; y++)
                {
                    if (i != x && j != y && this.State[x, y] == value)
                        return false;
                }
            }
            return true;
        }


        

    }
}
