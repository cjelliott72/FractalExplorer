using System.Numerics;

namespace FractalRenderer.Fractals
{
    /// <summary>
    /// Tricorn Fractal
    /// </summary>
    public class Tricorn : IFractal
    {
        /// <inheritdoc/>
        public int IterationCount(Complex z, Complex c, double maxValueExtent, int maxIterations)
        {
            int n = 0;

            while (Complex.Abs(z) <= maxValueExtent && n < maxIterations)
            {
                z = Complex.Pow(z, -2d) + c;
                n++;
            }

            return n;
        }
    }
}
