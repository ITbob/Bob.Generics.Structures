using Bob.Generics.Structures.Items;
using Bob.Generics.Structures.RTree.Source.Add;
using Bob.Generics.Structures.RTree.Source.Split;
using Bob.Generics.Structures.Source;
using Bob.Generics.Structures.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bob.Generics.Structures.RTree.Source
{
    public class RTree<T>: IGenericTree<T>
        where T: IComparable
    {
        private RNode<T> Node { get; set; }
        public Int32 Count { get; private set; }
        public RTreeConfig Config { get; }
        public ISearchNodeStrategy<T> AddStrategy { get; }
        public ISplitStrategy<T> SplitStrategy { get; }

        public RTree()
        {
            this.Config = new RTreeConfig()
            {
                Max = 5,
                Min = 2
            };

            this.AddStrategy = new SearchLessEnlargementStrategy<T>();
            this.SplitStrategy = new GuttmanSplit<T>();
        }

        public Boolean Contains(IBoundingBox<T> area)
        {
            if(this.Node == null)
            {
                return false;
            }
            else
            {
                return this.Contains(this.Node, area);
            }
        }

        private Boolean Contains(RNode<T> node, IBoundingBox<T> area)
        {
            if (!node.BoundingBox.Contains(area))
            {
                return false;
            }
            else
            {
                if (node.IsLeaf)
                {
                    foreach (var item in node.Items)
                    {
                        if(area.CompareTo(item) == 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {

                    foreach (var child in node.Children)
                    {
                        if (child.BoundingBox.Contains(area))
                        {
                            return this.Contains(child, area);
                        }
                    }
                    return false;
                }
            }

 
        }

        public Boolean Add(ShapeItem<T> item)
        {
            if(this.Node == null)
            {
                this.Node = new RNode<T>(this.Config,this.SplitStrategy);
                this.Node.Add(item);
                this.Count += 1;
                return true;
            }
            else
            {
                this.Add(this.Node, item);
            }
            return false;
        }

        private void Add(RNode<T> currentNode,ShapeItem<T> item)
        {
            if (!currentNode.HasChildren())
            {
                currentNode.Add(item);
            }
            else
            {
                this.Add(this.AddStrategy.GetNode(currentNode.Children, item.BoundingBox), item);
            }
        }

        public override string ToString()
        {
            var text = String.Empty;
            this.ToString(this.Node, ref text);
            return text;
        }

        private void ToString(RNode<T> currentNode, ref String text)
        {
            if (currentNode.IsLeaf)
            {
                text += $"Node {this.Node.BoundingBox.ToString()}{Environment.NewLine}";
                foreach (var item in currentNode.Items)
                {
                    text += $"{item.BoundingBox.ToString()}";
                }
                text += Environment.NewLine;
            }
            else
            {
                text += $"Node {this.Node.BoundingBox.ToString()}{Environment.NewLine}";
                foreach (var child in currentNode.Children)
                {
                    this.ToString(child, ref text);
                }
            }
        }
    }
}
