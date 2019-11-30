namespace FractalRenderer
{
    /// <summary>
    /// This Dto class contains the required parameters for generating a Fractal image
    /// </summary>
    public class ParametersDto
    {
        /// <summary>
        /// Height in pixels of the output Bitmap
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Width in pixels of the output Bitmap
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Minimum (leftmost) coordinate of the x-axis to be plotted
        /// </summary>
        public double xMinimum { get; set; }
        /// <summary>
        /// Maximum (rightmost) coordinate of the x-axis to be plotted
        /// </summary>
        public double xMaximum { get; set; }
        /// <summary>
        /// Minimum (topmost) coordinate of the y-axis to be plotted
        /// </summary>
        public double yMinimum { get; set; }
        /// <summary>
        /// Maximum (bottommost) coordinate of the y-axis to be plotted
        /// </summary>
        public double yMaximum { get; set; }
        /// <summary>
        /// The break-out value, at this number of iterations no further calculations are performed
        /// </summary>
        public int MaxIterations { get; set; }
        /// <summary>
        /// The upper limit of Abs(Complex Z), beyond which the value trends towards infinity
        /// </summary>
        public double MaxValueExtent { get; set; }

        /// <summary>
        /// FractalColorType to be used in generated image
        /// </summary>
        public FractalColorType ColorType { get; set; }

        /// <summary>
        /// Name of the Fractal to be rendered
        /// </summary>
        public string FractalName { get; set; }
    }
}
