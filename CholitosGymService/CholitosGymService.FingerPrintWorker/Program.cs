using CholitosGymService.Core.Interfaces.FingerPrint;
using CholitosGymService.FingerPrintWorker.Tasks;
using CholitosGymService.Infrastructure.FingerPrintBackground;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<FingerPrintTask>();

// FingerPrint services
builder.Services.AddTransient<IFingerPrintProcess, FingerPrintProcess>();

var host = builder.Build();
host.Run();
