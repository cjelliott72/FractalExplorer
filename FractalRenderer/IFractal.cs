using System.Numerics;

namespace FractalRenderer
{
    /// <summary>
    /// Interface for Fractal definition classes
    /// </summary>
    public interface IFractal
    {
        /// <summary>
        /// The upper limit of Complex Z, beyond which the value trends towards infinity
        /// </summary>
        double MaxValueExtent { get; }

        /// <summary>
        /// Returns the number of calculated iterations below the MaxValueExtent, or the IterationLimit if there are too many
        /// </summary>
        /// <param name="c">Complex C is the 'window' of coordinates in the iteration calculation</param>
        /// <param name="iterationLimit">Maximum number of calculations to attempt </param>
        /// <returns>The number of calculated iterations or the IterationLimit if there are too many</returns>
        int IterationCount(Complex c, int iterationLimit);
    }
}
