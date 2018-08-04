using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.RTree.Source.Split
{
    public interface ISplitStrategy<T>
        where T: IComparable
    {
        SplitNodeResult<T> Split(RNode<T> overflowNode);
    }
}
