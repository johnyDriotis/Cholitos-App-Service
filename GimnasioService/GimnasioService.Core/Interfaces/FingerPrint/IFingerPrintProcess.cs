using GimnasioService.Core.Dtos;
using GimnasioService.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimnasioService.Core.Interfaces.FingerPrint
{
    public interface IFingerPrintProcess
    {
        Task<GenericResponseFingerPrint<FingerPrintDto>> FingerPrintCaptureThreeTimes(CancellationToken stoppingToken);
    }
}
