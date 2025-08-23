using GimnasioService.Core.Dtos;
using GimnasioService.Core.Interfaces.FingerPrint;
using GimnasioService.Core.Response;
using GimnasioService.Core.UseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GimnasioService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FingerPrintController : ControllerBase
    {
        private readonly IFingerPrintUseCase _fingerPrintUseCase;
        private readonly CancellationToken _cancellationToken;

        public FingerPrintController(IFingerPrintUseCase fingerPrintUseCase)
        {
            _fingerPrintUseCase = fingerPrintUseCase ?? throw new ArgumentNullException(nameof(fingerPrintUseCase));
        }

        [HttpPost(template: "FingerPrintCaptureThreeTimes", Name = "CapturarHuellaDactilarTresVeces")]
        public async Task<GenericResponseFingerPrint<FingerPrintDto>> FingerPrintCaptureThreeTimes()
        {
            return await _fingerPrintUseCase.FingerPrintCaptureThreeTimes(_cancellationToken);
        }
    }
}
