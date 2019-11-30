using System;
using System.Drawing;

namespace FractalRenderer
{
    /// <summary>
    /// Common helper methods for calculating or converting pixel colors
    /// </summary>
    public static class PaletteHelper
    {
        /// <summary>
        /// Gets the fractal pixel color for a given iteration
        /// </summary>
        /// <param name="iteration">Current fractal Iteration</param>
        /// <param name="maxIterations">Maximum Iterations</param>
        /// <param name="colorType">FractalColorType</param>
        /// <returns>Color</returns>
        public static Color GetColor(int iteration, int maxIterations, FractalColorType colorType)
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

        /// <summary>
        /// Returns a RGB Color for the given HSV parameters
        /// </summary>
        /// <param name="hue">Hue</param>
        /// <param name="saturation">Saturation</param>
        /// <param name="value">Value</param>
        /// <returns>Color</returns>
        public static Color GetColorFromHSV(double hue, double saturation, double value)
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
    }
}
