using System.Numerics;

namespace FractalRenderer
{
    /// <summary>
    /// IFractal implementation of the Magnet Set
    /// </summary>
    public class Magnet : IFractal
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="maxValueExtent">Initialisation value for MaxValueExtent</param>
        public Magnet(double maxValueExtent = 2d)
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
                z = Complex.Pow((Complex.Pow(z, 2d) + (c - 1)) / (2 * z + (c - 2)), 2d);
                n++;
            }

            return n;
        }
    }
}
