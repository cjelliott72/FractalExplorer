using System.Drawing;
using System.Threading.Tasks;

namespace FractalRenderer
{
    /// <summary>
    /// Interface for Fractal Rendering Classes
    /// </summary>
    public interface IFractalRenderer
    {
        /// <summary>
        /// This Asynchronous method returns a Fractal Bitmap generated from the provided parameters
        /// </summary>
        /// <param name="parameters">ParametersDto</param>
        /// <param name="fractal">IFractal instance</param>
        /// <returns>Bitmap</returns>
        public Task<Bitmap> Render(ParametersDto parameters, IFractal fractal);
    }
}
