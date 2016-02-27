using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Math3D.Core;

namespace Math3D.Bodies
{
    public class Face
    {
        public IReadOnlyList<Vector3> Vertices { get; }

        public Face(IEnumerable<Vector3> vertices)
        {
            var center = vertices.Aggregate((aggregate, current) => aggregate + current) / vertices.Count();
            var first = vertices.First();
            this.Vertices = new ReadOnlyCollection<Vector3>(
                vertices
                    //.OrderBy(vertex => Math.Acos( (first - center).Normalize() * (vertex - center).Normalize() ))
                    .ToList());
        }
    }
}