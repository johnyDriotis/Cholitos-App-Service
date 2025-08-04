using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimnasioService.Core.Response
{
    public class GenericResponseBd<T>
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsError { get; set; }
    }
}
