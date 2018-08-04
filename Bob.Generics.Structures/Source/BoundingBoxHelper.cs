using Bob.Generics.Structures.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.Source
{
    public static class BoundingBoxHelper<T>
        where T:IComparable
    {

        public static T Add(T number1, T number2) //dirty, let's check that letter
        {
            dynamic a = number1;
            dynamic b = number2;
            return a + b;
        }

        public static T Multi(T number1, T number2) //dirty, let's check that letter
        {
            dynamic a = number1;
            dynamic b = number2;
            return a * b;
        }

        public static T Substract(T number1, T number2) //dirty, let's check that letter
        {
            dynamic a = number1;
            dynamic b = number2;
            return a - b;
        }

        public static T GetDiffCoveredArea(IBoundingBox<T> bb1, IBoundingBox<T> bb2)
        {
            var coverdArea = bb1.GetCoveredBoundingbox(bb2);
            return Substract(coverdArea.GetArea(), bb1.GetArea());
        }

        public static BoundingBox2D<T> GetBoundingBox(T width, T height)
        {
            return new BoundingBox2D<T>()
            {
                Width = width,
                Height = height
            };
        }

    }
}
