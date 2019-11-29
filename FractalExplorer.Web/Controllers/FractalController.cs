using FractalRenderer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace FractalExplorer.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FractalController : ControllerBase
    {
        private readonly ILogger<FractalController> _logger;
        private readonly IFractal _fractal;
        private readonly BitmapRenderer _renderer;
        private const double _maxValueExtent = 2d;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="logger">ILogger instance</param>
        public FractalController(ILogger<FractalController> logger)
        {
            _logger = logger;
            _fractal = new Mandelbrot(_maxValueExtent);
            _renderer = new BitmapRenderer(_fractal, FractalColorType.Color);
        }

        // GET: api/Fractal
        [HttpGet]
        public async Task<ActionResult<byte[]>> GetFractalImage(int height, int width, double realStart, double realEnd, double imagStart, double imagEnd, int maxIterations)
        {
            PlotWindow plotWindow = new PlotWindow(realStart, realEnd, imagStart, imagEnd);
            Bitmap bitmap = await _renderer.Render(height, width, PixelFormat.Format24bppRgb, plotWindow, maxIterations);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }
    }
}
