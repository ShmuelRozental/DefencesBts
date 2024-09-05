using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public class DefenseStrategiesBST
    {
        public BSTNode Root { get; private set; }

        public void Insert(int minSeverity, int maxSeverity, List<string> defenses)
        {
            Root = InsertRec(Root, minSeverity, maxSeverity, defenses);
        }


        //O(log n)
        private BSTNode InsertRec(BSTNode root, int minSeverity, int maxSeverity, List<string> defenses)
        {
            if (root == null)
            {
                return new BSTNode(minSeverity, maxSeverity, defenses);
            }

            if (minSeverity < root.MinSeverity)
            {
                root.Left = InsertRec(root.Left, minSeverity, maxSeverity, defenses);
            }
            else if (minSeverity > root.MinSeverity)
            {
                root.Right = InsertRec(root.Right, minSeverity, maxSeverity, defenses);
            }

            return root;
        }

        //O(n)
        public void PreOrderTraversal(BSTNode node)
        {
            if (node != null)
            {
                Console.WriteLine($"Severity Range: {node.MinSeverity}-{node.MaxSeverity}, Defenses: {string.Join(", ", node.Defenses)}");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public BSTNode Search(int severity)
        {
            return SearchRec(Root, severity);
        }


        //O(log n)
        private BSTNode SearchRec(BSTNode root, int severity)
        {
            if (root == null || (severity >= root.MinSeverity && severity <= root.MaxSeverity))
                return root;

            if (severity < root.MinSeverity)
                return SearchRec(root.Left, severity);

            return SearchRec(root.Right, severity);
        }

        public int Min()
        {
            if (Root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }
            return Min(Root);
        }

        //O(h)
        private int Min(BSTNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.MinSeverity;
        }
    }

}
