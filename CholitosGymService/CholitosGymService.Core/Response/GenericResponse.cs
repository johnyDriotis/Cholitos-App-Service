using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CholitosGymService.Core.Response
{
    public class GenericResponse<T>
    {
        public ResponseStatus HttpResponseStatus { get; set; }
        public T Item { get; set; }
    }
}
