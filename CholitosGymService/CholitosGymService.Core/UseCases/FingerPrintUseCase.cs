using CholitosGymService.Core.Dtos;
using CholitosGymService.Core.Interfaces.FingerPrint;
using CholitosGymService.Core.Response;
using CholitosGymService.Core.UseCases.Interfaces;

namespace CholitosGymService.Core.UseCases
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
