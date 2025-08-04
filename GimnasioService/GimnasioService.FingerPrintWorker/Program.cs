using GimnasioService.Core.Interfaces.FingerPrint;
using GimnasioService.FingerPrintWorker.Tasks;
using GimnasioService.Infrastructure.FingerPrintBackground;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<FingerPrintTask>();

// FingerPrint services
builder.Services.AddTransient<IFingerPrintProcess, FingerPrintProcess>();

var host = builder.Build();
host.Run();
