using Bob.Generics.Structures;
using Bob.Generics.Structures.RTree.Source;
using Bob.Generics.Structures.RTree.Source.Split;
using Bob.Generics.Structures.Source;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace Bob.Genercis.Structures.RTree.Test.Source
{
    [TestFixture]
    public class RtreeFeatures
    {
        [Test]
        public void ShouldAddAnElement()
        {
            var shape = Shape2DFactory.GetShape();
            var tree = new RTree<Int32>();
            tree.Add(shape);

            Assert.AreEqual(1, tree.Count);
        }

        [Test]
        public void ShouldIncreaseNodeArea()
        {
            var config = new RTreeConfig()
            {
                Max = 5,
                Min = 2
            };
            var node = new RNode<Int32>(config, new GuttmanSplit<Int32>());

            var elemets = new List<Shape2DItem<Int32>>()
            {
                Shape2DFactory.GetShape(0,0,10,10),
                Shape2DFactory.GetShape(15,10,10,10),
                //Shape2DFactory.GetShape(30,0,10,10),
                //Shape2DFactory.GetShape(45,0,10,10),
                //Shape2DFactory.GetShape(60,0,10,10),
                //Shape2DFactory.GetShape(75,0,10,10),
            };

            foreach (var item in elemets)
            {
                node.Add(item);
            }

            Assert.AreEqual(25, ((BoundingBox2D<Int32>)node.BoundingBox).Right);
            Assert.AreEqual(20, ((BoundingBox2D<Int32>)node.BoundingBox).Bottom);
        }

        [Test]
        public void ShouldGetWorstCouple()
        {
            var nodeStrategy = new GuttmanSplit<Int32>();

            var elemets = new List<Shape2DItem<Int32>>()
            {
                Shape2DFactory.GetShape(0,0,10,10),
                Shape2DFactory.GetShape(15,10,10,10),
                Shape2DFactory.GetShape(30,0,10,10),
                Shape2DFactory.GetShape(75,0,10,10),
                Shape2DFactory.GetShape(45,0,10,10),
                Shape2DFactory.GetShape(60,0,10,10),
            };

            var worstCouple = nodeStrategy.GetWorstCouple(elemets);

            Assert.AreEqual(0, elemets.ElementAt(worstCouple.IndexA).BoundingBox2D.X);
            Assert.AreEqual(75, elemets.ElementAt(worstCouple.IndexB).BoundingBox2D.X);
        }

        [Test]
        public void ShouldAdd7Elements()
        {
            var elemets = new List<Shape2DItem<Int32>>()
            {
                Shape2DFactory.GetShape(0,0,10,10),
                Shape2DFactory.GetShape(15,0,10,10),
                Shape2DFactory.GetShape(30,0,10,10),
                Shape2DFactory.GetShape(45,0,10,10),
                Shape2DFactory.GetShape(60,0,10,10),
                Shape2DFactory.GetShape(75,0,10,10),
            };

            var tree = new RTree<Int32>();

            foreach (var item in elemets)
            {
                tree.Add(item);
            }

            Debug.WriteLine(tree.ToString());

            Assert.Fail();
        }

        

    }
}
