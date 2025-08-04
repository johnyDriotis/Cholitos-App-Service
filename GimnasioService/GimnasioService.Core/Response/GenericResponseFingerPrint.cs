using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimnasioService.Core.Response
{
    public class GenericResponseFingerPrint<T>
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public T Item { get; set; }
    }
}
