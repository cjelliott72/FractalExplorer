using FractalExplorer.Web.Services;
using FractalRenderer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FractalExplorer.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FractalController : ControllerBase
    {
        private readonly ILogger<FractalController> _logger;
        private readonly FractalService fractalService;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="logger">ILogger instance</param>
        public FractalController(ILogger<FractalController> logger)
        {
            _logger = logger;
            fractalService = new FractalService();
        }

        // GET: api/Fractal
        [HttpGet]
        public async Task<ActionResult<byte[]>> GetFractalImage(
            int height, int width, double realStart, double realEnd, double imagStart, double imagEnd,
            int maxIterations, FractalColorType colorType, string fractalName)
        {
            try
            {
                ParametersDto parameters = new ParametersDto
                {
                    Height = height,
                    Width = width,
                    xMinimum = realStart,
                    xMaximum = realEnd,
                    yMinimum = imagStart,
                    yMaximum = imagEnd,
                    MaxIterations = maxIterations,
                    ColorType = colorType,
                    FractalName = fractalName,
                    MaxValueExtent = 2d
                };
                return await fractalService.GetFractalByteArray(parameters);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
