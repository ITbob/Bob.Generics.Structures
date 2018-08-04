using Bob.Generics.Structures.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.RTree.Source.Add
{
    public interface ISearchNodeStrategy<T>
        where T:IComparable
    {
        RNode<T> GetNode(IEnumerable<RNode<T>> nodes, IBoundingBox<T> item);
    }
}
