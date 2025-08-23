using GimnasioService.Core.Dtos;
using GimnasioService.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimnasioService.Core.UseCases.Interfaces
{
    public interface IFingerPrintUseCase
    {
        Task<GenericResponseFingerPrint<FingerPrintDto>> FingerPrintCaptureThreeTimes(CancellationToken stoppingToken);
    }
}
