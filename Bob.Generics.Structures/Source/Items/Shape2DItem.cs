using Bob.Generics.Structures.Items;
using Bob.Generics.Structures.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures
{
    //maybe has to refactor, I am not really satisfied with this solution
    public class Shape2DItem<T> : ShapeItem<T>
        where T : IComparable
    {
        public BoundingBox2D<T> BoundingBox2D { get; set; }

        public override IBoundingBox<T> BoundingBox => this.BoundingBox2D;
    }
}
