using Math3D.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Plot3D.Test.Core
{
    [TestClass]
    public class MatrixMultiplicationTests
    {
        [TestMethod]
        public void IdentityTimesIdentityIsIdentity()
        {
            var expected = Matrix44.Identity;
            var actual = Matrix44.Identity * Matrix44.Identity;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RandomMatrixMultiplication()
        {
            // http://i.stack.imgur.com/ehGJn.gif
            var expected = new Matrix44(
                -1, +0, +0, +0,
                +0, +1, +0, +0,
                +0, +0, -1, +0,
                +0, -1, -1, +1
            );

            var matrixA = new Matrix44(
                -1, +0, +0, +0,
                +0, +1, +0, +0,
                +0, +0, -1, +0,
                +0, +0, +0, +1
            );

            var matrixB = new Matrix44(
                +1, +0, +0, +0,
                +0, +1, +0, +0,
                +0, +0, +1, +0,
                +0, -1, -1, +1
            );

            var actual = matrixA * matrixB;
            Assert.AreEqual(expected, actual);
        }
    }
}
