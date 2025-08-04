using System.Net;

namespace GimnasioService.Core.Response
{
    public class ResponseStatus
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Descripcion { get; set; }
    }
}
