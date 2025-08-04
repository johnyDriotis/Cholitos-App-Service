using CholitosGymService.Core.Interfaces.FingerPrint;

namespace CholitosGymService.FingerPrintWorker.Tasks
{
    public class FingerPrintTask : BackgroundService
    {
        private readonly IFingerPrintProcess _fingerPrintProcess;

        public FingerPrintTask(IFingerPrintProcess fingerPrintProcess)
        {
            _fingerPrintProcess = fingerPrintProcess ?? throw new ArgumentNullException(nameof(fingerPrintProcess));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var a = await _fingerPrintProcess.FingerPrintCaptureThreeTimes(stoppingToken);
        }
    }
}
