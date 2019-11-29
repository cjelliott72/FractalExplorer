using System;
using System.Numerics;

namespace FractalRenderer
{
    /// <summary>
    /// IFractal implementation of the BurningShip Set
    /// </summary>
    public class BurningShip : IFractal
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="maxValueExtent">Initialisation value for MaxValueExtent</param>
        public BurningShip(double maxValueExtent = 2d)
        {
            MaxValueExtent = maxValueExtent;
        }

        /// <inheritdoc/>
        public double MaxValueExtent { get; }

        /// <inheritdoc/>
        public int IterationCount(Complex c, int iterationLimit)
        {
            Complex z = Complex.Zero;
            int n = 0;

            while (Complex.Abs(z) <= MaxValueExtent && n < iterationLimit)
            {
                Complex t = new Complex(Math.Abs(z.Real), Math.Abs(z.Imaginary));
                z = Complex.Pow(t, 2d) + c;
                n++;
            }

            return n;
        }
    }
}
