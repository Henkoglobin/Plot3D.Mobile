using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Math3D.Bodies
{
    public class Mesh
    {
        public IReadOnlyList<Face> Faces { get; }

        public Mesh(IEnumerable<Face> faces)
        {
            this.Faces = new ReadOnlyCollection<Face>(faces.ToList());
        }
    }
}
