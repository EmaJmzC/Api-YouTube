using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;

namespace BC
{
    public class Configuracion
    {
        private readonly IConfiguration _configuration;

        public Configuracion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObtenerEndPoint(string nombreEndPoint)
        {
            return _configuration.GetSection("APIEndPoints").Get<List<APIEndPoint>>().Where(e => e.Nombre == nombreEndPoint).First().Valor;
        }
        public string GetPropiedad(string propiedad)
        {
            return _configuration.GetValue<string>(propiedad);
        }
    }
}
