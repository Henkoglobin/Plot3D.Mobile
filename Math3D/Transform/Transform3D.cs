using Math3D.Core;

namespace Math3D.Transform
{
    public class Transform3D
    {
        private Matrix44 matrix = Matrix44.Identity;

        public Transform3D()
        { }

        public Transform3D(Matrix44 matrix)
        {
            this.matrix = matrix;
        }

        public Vector3 Apply(Vector3 vector)
            => (Vector3)(this.matrix * new Vector4(vector, 1.0));

        public Transform3D Reset()
        {
            this.matrix = Matrix44.Identity;
            return this;
        }

        public static Transform3D Identity()
            => new Transform3D();


        public Transform3D Translate(Vector3 offset)
        {
            this.matrix *= Matrix44.GetTranslation(offset.X, offset.Y, offset.Z);
            return this;
        }

        public Transform3D RotateY(double angle)
        {
            this.matrix *= Matrix44.GetRotationY(angle);
            return this;
        }

       
    }
}
