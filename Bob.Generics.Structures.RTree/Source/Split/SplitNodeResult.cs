using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.RTree.Source.Split
{
    public struct SplitNodeResult<T>
        where T:IComparable
    {
        public RNode<T> A { get; set; }
        public RNode<T> B { get; set; }
    }
}
