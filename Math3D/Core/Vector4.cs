using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StandardLibrary.Extensions;

namespace Math3D.Core
{
    public struct Vector4 : IEnumerable<double>
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double W { get; }

        public Vector4(double x, double y, double z, double w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Vector4(double[] values)
        {
            if (values.Length != 4) throw new ArgumentException();

            this.X = values[0];
            this.Y = values[1];
            this.Z = values[2];
            this.W = values[3];
        }

        public Vector4(Vector3 xyz, double w)
            : this(xyz.X, xyz.Y, xyz.Z, w)
        { }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return this.X;
                    case 1: return this.Y;
                    case 2: return this.Z;
                    case 3: return this.W;
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public static explicit operator Vector3(Vector4 vector)
            => new Vector3(vector.X / vector.W, vector.Y / vector.W, vector.Z / vector.W);

        public IEnumerator<double> GetEnumerator()
            => (new[] { this.X, this.Y, this.Z, this.W }).AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public override string ToString()
            => $"{nameof(Vector4)} ({this.X}, {this.Y}, {this.Z}, {this.W})";

        public override bool Equals(object obj)
        {
            var other = obj as Vector4?;
            if (other == null) return false;

            return this.X.EqualsAlmost(other.Value.X)
                && this.Y.EqualsAlmost(other.Value.Y)
                && this.Z.EqualsAlmost(other.Value.Z)
                && this.W.EqualsAlmost(other.Value.W);
        }
    }
}
