using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.Items
{
    public interface IBoundingBox<T>:ICloneable, IComparable
            where T : IComparable
    {
        Boolean Contains(IBoundingBox<T> otherBoundingBox);

        IBoundingBox<T> GetCoveredBoundingbox(IBoundingBox<T> otherBoundingBox);

        T GetArea();
    }
}
