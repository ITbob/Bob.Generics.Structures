using Bob.Generics.Structures.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bob.Generics.Structures.Source
{
    public class BoundingBox2D<T>:IBoundingBox<T>
        where T : IComparable
    {
        public T X { get; set; }
        public T Y { get; set; }

        public T Width { get; set; }
        public T Height { get; set; }

        public T Right => BoundingBoxHelper<T>.Add(this.X, this.Width);

        public T Bottom => BoundingBoxHelper<T>.Add(this.Y, this.Height);


        public object Clone()
        {
            return new BoundingBox2D<T>()
            {
                X = this.X,
                Y = this.Y,
                Width = this.Width,
                Height = this.Height
            };
        }

        public Int32 CompareTo(object obj)
        {
            if (obj is BoundingBox2D<T>)
            {
                var bb2 = (BoundingBox2D<T>) obj;
                return this.GetArea().CompareTo(bb2.GetArea());
            }
            else
            {
                //thta's bad need to create specific exepction
                throw new ApplicationException(@"not adequat dimension");
            }
        }

        public bool Contains(IBoundingBox<T> otherBoundingBox)
        {
            if(otherBoundingBox is BoundingBox2D<T>)
            {
                var other2DBoundingBox = (BoundingBox2D<T>) otherBoundingBox;
                return this.X.CompareTo(other2DBoundingBox.X) <= 0 
                    && this.Y.CompareTo(other2DBoundingBox.Y) <= 0
                    && this.Right.CompareTo(other2DBoundingBox.Right) >= 0
                    && this.Bottom.CompareTo(other2DBoundingBox.Bottom) >= 0;
            }
            else
            {
                throw new ApplicationException(@"not adequat dimension");
            }            
        }

        public T GetArea()
        {
            return BoundingBoxHelper<T>.Multi(this.Width, this.Height);
        }

        public IBoundingBox<T> GetCoveredBoundingbox(IBoundingBox<T> otherBoundingBox)
        {
            if (otherBoundingBox is BoundingBox2D<T>)
            {
                var other2DBoundingBox = (BoundingBox2D<T>)otherBoundingBox;

                var coveredBb = (BoundingBox2D<T>) this.Clone();

                if (this.X.CompareTo(other2DBoundingBox.X) > 0)
                {
                    coveredBb.X = other2DBoundingBox.X;
                }

                if (this.Y.CompareTo(other2DBoundingBox.Y) > 0)
                {
                    coveredBb.Y = other2DBoundingBox.Y;
                }

                if (this.Right.CompareTo(other2DBoundingBox.Right) < 0)
                {
                    coveredBb.Width = BoundingBoxHelper<T>.Add(this.Width, 
                        BoundingBoxHelper<T>.Substract(other2DBoundingBox.Right, this.Right));
                }

                if (this.Bottom.CompareTo(other2DBoundingBox.Bottom) < 0)
                {
                    coveredBb.Height = BoundingBoxHelper<T>.Add(this.Height, 
                        BoundingBoxHelper<T>.Substract(other2DBoundingBox.Bottom, this.Bottom));
                }

                return coveredBb;
            }
            else
            {
                throw new ApplicationException(@"not adequat dimension");
            }

        }

        public override string ToString()
        {
            return $"[{this.X},{this.Y},{this.Right},{this.Bottom}]";
        }
    }
}
