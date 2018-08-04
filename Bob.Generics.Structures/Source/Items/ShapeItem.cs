using Bob.Generics.Structures.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures
{
    public abstract class ShapeItem<T>
        where T :IComparable
    {
        public abstract IBoundingBox<T> BoundingBox { get; }
    }
}
