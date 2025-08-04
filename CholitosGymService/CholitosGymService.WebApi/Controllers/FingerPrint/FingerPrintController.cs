using CholitosGymService.Core.Dtos;
using CholitosGymService.Core.Interfaces.FingerPrint;
using CholitosGymService.Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CholitosGymService.WebApi.Controllers.FingerPrint
{
    [Route("api/[controller]")]
    [ApiController]
    public class FingerPrintController : ControllerBase
    {
        private readonly IFingerPrintProcess _fingerPrintProcess;
        private readonly CancellationToken _cancellationToken;

        public FingerPrintController(IFingerPrintProcess fingerPrintProcess)
        {
            _fingerPrintProcess = fingerPrintProcess ?? throw new ArgumentNullException(nameof(fingerPrintProcess));
        }

        [HttpPost(template: "FingerPrintCaptureThreeTimes", Name = "CapturarHuellaDactilarTresVeces")]
        public async Task<GenericResponseFingerPrint<FingerPrintDto>> FingerPrintCaptureThreeTimes()
        {
            return await _fingerPrintProcess.FingerPrintCaptureThreeTimes(_cancellationToken);
        }
    }
}
