using Bob.Generics.Structures.Source;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Bob.Generic.BoundingBox.Test.Source
{
    [TestFixture]
    public class BoundingBoxFeatures
    {
        [Test]
        public void ShouldGet9Area()
        {
            var rectangle = new BoundingBox2D<Int32>();
            rectangle.Width = 3;
            rectangle.Height = 3;

            Assert.Equals(9, rectangle.GetArea());
        }

        [Test]
        public void ShouldGet4x3Bb()
        {
            var rectangle = BoundingBoxHelper<Int32>.GetBoundingBox(3, 3);
            var rectangle2 = BoundingBoxHelper<Int32>.GetBoundingBox(4, 3);

            var coverdArea = (BoundingBox2D<Int32>) rectangle.GetCoveredBoundingbox(rectangle2);

            Assert.AreEqual(4, coverdArea.Width);
            Assert.AreEqual(3, coverdArea.Height);

        }

        [Test]
        public void ShouldGet4x4Bb()
        {
            var rectangle = BoundingBoxHelper<Int32>.GetBoundingBox(3, 4);
            var rectangle2 = BoundingBoxHelper<Int32>.GetBoundingBox(4, 3);

            var coverdArea = (BoundingBox2D<Int32>)rectangle.GetCoveredBoundingbox(rectangle2);

            Assert.AreEqual(4, coverdArea.Width);
            Assert.AreEqual(4, coverdArea.Height);

        }

        [Test]
        public void ShouldGet0Diff()
        {
            var rectangle = BoundingBoxHelper<Int32>.GetBoundingBox(3, 3);
            var rectangle2 = BoundingBoxHelper<Int32>.GetBoundingBox(4, 3);

            var diff = BoundingBoxHelper<Int32>.GetDiffCoveredArea(rectangle2, rectangle);
            Assert.AreEqual(0, diff);
        }

        [Test]
        public void ShouldGet3Diff()
        {
            var rectangle = BoundingBoxHelper<Int32>.GetBoundingBox(3, 3);
            var rectangle2 = BoundingBoxHelper<Int32>.GetBoundingBox(4, 3);

            var diff = BoundingBoxHelper<Int32>.GetDiffCoveredArea(rectangle, rectangle2);
            Assert.AreEqual(3, diff);
        }

    }
}
