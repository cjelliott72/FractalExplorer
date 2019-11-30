using System.Numerics;

namespace FractalRenderer.Fractals
{
    /// <summary>
    /// Mandelbrot fractal
    /// </summary>
    public class Mandelbrot : IFractal
    {
        /// <inheritdoc/>
        public int IterationCount(Complex z, Complex c, double maxValueExtent, int maxIterations)
        {
            int n = 0;

            while (Complex.Abs(z) <= maxValueExtent && n < maxIterations)
            {
                z = Complex.Pow(z, 2d) + c;
                n++;
            }

            return n;
        }
    }
}
