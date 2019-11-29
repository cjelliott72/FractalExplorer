using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Threading.Tasks;

namespace FractalRenderer
{
    /// <summary>
    /// This class renders the Fractal view in Bitmap format
    /// </summary>
    public class BitmapRenderer
    {
        #region Private Methods

        private Color GetColor(int iteration, int maxIterations, FractalColorType colorType)
        {
            double hue;
            int color;
            switch (colorType)
            {
                case FractalColorType.BlueScheme:
                    hue = 255 - iteration * 255 / maxIterations;
                    return GetColorFromHSV(hue, 1d, (iteration < maxIterations ? 1d : 0d));

                case FractalColorType.RedScheme:
                    hue = 255 * iteration / maxIterations;
                    return GetColorFromHSV(hue, 1d, (iteration < maxIterations ? 1d : 0d));

                case FractalColorType.BlackAndWhite:
                default:
                    hue = 255 - iteration * 255 / maxIterations;
                    color = (int)hue;
                    return Color.FromArgb(color, color, color);
            }
        }

        private Color GetColorFromHSV(double hue, double saturation, double value)
        {
            int hi = (int)Math.Floor(hue / 60) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);
            value *= 255;
            int v = (int)value;
            int p = (int)(value * (1 - saturation));
            int q = (int)(value * (1 - f * saturation));
            int t = (int)(value * (1 - (1 - f) * saturation));

            return hi switch
            {
                0 => Color.FromArgb(255, v, t, p),
                1 => Color.FromArgb(255, q, v, p),
                2 => Color.FromArgb(255, p, v, t),
                3 => Color.FromArgb(255, p, q, v),
                4 => Color.FromArgb(255, t, p, v),
                _ => Color.FromArgb(255, v, p, q),
            };
        }

        private IFractal GetFractal(FractalSetType fractalType)
        {
            switch(fractalType)
            {
                case FractalSetType.BurningShip:
                    return new BurningShip();
                case FractalSetType.Magnet:
                    return new Magnet();
                case FractalSetType.Tricorn:
                    return new Tricorn();
                case FractalSetType.Mandelbrot:
                default:
                    return new Mandelbrot();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This asynchronous method will render the Fractal Bitmap using the coordinates provided in the PlotWindow struct
        /// </summary>
        /// <param name="height">Height in pixels of the output Bitmap</param>
        /// <param name="width">Width in pixels of the output Bitmap</param>
        /// <param name="pixelFormat">Specifies the System.Drawing.Imaging pixel format for Bitmap pixel colors</param>
        /// <param name="plotWindow">PlotWindow struct containing the real and imaginary coordinates the Fractal should be plotted against</param>
        /// <param name="maxIterations">The maximum number of iterations to be calculated for each pixel. Higher values will produce more fine detail but will take longer to calculate</param>
        /// <param name="colorType">FractalColorType to be used in generated image</param>
        /// <param name="fractalType">Fractal formula to be used in calculated image</param>
        /// <returns>Task object containing the Bitmap image</returns>
        public Task<Bitmap> Render(int height, int width, PixelFormat pixelFormat, PlotWindow plotWindow, int maxIterations, FractalColorType colorType, FractalSetType fractalType)
        {
            Bitmap bitmap = new Bitmap(height, width, pixelFormat);
            double xJump = (plotWindow.RealEnd - plotWindow.RealStart) / width;
            double yJump = (plotWindow.ImagEnd - plotWindow.ImagStart) / height;
            IFractal fractal = GetFractal(fractalType);

            for (int x = 0; x < width; x++)
            {
                double cx = (xJump * x) - Math.Abs(plotWindow.RealStart);

                for (int y = 0; y < height; y++)
                {
                    double cy = (yJump * y) - Math.Abs(plotWindow.ImagStart);
                    int iteration = fractal.IterationCount(new Complex(cx, cy), maxIterations);
                    bitmap.SetPixel(x, y, GetColor(iteration, maxIterations, colorType));
                }
            }

            return Task.FromResult(bitmap);
        }

        #endregion
    }
}
