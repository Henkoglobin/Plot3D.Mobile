using System;
using Math3D.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Plot3D.Test.Core
{
    [TestClass]
    public class MatrixVectorMultiplicationTests
    {
        [TestMethod]
        public void SomeRandomMultiplication1()
        {
            // http://developer.amd.com/wordpress/media/2013/01/fig01.jpg
            var expected = new Vector4(4, 47, 5, 68);

            var matrix = new Matrix44(
                1, 0, 2, 0,
                0, 3, 0, 4,
                0, 0, 5, 0,
                6, 0, 0, 7
            );
            var vector = new Vector4(2, 5, 1, 8);

            var actual = matrix * vector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SomeRandomMultiplication2()
        {
            // http://developer.amd.com/wordpress/media/2013/01/fig01.jpg
            var expected = new Vector4(18, 2, 1, 1.2);

            var matrix = new Matrix44(
                 0.0, 2.0, 5.0, 2.0,
                 0.4, 0.0, 0.0, 0.0,
                 0.0, 0.5, 0.0, 0.0,
                 0.0, 0.0, 0.6, 0.0
            );
            var vector = new Vector4(5, 2, 2, 2);

            var actual = matrix * vector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TranslateVector()
        {
            var expected = new Vector4(1, 2, 3, 1);
            var matrix = Matrix44.GetTranslation(0, 1, 2);
            var vector = new Vector4(1, 1, 1, 1);
            var actual = matrix * vector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScaleVector()
        {
            var expected = new Vector4(2, 6, 12, 1);
            var matrix = Matrix44.GetScale(2, 3, 4);
            var vector = new Vector4(1, 2, 3, 1);
            var actual = matrix * vector;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RotateVector()
        {
            var expected = new Vector4(0, 0, 1, 1);
            var matrix = Matrix44.GetRotationX(Math.PI / 2.0);
            var vector = new Vector4(0, 1, 0, 1);
            var actual = matrix * vector;

            Assert.AreEqual(expected, actual);
        }
    }
}
