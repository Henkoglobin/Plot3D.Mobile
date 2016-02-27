using System;
using System.Diagnostics;
using System.Linq;
using Math3D.Auxiliary;
using Math3D.Bodies;
using Math3D.Core;
using Math3D.Transform;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;

namespace Plot3D.Mobile.Controls
{
    public class Plot3DView : NControlView
    {
        public static readonly BindableProperty MeshProperty = BindableProperty.Create<Plot3DView, Mesh>(o => o.Mesh, null);

        public Mesh Mesh
        {
            get { return (Mesh)this.GetValue(Plot3DView.MeshProperty); }
            set { this.SetValue(Plot3DView.MeshProperty, value); }
        }

        public Plot3DView()
        {
            this.Mesh = new Mesh(Meshes.CreateBox(0, 0, 0, 1, 1, 1));
        }

        public override void Draw(ICanvas canvas, Rect rect)
        {
            Func<Vector3, NGraphics.Point> toPoint = position => new NGraphics.Point(
                (position.X + 1.0) / 2.0 * rect.Width,
                (position.Y + 1.0) / 2.0 * rect.Height);

            var view = Matrix44.GetPerspective(Math.PI / 4, rect.Width / rect.Height, 0.1, 100.0);
            var viewTransform = new Transform3D(view)
                .Translate(new Vector3(0, 0, 6))
                ;
            foreach (var face in this.Mesh.Faces)
            {
                var prev = viewTransform.Apply(face.Vertices.Last());
                foreach (var vertex in face.Vertices)
                {
                    var position = viewTransform.Apply(vertex);

                    Debug.WriteLine($"{vertex} => {toPoint(position)}");

                    canvas.DrawLine(toPoint(prev), toPoint(position), new Pen(Colors.Red, 1));

                    prev = position;
                }
            }
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
            => new SizeRequest(new Xamarin.Forms.Size(widthConstraint, heightConstraint));
    }
}
