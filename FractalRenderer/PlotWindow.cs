namespace FractalRenderer
{
    /// <summary>
    /// This struct encapsulates the real and imaginary coordinates for the graph a Fractal will be rendered against
    /// </summary>
    public struct PlotWindow
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="realStart">Initial value for RealStart</param>
        /// <param name="realEnd">Initial value for RealEnd</param>
        /// <param name="imagStart">Initial value for ImagStart</param>
        /// <param name="imagEnd">Initial value for ImagEnd</param>
        public PlotWindow(double realStart, double realEnd, double imagStart, double imagEnd)
        {
            RealStart = realStart;
            RealEnd = realEnd;
            ImagStart = imagStart;
            ImagEnd = imagEnd;
        }

        /// <summary>
        /// The start coordinate of the Real (x dimension) window
        /// </summary>
        public double RealStart { get; set; }
        /// <summary>
        /// The end coordinate of the Real (x dimension) window
        /// </summary>
        public double RealEnd { get; set; }
        /// <summary>
        /// The start coordinate of the Imaginary (y dimension) window
        /// </summary>
        public double ImagStart { get; set; }
        /// <summary>
        /// The end coordinate of the Imaginary (y dimension) window
        /// </summary>
        public double ImagEnd { get; set; }
    }
}
