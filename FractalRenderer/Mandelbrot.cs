using System.Numerics;

namespace FractalRenderer
{
    /// <summary>
    /// IFractal implementation of the Mandelbrot Set
    /// </summary>
    public class Mandelbrot : IFractal
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="maxValueExtent">Initialisation value for MaxValueExtent</param>
        public Mandelbrot(double maxValueExtent = 2d)
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
                z = z * z + c;
                n++;
            }

            return n;
        }
    }
}
