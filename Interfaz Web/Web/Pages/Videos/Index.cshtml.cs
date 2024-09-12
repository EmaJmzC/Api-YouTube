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
        public string SearchTerm { get; set; }

        public async Task OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;

            if (string.IsNullOrEmpty(searchTerm))
            {
                return;
            }
            string endPoint = _configuracion.ObtenerEndPoint("ObtenerVideos");
            string url = string.Format(endPoint, searchTerm);
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, url);
            var respuesta = await cliente.SendAsync(solicitud);
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            videos = JsonSerializer.Deserialize<List<Video>>(resultado, options);
        }
    }
}
