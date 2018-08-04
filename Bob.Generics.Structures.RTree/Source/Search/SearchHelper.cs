using Bob.Generics.Structures.Items;
using Bob.Generics.Structures.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bob.Generics.Structures.RTree.Source.Search
{
    public static class SearchHelper<T>
        where T : IComparable
    {
        public static RNode<T> GetLessEnlargementNode(IEnumerable<RNode<T>> nodes, IBoundingBox<T> item)
        {
            var nextNode = nodes.First();
            var coverdArea = nextNode.BoundingBox.GetCoveredBoundingbox(item);
            var diff = BoundingBoxHelper<T>.Substract(coverdArea.GetArea(), nextNode.BoundingBox.GetArea());

            //get node by trying to get the less enlargement
            for (int i = 1; i < nodes.Count(); i++)
            {
                var diff2 = BoundingBoxHelper<T>.GetDiffCoveredArea(item, nodes.ElementAt(i).BoundingBox);

                if (diff2.CompareTo(diff) < 0)
                {
                    nextNode = nodes.ElementAt(i);
                }
            }
            return nextNode;
        }
    }
}
