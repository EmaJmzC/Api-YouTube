using Abstracciones.Modelos;
using BC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace VistarRazor.Pages.Videos
{
    public class IndexModel : PageModel
    {
        private Configuracion _configuracion;

        public IndexModel(Configuracion configuracion)
        {
            _configuracion = configuracion;
        }
        public IList<Video> videos { get; set; } = default!;
        [HttpGet("{id}")]
        public async Task OnGet(string id)
        {
            string endPoint = _configuracion.ObtenerEndPoint("ObtenerVideos");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endPoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            videos = JsonSerializer.Deserialize<List<Video>>(resultado, options);
        }
    }
}
