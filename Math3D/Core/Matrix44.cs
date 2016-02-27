using System;
using System.Linq;
using StandardLibrary.Extensions;
using StandardLibrary.PatternHelpers;

namespace Math3D.Core
{
    public struct Matrix44
    {
        public static readonly Matrix44 Identity = new Matrix44(
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        );

        private readonly double[] values;

        public Matrix44(params double[] values)
        {
            if (values.Length != 16) throw new ArgumentException();
            this.values = values;
        }

        public double this[int row, int column]
            => this.values[row * 4 + column];

        public double this[int index]
            => this.values[index];

        public Matrix44 Transpose()
        {
            var self = this;
            var result = from row in Enumerable.Range(0, 4)
                         from column in Enumerable.Range(0, 4)
                         select self[column, row];
            return new Matrix44(result.ToArray());
        }

        public static Matrix44 operator *(Matrix44 matrix1, Matrix44 matrix2)
        {
            var result = from i in Enumerable.Range(0, 4)
                         from j in Enumerable.Range(0, 4)
                         select Enumerable.Range(0, 4).Sum(k => matrix1[i, k] * matrix2[k, j]);

            return new Matrix44(result.ToArray());
        }

        public static Vector4 operator *(Matrix44 matrix, Vector4 vector)
        {
            var result = from i in Enumerable.Range(0, 4)
                         select Enumerable.Range(0, 4).Sum(k => matrix[i, k] * vector[k]);
            return new Vector4(result.ToArray());
        }

        public static Matrix44 operator +(Matrix44 matrix1, Matrix44 matrix2)
        {
            var result = from i in Enumerable.Range(0, 16)
                         select matrix1[i] + matrix2[i];
            return new Matrix44(result.ToArray());
        }

        public override bool Equals(object obj)
        {
            var other = obj as Matrix44?;
            if (other == null) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return this.values.SequenceEqual(other.Value.values,
                new StrategyComparer<double>((x, y) => x.EqualsAlmost(y)));
        }

        public static Matrix44 GetTranslation(double offsetX, double offsetY, double offsetZ)
            => new Matrix44(
                1, 0, 0, offsetX,
                0, 1, 0, offsetY,
                0, 0, 1, offsetZ,
                0, 0, 0, 1
            );

        public static Matrix44 GetScale(double scaleX, double scaleY, double scaleZ)
            => new Matrix44(
                scaleX, 0, 0, 0,
                0, scaleY, 0, 0,
                0, 0, scaleZ, 0,
                0, 0, 0, 1
            );

        public static Matrix44 GetRotationX(double angle)
            => new Matrix44(
                1, 0, 0, 0,
                0, Math.Cos(angle), -Math.Sin(angle), 0,
                0, Math.Sin(angle), Math.Cos(angle), 0,
                0, 0, 0, 1
            );

        public static Matrix44 GetRotationY(double angle)
            => new Matrix44(
                Math.Cos(angle), 0, Math.Sin(angle), 0,
                0, 1, 0, 0,
                -Math.Sin(angle), 0, Math.Cos(angle), 0,
                0, 0, 0, 1
            );

        public static Matrix44 GetRotationZ(double angle)
            => new Matrix44(
                Math.Cos(angle), -Math.Sin(angle), 0, 0,
                Math.Sin(angle), Math.Cos(angle), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );

        public static Matrix44 GetRotation(double axisX, double axisY, double axisZ, double angle)
        {
            var cosa = Math.Cos(angle);
            var icosa = 1 - cosa;
            var sina = Math.Sin(angle);

            return new Matrix44(
                axisX * axisX * icosa + cosa,
                axisX * axisY * icosa - axisZ * sina,
                axisX * axisZ * icosa + axisY * sina,
                0,
                axisY * axisX * icosa + axisZ * sina,
                axisY * axisY * icosa + cosa,
                axisY * axisZ * icosa - axisX * sina,
                0,
                axisZ * axisX * icosa - axisY * sina,
                axisZ * axisY * icosa + axisX * sina,
                axisZ * axisZ * icosa + cosa,
                0,
                0, 0, 0, 1
            );
        }

        public static Matrix44 GetOrthographic(double left, double right, double bottom, double top, double zNear, double zFar)
            => new Matrix44(
                2 / (right - left), 0, 0, -(right + left) / (right - left),
                0, 2 / (top - bottom), 0, -(top + bottom) / (top - bottom),
                0, 0, -2 / (zFar - zNear), -(zFar + zNear) / (zFar - zNear),
                0, 0, 0, 1
            );

        public static Matrix44 GetPerspective(double fovY, double aspect, double zNear, double zFar)
        {
            var f = 1 / Math.Tan(fovY / 2.0);
            return new Matrix44(
                f / aspect, 0, 0, 0,
                0, f, 0, 0,
                0, 0, (zFar + zNear) / (zFar - zNear), 2 * (zNear * zFar) / (zNear - zFar),
                0, 0, -1, 0
            );
        }
    }
}
