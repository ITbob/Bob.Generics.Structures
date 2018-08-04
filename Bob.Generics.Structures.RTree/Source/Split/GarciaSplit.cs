using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.RTree.Source.Split
{
    public class GarciaSplit<T> : ISplitStrategy<T>
        where T : IComparable
    {
        //share 50 50 elements
        public SplitNodeResult<T> Split(RNode<T> overflowNode)
        {
            throw new NotImplementedException();
        }
    }
}
