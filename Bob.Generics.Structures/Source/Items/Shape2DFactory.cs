using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures
{
    public static class Shape2DFactory
    {
        public static Shape2DItem<Int32> GetShape()
        {
            return new Shape2DItem<Int32>()
            {
                BoundingBox2D = new Source.BoundingBox2D<int>() { 
                    X = 0,
                    Y = 0,
                    Width = 10,
                    Height = 10
                }
            };
        }

        public static Shape2DItem<Int32> GetShape(Int32 x, Int32 y, Int32 width, Int32 height)
        {
            return new Shape2DItem<Int32>()
            {
                BoundingBox2D = new Source.BoundingBox2D<int>()
                {
                    X = x,
                    Y = y,
                    Width = width,
                    Height = height
                }
            };
        }
    }
}
