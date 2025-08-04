using CholitosGymService.Core.Dtos;
using CholitosGymService.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CholitosGymService.Core.Interfaces.FingerPrint
{
    public interface IFingerPrintProcess
    {
        Task<GenericResponseFingerPrint<FingerPrintDto>> FingerPrintCaptureThreeTimes(CancellationToken stoppingToken);
    }
}
