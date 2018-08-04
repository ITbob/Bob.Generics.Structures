using Bob.Generics.Structures.Items;
using Bob.Generics.Structures.RTree.Source.Split;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.RTree.Source
{
    public class RNode<T>
        where T:IComparable
    {
        public IBoundingBox<T> BoundingBox { get; set; }
        public ISplitStrategy<T> SplitStrategy { get; set; }

        public IList<ShapeItem<T>> Items { get; set; }
        public RTreeConfig Config { get; }

        public RNode<T> Parent { get; set; } = null;
        public IList<RNode<T>> Children { get; set; }

        public Boolean IsRoot => this.Parent == null;
        public Boolean IsLeaf => this.Children.Count == 0;

        public RNode(RTreeConfig config, ISplitStrategy<T> splitStrategy)
        {
            this.SplitStrategy = splitStrategy;
            this.Config = config;
            this.Children = new List<RNode<T>>();
            this.Items = new List<ShapeItem<T>>();
        }

        public void Add(ShapeItem<T> item)
        {
            if (this.Items.Count == 0)
            {
                this.BoundingBox = (IBoundingBox<T>)item.BoundingBox.Clone();
                this.Items.Add(item);
                return;
            }

            if (!this.BoundingBox.Contains(item.BoundingBox))
            {
                this.BoundingBox = this.BoundingBox.GetCoveredBoundingbox(item.BoundingBox);
            }

            this.Items.Add(item);

            if (this.Config.Max < this.Items.Count)
            {
                this.Split();
            }
        }

        private void Split()
        {
            var result = this.SplitStrategy.Split(this);
            result.A.Parent = this;
            result.B.Parent = this;
            this.Children.Add(result.A);
            this.Children.Add(result.B);
            this.Items.Clear();
        }

        public EventHandler Splitting;

        private void OnSplitting()
        {
            this.Splitting?.Invoke(this, EventArgs.Empty);
        }

        internal Boolean HasChildren()
        {
            return 0 < this.Children.Count;
        }
    }
}
