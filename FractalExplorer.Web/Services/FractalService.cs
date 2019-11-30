using FractalRenderer;
using FractalRenderer.Fractals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace FractalExplorer.Web.Services
{
    /// <summary>
    /// Service class for managing the fractals and rendering
    /// </summary>
    public class FractalService
    {
        #region Member variables

        protected Dictionary<string, IFractal> fractalDictionary;
        protected IFractalRenderer fractalRenderer;

        #endregion

        #region Constructors

        /// <summary>
        /// Class Constructor
        /// </summary>
        public FractalService()
        {
            fractalRenderer = new MandelbrotRenderer();
            RegisterFractals();
        }

        #endregion

        #region Protected Methods

        protected void RegisterFractals()
        {
            fractalDictionary = new Dictionary<string, IFractal>
            {
                { "Mandelbrot", new Mandelbrot() },
                { "Tricorn", new Tricorn() },
                { "BurningShip", new BurningShip() },
                { "Magnet", new Magnet() }
            };
        }

        protected IFractal GetFractal(string key)
        {
            if (fractalDictionary.TryGetValue(key, out IFractal fractal))
            {
                return fractal;
            }
            else
            {
                throw new ArgumentException("Fractal with key '" + key + "' not found.");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Asynchronous method to return a Bitmap image rendered according to the provided parameters
        /// </summary>
        /// <param name="parameters">ParametersDto</param>
        /// <returns>Bitmap</returns>
        public async Task<Bitmap> GetFractalBitmap(ParametersDto parameters)
        {
            Bitmap bitmap = await fractalRenderer.Render(parameters, GetFractal(parameters.FractalName));

            return bitmap;
        }

        /// <summary>
        /// Asynchronous method to return a Byte[] of an image rendered according to the provided parameters
        /// </summary>
        /// <param name="parameters">ParametersDto</param>
        /// <returns>byte[]</returns>
        public async Task<byte[]> GetFractalByteArray(ParametersDto parameters)
        {
            Bitmap bitmap = await GetFractalBitmap(parameters);

            using MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Returns a list of the registered Fractals
        /// </summary>
        /// <returns>List of type string</returns>
        public List<string> GetFractalList()
        {
            return new List<string>(fractalDictionary.Keys);
        }

        #endregion
    }
}
