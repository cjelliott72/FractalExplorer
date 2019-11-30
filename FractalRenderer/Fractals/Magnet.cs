using System.Numerics;

namespace FractalRenderer.Fractals
{
    /// <summary>
    /// Magnet fractal
    /// </summary>
    public class Magnet : IFractal
    {
        /// <inheritdoc/>
        public int IterationCount(Complex z, Complex c, double maxValueExtent, int maxIterations)
        {
            int n = 0;

            while (Complex.Abs(z) <= maxValueExtent && n < maxIterations)
            {
                z = Complex.Pow((Complex.Pow(z, 2d) + (c - 1)) / (2 * z + (c - 2)), 2d);
                n++;
            }

            return n;
        }
    }
}
