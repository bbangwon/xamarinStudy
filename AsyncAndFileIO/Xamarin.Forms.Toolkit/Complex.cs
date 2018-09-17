﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Toolkit
{
    public struct Complex : IEquatable<Complex>, IFormattable
    {
        bool gotMagnitude, gotMagnitudeSquared;
        double magnitude, magnitudeSquared;

        public Complex(double real, double imaginary) : this()
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double Real { private set; get; }
        public double Imaginary { private set; get; }

        public double MagnitudeSquared
        {
            get
            {
                if (gotMagnitudeSquared)
                    return magnitudeSquared;

                magnitudeSquared = Real * Real + Imaginary * Imaginary;
                gotMagnitudeSquared = true;
                return magnitudeSquared;
            }
        }

        public double Magnitude
        {
            get
            {
                if (gotMagnitude)
                    return magnitude;

                magnitude = Math.Sqrt(magnitudeSquared);
                gotMagnitude = true;
                return magnitude;
            }
        }

        public static Complex operator +(Complex left, Complex right)
        {
            return new Complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }

        public static Complex operator -(Complex left, Complex right)
        {
            return new Complex(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }

        public static Complex operator *(Complex left, Complex right)
        {
            return new Complex(left.Real * right.Real - left.Imaginary * right.Imaginary,
                left.Real * right.Imaginary + left.Imaginary * right.Real);
        }

        public static bool operator ==(Complex left, Complex right)
        {
            return left.Real == right.Real && left.Imaginary == right.Imaginary;
        }

        public static bool operator !=(Complex left, Complex right)
        {
            return !(left == right);
        }

        public static implicit operator Complex(double value)
        {
            return new Complex(value, 0);
        }

        public static implicit operator Complex(int value)
        {
            return new Complex(value, 0);
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() + Imaginary.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Real.Equals(((Complex)obj).Real) && Imaginary.Equals(((Complex)obj).Imaginary);
        }

        public bool Equals(Complex other)
        {
            return Real.Equals(other) && Imaginary.Equals(other);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}i", Real, RealImaginaryConnector(Imaginary), Math.Abs(Imaginary));
        }

        public string ToString(string format)
        {
            return String.Format("{0} {1} {2}i", Real.ToString(format), RealImaginaryConnector(Imaginary), Math.Abs(Imaginary).ToString(format));
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return String.Format("{0} {1} {2}i", Real.ToString(formatProvider), RealImaginaryConnector(Imaginary), Math.Abs(Imaginary).ToString(formatProvider));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return String.Format("{0} {1} {2}i", Real.ToString(format, formatProvider), RealImaginaryConnector(Imaginary), Math.Abs(Imaginary).ToString(format, formatProvider));
        }

        string RealImaginaryConnector(double value)
        {
            return Math.Sign(value) > 0 ? "+" : "\u2013";
        }
    }
}
