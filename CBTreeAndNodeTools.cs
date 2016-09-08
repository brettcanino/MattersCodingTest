using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MattersightCodingTest
{
    class CBTreeAndNodeTools
    {

        public void Map(CNode node, CBTree tree)
        {
            if (node.IsLeaf)
            {
                return;
            }

            CNode RightChild = node.RightChild;
            CNode LeftChild = node.LeftChild;

            if (RightChild != null)
            {
                SetDataForChildNode(node, RightChild);

                if (RightChild.Depth > tree.MaxDepth)
                {
                    tree.MaxDepth = RightChild.Depth;
                }

                Map(RightChild, tree);
            }

            if (LeftChild != null)
            {
                SetDataForChildNode(node, LeftChild);

                if (LeftChild.Depth > tree.MaxDepth)
                {
                    tree.MaxDepth = LeftChild.Depth;
                }

                Map(LeftChild, tree);
            }
        }

        public void Map(CBTree Tree)
        {
            Tree.RootNode.Depth = 0;
            Map(Tree.RootNode, Tree);
        }

        private void SetDataForChildNode(CNode node, CNode Child)
        {
            Child.Depth = node.Depth + 1;
            Child.ParentNodesStack = new Stack<CNode>(new Stack<CNode>(node.ParentNodesStack));
            Child.ParentNodesStack.Push(node);
            Child.Parent = node;
        }

        private static void PrintPreliminatyParentFindingInfo(CNode n1, CNode n2)
        {
            Console.WriteLine(GetPreliminaryCommonParentString() + n1.Name + And() + n2.Name + Period());
            Console.WriteLine("");
        }

        private static void PrintFailedParentFindingInfo(CNode n1, CNode n2)
        {
            Console.WriteLine(GetFailedCommonParentString() + n1.Name + And() + n2.Name + Period());
            Console.WriteLine("");
        }

        public CNode ParentFinder(CNode n1, CNode n2)
        {
            PrintPreliminatyParentFindingInfo(n1, n2);

            CNode n1Parent = n1.ParentNodesStack.Pop();
            CNode n2Parent = n2.ParentNodesStack.Pop();

            while (n1Parent.Name != n2Parent.Name &&
                   n1Parent != null &&
                   n2Parent != null)
            {
                if (n1Parent.Depth > n2Parent.Depth)
                {
                    n1Parent = n1.ParentNodesStack.Pop();
                }
                else if (n1Parent.Depth < n2Parent.Depth)
                {
                    n2Parent = n2.ParentNodesStack.Pop();
                }
                else
                {
                    n1Parent = n1.ParentNodesStack.Pop();
                    n2Parent = n2.ParentNodesStack.Pop();
                }
            }

            if (n1Parent.Name == n2Parent.Name)
            {
                return n1Parent;
            }
            else
            {
                return null;
            }
        }

        public void Draw(CBTree tree, CNode commonParent)
        {
            DrawBranch(tree.MaxDepth, 0, tree.RootNode, commonParent);
        }

        private void DrawBranch(double maxDepth, int currentDepth, CNode node, CNode commonParent)
        {
            if (node == null)
            {
                return;
            }

            if (currentDepth == 0)
            {
                Console.Write(GetNodeHeader() + node.Name);
            }
            else if (currentDepth == 1)
            {
                Console.Write(GetDepthSeperatorForDepth1() + GetNodeHeader() + node.Name);
            }
            else if (currentDepth >= 2)
            {
                Console.Write(GetDepthSeperatorForDepth1());

                for (int i = 2; i <= currentDepth; i++)
                {
                    Console.Write(GetDepthSeperatorGreaterThan1());
                }

                Console.Write(GetNodeHeader() + node.Name);
            }

            if (node.Name == commonParent.Name)
            {
                Console.WriteLine(GetCommonParentString());
            }
            else
            {
                Console.WriteLine();
            }

            if (!node.IsLeaf)
            {
                DrawBranch(maxDepth, currentDepth + 1, node.LeftChild, commonParent);
                DrawBranch(maxDepth, currentDepth + 1, node.RightChild, commonParent);
            }

        }

        public void PrintExitLine()
        {
            Console.WriteLine();
            Console.Write(ExitString());
        }

        private static string GetNodeHeader()
        {
            return "+- ";
        }

        private static string GetDepthSeperatorForDepth1()
        {
            return "   ";
        }

        private static string GetDepthSeperatorGreaterThan1()
        {
            return "|  ";
        }

        private static string GetCommonParentString()
        {
            return " -- COMMON PARENT --";
        }

        private static string GetFailedCommonParentString()
        {
            return "No common parent was found between nodes ";
        }

        private static string GetPreliminaryCommonParentString()
        {
            return "Looking for the common parent for nodes ";
        }

        private static string And()
        {
            return " and ";
        }

        private static string Period()
        {
            return ".";
        }

        private static string ExitString()
        {
            return "Press any key to exit...";
        }
    }
}
