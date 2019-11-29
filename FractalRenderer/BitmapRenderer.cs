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
        #region Constructors

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="fractal">Initialiser for Fractal property</param>
        /// <param name="colorType">Initialiser for ColorType property</param>
        public BitmapRenderer(IFractal fractal, FractalColorType colorType)
        {
            Fractal = fractal;
            ColorType = colorType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// An instance of IFractal to be rendered
        /// </summary>
        public IFractal Fractal { get; }

        /// <summary>
        /// The color scheme to be used in the Bitmap
        /// </summary>
        public FractalColorType ColorType { get; }

        #endregion

        #region Private Methods

        private Color GetColor(int iteration, int maxIterations)
        {
            double hue;
            int color;
            switch (ColorType)
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
            value = value * 255;
            int v = (int)value;
            int p = (int)(value * (1 - saturation));
            int q = (int)(value * (1 - f * saturation));
            int t = (int)(value * (1 - (1 - f) * saturation));

            switch (hi)
            {
                case 0:
                    return Color.FromArgb(255, v, t, p);
                case 1:
                    return Color.FromArgb(255, q, v, p);
                case 2:
                    return Color.FromArgb(255, p, v, t);
                case 3:
                    return Color.FromArgb(255, p, q, v);
                case 4:
                    return Color.FromArgb(255, t, p, v);
                default:
                    return Color.FromArgb(255, v, p, q);
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
        /// <returns>Task object containing the Bitmap image</returns>
        public Task<Bitmap> Render(int height, int width, PixelFormat pixelFormat, PlotWindow plotWindow, int maxIterations)
        {
            Bitmap bitmap = new Bitmap(height, width, pixelFormat);
            double xJump = (plotWindow.RealEnd - plotWindow.RealStart) / width;
            double yJump = (plotWindow.ImagEnd - plotWindow.ImagStart) / height;

            for (int x = 0; x < width; x++)
            {
                double cx = (xJump * x) - Math.Abs(plotWindow.RealStart);

                for (int y = 0; y < height; y++)
                {
                    double cy = (yJump * y) - Math.Abs(plotWindow.ImagStart);
                    int iteration = Fractal.IterationCount(new Complex(cx, cy), maxIterations);
                    bitmap.SetPixel(x, y, GetColor(iteration, maxIterations));
                }
            }

            return Task.FromResult<Bitmap>(bitmap);
        }

        #endregion
    }
}
