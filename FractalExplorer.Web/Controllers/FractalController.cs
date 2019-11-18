using FractalRenderer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Threading.Tasks;

namespace FractalExplorer.Web.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FractalController : ControllerBase
    {
        private readonly ILogger<FractalController> _logger;
        private readonly IFractal _fractal;
        private readonly BitmapRenderer _renderer;
        private const double _maxValueExtent = 2d;
        private const int _maxIterations = 80;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="logger">ILogger instance</param>
        public FractalController(ILogger<FractalController> logger)
        {
            _logger = logger;
            _fractal = new Mandelbrot(_maxValueExtent);
            _renderer = new BitmapRenderer(_fractal, FractalColorType.Color, _maxIterations);
        }

        // GET: api/Fractal
        [HttpGet]
        public async Task<ActionResult<Bitmap>> GetFractalBitmap(int height, int width, double realStart, double realEnd, double imagStart, double imagEnd)
        {
            PlotWindow plotWindow = new PlotWindow(realStart, realEnd, imagStart, imagEnd);
            Bitmap bitmap = await _renderer.Render(height, width, System.Drawing.Imaging.PixelFormat.Format24bppRgb, plotWindow);

            return bitmap;
        }
    }
}
