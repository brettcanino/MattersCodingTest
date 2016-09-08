using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattersightCodingTest
{
    class CNode
    {
        public string Name { get; set; }
        public bool IsLeaf { get; set; }
        public int Depth { get; set; }
        public CNode RightChild { get; set; }
        public CNode LeftChild { get; set; }
        public CNode Parent { get; set; }
        public Stack<CNode> ParentNodesStack { get; set; }

    }
}
