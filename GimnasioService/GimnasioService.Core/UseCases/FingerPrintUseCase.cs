using GimnasioService.Core.Dtos;
using GimnasioService.Core.Interfaces.FingerPrint;
using GimnasioService.Core.Response;
using GimnasioService.Core.UseCases.Interfaces;

namespace GimnasioService.Core.UseCases
{
    public class FingerPrintUseCase : IFingerPrintUseCase
    {
        private readonly IFingerPrintProcess _fingerPrintProcess;

        public FingerPrintUseCase(IFingerPrintProcess fingerPrintProcess)
        {
            _fingerPrintProcess = fingerPrintProcess ?? throw new ArgumentNullException(nameof(fingerPrintProcess));
        }

        public async Task<GenericResponseFingerPrint<FingerPrintDto>> FingerPrintCaptureThreeTimes(CancellationToken stoppingToken) {
            return await _fingerPrintProcess.FingerPrintCaptureThreeTimes(stoppingToken);
        }
    }
}
