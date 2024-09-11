using Abstracciones.API;
using Abstracciones.BW;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VideoController : ControllerBase, IVideoController
    {
        private IVideoBW _videoBW;

        public VideoController(IVideoBW videoBW)
        {
            _videoBW = videoBW;
        }
        [HttpGet("buscar/{criterio}")]
        public async Task<IActionResult> Obtener(string criterio)
        {
            return Ok(await _videoBW.Obtener(criterio));
        }
        [HttpGet("obtener/{id}")]
        public async Task<IActionResult> ObtenerporId(string id)
        {
            return Ok(await _videoBW.ObtenerporId(id));
        }
    }
}
