using System;

namespace StandardLibrary.Extensions
{
    public static class DoubleExtensions
    {
        public const double Epsilon = 1.0e-6;

        public static bool EqualsAlmost(this double number1, double number2, double epsilon = DoubleExtensions.Epsilon)
        {
            return Math.Abs(number1 - number2) < epsilon;
        }
    }
}
