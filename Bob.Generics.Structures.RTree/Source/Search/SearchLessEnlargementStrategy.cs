using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bob.Generics.Structures.Items;
using Bob.Generics.Structures.RTree.Source.Search;
using Bob.Generics.Structures.Source;

namespace Bob.Generics.Structures.RTree.Source.Add
{
    public class SearchLessEnlargementStrategy<T> : ISearchNodeStrategy<T>
        where T : IComparable
    {
        public RNode<T> GetNode(IEnumerable<RNode<T>> nodes, IBoundingBox<T> item)
        {
            return SearchHelper<T>.GetLessEnlargementNode(nodes, item);
        }
    }
}
