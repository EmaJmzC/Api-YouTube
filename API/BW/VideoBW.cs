using Abstracciones.BW;
using Abstracciones.Modelos;
using Abstracciones.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class VideoBW : IVideoBW
    {
        private IVideoSG _videoSG;

        public VideoBW(IVideoSG videoSG)
        {
            _videoSG = videoSG;
        }

        public Task<IEnumerable<Video>> Obtener(string criterio)
        {
            return _videoSG.Obtener(criterio);
        }


        public Task<Video> ObtenerporId(string id)
        {
            return _videoSG.ObtenerporId(id);
        }
    }
}
