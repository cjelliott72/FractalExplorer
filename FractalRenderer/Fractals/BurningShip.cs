using System;
using System.Numerics;

namespace FractalRenderer.Fractals
{
    /// <summary>
    /// BurningShip fractal
    /// </summary>
    public class BurningShip : IFractal
    {
        /// <inheritdoc/>
        public int IterationCount(Complex z, Complex c, double maxValueExtent, int maxIterations)
        {
            int n = 0;

            while (Complex.Abs(z) <= maxValueExtent && n < maxIterations)
            {
                Complex t = new Complex(Math.Abs(z.Real), Math.Abs(z.Imaginary));
                z = Complex.Pow(t, 2d) + c;
                n++;
            }

            return n;
        }
    }
}
