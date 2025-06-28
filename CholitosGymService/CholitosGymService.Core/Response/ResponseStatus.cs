using System.Net;

namespace CholitosGymService.Core.Response
{
    public class ResponseStatus
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Descripcion { get; set; }
    }
}
