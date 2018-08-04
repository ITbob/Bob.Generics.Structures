using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bob.Generics.Structures.Source;
using Bob.Generics.Structures.RTree.Source.Add;
using Bob.Generics.Structures.RTree.Source.Search;

namespace Bob.Generics.Structures.RTree.Source.Split
{
    public class GuttmanSplit<T> : ISplitStrategy<T>
        where T : IComparable
    {
        public SplitNodeResult<T> Split(RNode<T> overflowNode)
        {
            var worstCouple = GetWorstCouple(overflowNode.Items);

            var result1 = new RNode<T>(overflowNode.Config, overflowNode.SplitStrategy);
            var result2 = new RNode<T>(overflowNode.Config, overflowNode.SplitStrategy);

            result1.Add(overflowNode.Items.ElementAt(worstCouple.IndexA));
            result2.Add(overflowNode.Items.ElementAt(worstCouple.IndexB));

            if(worstCouple.IndexA < worstCouple.IndexB)
            {
                overflowNode.Items.RemoveAt(worstCouple.IndexB);
                overflowNode.Items.RemoveAt(worstCouple.IndexA);
            }
            else
            {
                overflowNode.Items.RemoveAt(worstCouple.IndexA);
                overflowNode.Items.RemoveAt(worstCouple.IndexB);
            }

            var nodes = new List<RNode<T>>() {
                result1,
                result2
            };

            foreach (var item in overflowNode.Items)
            {
                var node = SearchHelper<T>.GetLessEnlargementNode(nodes, item.BoundingBox);
                node.Add(item);
            }

            return new SplitNodeResult<T>()
            {
                A = result1,
                B = result2
            };
        }

        public WorstCouple GetWorstCouple(IEnumerable<ShapeItem<T>> items)
        {
            var worstCouple = new WorstCouple();

            var currentCoverArea = BoundingBoxHelper<T>.GetDiffCoveredArea(
                items.ElementAt(0).BoundingBox
                , items.ElementAt(1).BoundingBox);

            for (int i = 0; i < items.Count(); i++)
            {
                for (int l = 0; l < items.Count(); l++)
                {
                    if (l != i)
                    {
                        var coverArea = BoundingBoxHelper<T>.GetDiffCoveredArea(
                                    items.ElementAt(i).BoundingBox
                                    , items.ElementAt(l).BoundingBox);

                        if (coverArea.CompareTo(currentCoverArea) > 0)
                        {
                            currentCoverArea = coverArea;
                            worstCouple.IndexA = i;
                            worstCouple.IndexB = l;
                        }
                    }
                }
            }

            return worstCouple;
        }

        public class WorstCouple
        {
            public Int32 IndexA { get; set; }
            public Int32 IndexB { get; set; }
        }
    }
}
