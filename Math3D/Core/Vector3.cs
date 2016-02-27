using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StandardLibrary.Extensions;

namespace Math3D.Core
{
    public struct Vector3 : IEnumerable<double>
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Vector3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3(double[] values)
        {
            if (values.Length != 3) throw new ArgumentException();

            this.X = values[0];
            this.Y = values[1];
            this.Z = values[2];
        }

        public double Length => Math.Sqrt(this.LengthSquared);

        public double LengthSquared => this.X * this.X + this.Y * this.Y + this.Z * this.Z;

        public Vector3 Normalize()
        {
            return this / this.Length;
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return this.X;
                    case 1: return this.Y;
                    case 2: return this.Z;
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public IEnumerator<double> GetEnumerator()
            => (new[] { this.X, this.Y, this.Z }).AsEnumerable().GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public override string ToString()
            => $"{nameof(Vector3)} ({this.X}, {this.Y}, {this.Z})";

        public override bool Equals(object obj)
        {
            var other = obj as Vector3?;
            if (other == null) return false;

            return this.X.EqualsAlmost(other.Value.X)
                && this.Y.EqualsAlmost(other.Value.Y)
                && this.Z.EqualsAlmost(other.Value.Z);
        }

        public static Vector3 operator +(Vector3 self, Vector3 other)
        {
            return new Vector3(
                self.X + other.X, 
                self.Y + other.Y, 
                self.Z + other.Z);
        }

        public static Vector3 operator -(Vector3 self, Vector3 other)
        {
            return new Vector3(
                self.X - other.X,
                self.Y - other.Y,
                self.Z - other.Z);
        }

        public static double operator *(Vector3 self, Vector3 other)
        {
            return self.X * other.X + self.Y * other.Y + self.Z * other.Z;
        }

        public static Vector3 operator /(Vector3 vector, double scale)
        {
            return new Vector3(
                vector.X / scale,
                vector.Y / scale,
                vector.Z / scale);
        }

        public static Vector3 operator *(Vector3 vector, double scale)
        {
            return new Vector3(
                vector.X * scale,
                vector.Y * scale,
                vector.Z * scale);
        }
    }
}
