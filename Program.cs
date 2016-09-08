using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattersightCodingTest
{
    class Program
    {
        static void Main()
        {
            CBTreeAndNodeTools TreeTools = new CBTreeAndNodeTools();

            Console.WriteLine("Example 1");

            // Creating Nodes for the tree
            CNode leaf1 = new CNode
            {
                Name = "leaf1",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode leaf2 = new CNode
            {
                Name = "leaf2",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode leaf3 = new CNode
            {
                Name = "leaf3",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode leaf4 = new CNode
            {
                Name = "leaf4",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode node2 = new CNode
            {
                Name = "node2",
                IsLeaf = false,
                RightChild = leaf1,
                LeftChild = leaf2,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode node1 = new CNode
            {
                Name = "node1",
                IsLeaf = false,
                RightChild = node2,
                LeftChild = leaf3,
                ParentNodesStack = new Stack<CNode>()
            };


            // Create the root node 
            // This is the only input necessary to build the tree which is then mapped based on the root node
            CNode head = new CNode
            {
                Name = "head",
                IsLeaf = false,
                RightChild = node1,
                LeftChild = leaf4,
                Depth = 0,
                ParentNodesStack = new Stack<CNode>()
            };

            CBTree tree = new CBTree { RootNode = head };


            // tree mapping
            TreeTools.Map(tree);


            // Alter this function to search for a different Common parent between different nodes
            CNode CommonParent = TreeTools.ParentFinder(leaf1, leaf3);

            TreeTools.Draw(tree, CommonParent);

            //-------------------EXAMPLE 2------------------//

            Console.WriteLine();
            Console.WriteLine("Example 2");


            // Creating Nodes for the tree
            leaf1 = new CNode
            {
                Name = "leaf1",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            leaf2 = new CNode
            {
                Name = "leaf2",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            leaf3 = new CNode
            {
                Name = "leaf3",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            leaf4 = new CNode
            {
                Name = "leaf4",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode leaf5 = new CNode
            {
                Name = "leaf5",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode leaf6 = new CNode
            {
                Name = "leaf6",
                IsLeaf = true,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode node4 = new CNode
            {
                Name = "node4",
                IsLeaf = false,
                RightChild = leaf3,
                LeftChild = leaf5,
                ParentNodesStack = new Stack<CNode>()
            };

            CNode node3 = new CNode
            {
                Name = "node3",
                IsLeaf = false,
                RightChild = leaf6,
                LeftChild = node4,
                ParentNodesStack = new Stack<CNode>()
            };

            node2 = new CNode
            {
                Name = "node2",
                IsLeaf = false,
                RightChild = leaf1,
                LeftChild = leaf2,
                ParentNodesStack = new Stack<CNode>()
            };

            node1 = new CNode
            {
                Name = "node1",
                IsLeaf = false,
                RightChild = node2,
                LeftChild = node3,
                ParentNodesStack = new Stack<CNode>()
            };


            // Create the root node 
            // This is the only input necessary to build the tree which is then mapped based on the root node
            head = new CNode
            {
                Name = "head",
                IsLeaf = false,
                RightChild = node1,
                LeftChild = leaf4,
                Depth = 0,
                ParentNodesStack = new Stack<CNode>()
            };

            tree = new CBTree { RootNode = head };


            // tree mapping
            TreeTools.Map(tree);


            // Alter this function to search for a different Common parent between different nodes
            CommonParent = TreeTools.ParentFinder(leaf6, leaf5);

            TreeTools.Draw(tree, CommonParent);

            TreeTools.PrintExitLine();

            Console.ReadKey();
        }

    }
}
