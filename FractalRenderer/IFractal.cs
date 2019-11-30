using System.Numerics;

namespace FractalRenderer
{
    /// <summary>
    /// Interface for Fractal classes
    /// </summary>
    public interface IFractal
    {
        /// <summary>
        /// Returns the number of calculated iterations below the maxValueExtent, or the maxIterations if there are too many
        /// </summary>
        /// <param name="z">Complex term z in the fractal function z =  z^2 + c</param>
        /// <param name="c">Complex term c in the fractal function z =  z^2 + c</param>
        /// <param name="maxValueExtent">The upper limit of Abs(Complex Z), beyond which the value trends towards infinity</param>
        /// <param name="maxIterations">The break-out value, at this number of iterations no further calculations are performed</param>
        /// <returns>The number of calculated iterations or the MaxIterations if there are too many</returns>
        int IterationCount(Complex z, Complex c, double maxValueExtent, int maxIterations);
    }
}
