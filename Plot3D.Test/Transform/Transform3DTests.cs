using System;
using Math3D.Core;
using Math3D.Transform;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Plot3D.Test.Transform
{
    [TestClass]
    public class Transform3DTests
    {
        [TestMethod]
        public void TransformChaining()
        {
            var expected = new Vector3(1, 0, 2);
            var transform = new Transform3D()
                .Translate(new Vector3(1, 0, 0))
                .RotateY(-Math.PI / 2)
                .Translate(new Vector3(2, 0, 0));
            var vector = new Vector3(0, 0, 0);
            var actual = transform.Apply(vector);

            Assert.AreEqual(expected, actual);
        }
    }
}
