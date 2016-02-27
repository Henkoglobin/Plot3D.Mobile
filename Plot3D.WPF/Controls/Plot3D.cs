using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Math3D.Bodies;
using Math3D.Core;
using Math3D.Transform;
using Plot3D.WPF.Helpers;

namespace Plot3D.WPF.Controls
{
    public class Plot3D : ContentControl
    {
        public List<Mesh> Meshes
        {
            get { return (List<Mesh>)GetValue(MeshProperty); }
            set { SetValue(MeshProperty, value); }
        }

        public static readonly DependencyProperty MeshProperty =
            DependencyProperty.Register(nameof(Meshes), typeof(List<Mesh>), typeof(Plot3D), new PropertyMetadata(null));

        public BindableVector3 Offset
        {
            get { return (BindableVector3)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register("Offset", typeof(BindableVector3), typeof(Plot3D), new PropertyMetadata(null, onOffsetChanged));

        private static void onOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = (Plot3D)d;
            self.InvalidateVisual();
            self.Offset.PropertyChanged += (s, e2) => self.InvalidateVisual();
        }

        public Plot3D()
        {
            this.Meshes = new List<Mesh>() {
                new Mesh(Math3D.Auxiliary.Meshes.CreateBox(0, 0, 0, 1, 1, 1))
            };
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var width = this.ActualWidth;
            var height = this.ActualHeight;

            Func<Vector3, Point?> toPoint = position =>
                Math.Abs(position.Z) > 1
                    ? default(Point?)
                    : new Point(
                        (-position.X + 1.0) / 2.0 * width,
                        (position.Y + 1.0) / 2.0 * height);

            var view = Matrix44.GetPerspective(Math.PI / 4, width / height, 0.1, 100.0);
            var viewTransform = new Transform3D(view)
                .Translate(new Vector3(this.Offset?.X ?? 0.0, this.Offset?.Y ?? 0.0, this.Offset?.Z ?? 0.0))
                ;

            //var offset = new Vector3(this.Offset?.X ?? 0.0, this.Offset?.Y ?? 0.0, this.Offset?.Z ?? 0.0);

            foreach (var mesh in this.Meshes)
            {
                foreach (var face in mesh.Faces)
                {
                    var prev = viewTransform.Apply(face.Vertices.Last() /*+ offset*/);
                    foreach (var vertex in face.Vertices)
                    {
                        var position = viewTransform.Apply(vertex /*+ offset*/);

                        var pp = toPoint(prev);
                        var pc = toPoint(position);

                        if(pp.HasValue && pc.HasValue)
                        {
                            drawingContext.DrawLine(new Pen(Brushes.Red, 1), pp.Value, pc.Value);
                        }
                        
                        prev = position;
                    }
                }
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return constraint;
        }
    }
}
