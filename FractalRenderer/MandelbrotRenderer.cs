using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Threading.Tasks;

namespace FractalRenderer
{
    /// <summary>
    /// This class renders fractals of the Mandelbrot set
    /// </summary>
    public class MandelbrotRenderer : IFractalRenderer
    {
        #region Public Methods

        /// <inheritdoc/>
        public Task<Bitmap> Render(ParametersDto parameters, IFractal fractal)
        {
            Bitmap bitmap = new Bitmap(parameters.Height, parameters.Width, PixelFormat.Format24bppRgb);
            double xJump = (parameters.xMaximum - parameters.xMinimum) / parameters.Width;
            double yJump = (parameters.yMaximum - parameters.yMinimum) / parameters.Height;

            for (int x = 0; x < parameters.Width; x++)
            {
                double cx = (xJump * x) - Math.Abs(parameters.xMinimum);

                for (int y = 0; y < parameters.Height; y++)
                {
                    double cy = (yJump * y) - Math.Abs(parameters.yMinimum);
                    int iteration = fractal.IterationCount(Complex.Zero, new Complex(cx, cy),parameters.MaxValueExtent, parameters.MaxIterations);
                    bitmap.SetPixel(x, y, PaletteHelper.GetColor(iteration, parameters.MaxIterations, parameters.ColorType));
                }
            }

            return Task.FromResult(bitmap);
        }

        #endregion
    }
}
