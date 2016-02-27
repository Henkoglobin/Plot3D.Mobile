using System.Collections.Generic;
using Math3D.Bodies;
using Math3D.Core;

namespace Math3D.Auxiliary
{
    public static class Meshes
    {
        public static IEnumerable<Face> CreateBox(double x, double y, double z, double width, double height, double depth)
        {
            var a = width / 2.0;
            var b = height / 2.0;
            var c = depth / 2.0;


            // Front
            yield return new Face(new[] {
                new Vector3(x - a, y - b, z + c),
                new Vector3(x + a, y - b, z + c),
                new Vector3(x + a, y + b, z + c),
                new Vector3(x - a, y + b, z + c),
            });

            //Back

            yield return new Face(new[] {
                new Vector3(x - a, y + b, z - c),
                new Vector3(x + a, y + b, z - c),
                new Vector3(x + a, y - b, z - c),
                new Vector3(x - a, y - b, z - c),
            });

            //Top

            yield return new Face(new[] {
                new Vector3(x - a, y + b, z - c),
                new Vector3(x - a, y + b, z + c),
                new Vector3(x + a, y + b, z + c),
                new Vector3(x + a, y + b, z - c),
            });

            //Bottom

            yield return new Face(new[] {
                new Vector3(x - a, y - b, z - c),
                new Vector3(x + a, y - b, z - c),
                new Vector3(x + a, y - b, z + c),
                new Vector3(x - a, y - b, z + c),
            });

            //Left

            yield return new Face(new[] {
                new Vector3(x - a, y - b, z + c),
                new Vector3(x - a, y + b, z + c),
                new Vector3(x - a, y + b, z - c),
                new Vector3(x - a, y - b, z - c),
            });

            //Right

            yield return new Face(new[] {
                new Vector3(x + a, y - b, z - c),
                new Vector3(x + a, y + b, z - c),
                new Vector3(x + a, y + b, z + c),
                new Vector3(x + a, y - b, z + c),
            });
        }
    }
}
