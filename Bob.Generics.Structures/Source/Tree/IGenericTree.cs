using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.Tree
{
    public interface IGenericTree<T>
        where T : IComparable
    {
        Int32 Count { get; }
        Boolean Add(ShapeItem<T> item);
    }
}
