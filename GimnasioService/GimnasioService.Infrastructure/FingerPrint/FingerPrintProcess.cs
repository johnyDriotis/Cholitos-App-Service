using GimnasioService.Core.Dtos;
using GimnasioService.Core.Interfaces.FingerPrint;
using GimnasioService.Core.Response;
using libzkfpcsharp;
using Sample;
using System.Drawing;

namespace GimnasioService.Infrastructure.FingerPrintBackground
{
    public class FingerPrintProcess : IFingerPrintProcess
    {
        private IntPtr _deviceHandle = IntPtr.Zero;
        private IntPtr _dbHandle = IntPtr.Zero;

        private int mfpWidth = 0;
        private int mfpHeight = 0;

        private byte[] imageBuffer;
        private byte[] templateBuffer = new byte[2048];
        private int templateLen = 2048;
        int RegisterCount = 0;

        public async Task<GenericResponseFingerPrint<FingerPrintDto>> FingerPrintCaptureThreeTimes(CancellationToken stoppingToken)
        {
            List<byte[]> capturedTemplates = new();
            int scanCount = 0;
            List<string> base64ImgsFingerPrint = new List<string>();

            //Inicializacion de la base de datos de ZkTeco
            _dbHandle = zkfp2.DBInit();

            Console.WriteLine("Initializing fingerprint device...");
            if (zkfperrdef.ZKFP_ERR_OK != zkfp2.Init())
            {
                // Console.WriteLine("Failed to initialize zkfp.");
                return new GenericResponseFingerPrint<FingerPrintDto>()
                {
                    IsError = true,
                    ErrorMessage = "Falló el inicio del dispositivo de huella dactilar. "
                };
            }

            int count = zkfp2.GetDeviceCount();
            if (count <= 0)
            {
                // Console.WriteLine("No fingerprint device found.");
                zkfp2.Terminate();
                return new GenericResponseFingerPrint<FingerPrintDto>()
                {
                    IsError = true,
                    ErrorMessage = "No se encontró el dispositivo de huella dactilar. "
                };
            }

            _deviceHandle = zkfp2.OpenDevice(0);
            if (_deviceHandle == IntPtr.Zero)
            {
                // Console.WriteLine("Failed to open device.");
                zkfp2.Terminate();
                return new GenericResponseFingerPrint<FingerPrintDto>()
                {
                    IsError = true,
                    ErrorMessage = "Falló al abrir el dispositivo de huella dactilar. "
                };
            }

            RegisterCount = 0;

            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(_deviceHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(_deviceHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            imageBuffer = new byte[mfpWidth * mfpHeight];

            // Se ejecuta mientras el cliente coloca tres veces la huella dactilar
            while (scanCount < 3 && !stoppingToken.IsCancellationRequested)
            {
                // Console.WriteLine($"Please scan your finger ({scanCount + 1}/3)...");
                var result = await WaitForFingerprintAsync(_deviceHandle, stoppingToken);

                if (result.Success)
                {
                    byte[] cleanTemplate = result.Template;

                    // Valida que la huella sea igual que la anterior.
                    if (scanCount > 0)
                    {
                        int score = zkfp2.DBMatch(_dbHandle, capturedTemplates[0], cleanTemplate);

                        if (score < 60)
                        {
                            zkfp2.CloseDevice(_deviceHandle);
                            zkfp2.Terminate();
                            // Console.WriteLine("Service stopped.");

                            //Console.WriteLine("Fingerprint doesn't match previous scan. Please try again. ");
                            return new GenericResponseFingerPrint<FingerPrintDto>()
                            {
                                IsError = true,
                                ErrorMessage = "Las huellas ingresadas no son iguales, por favor asegurese de colocar el mismo dedo en el dispositivo. "
                            };
                        }
                    }

                    capturedTemplates.Add(cleanTemplate);
                    scanCount++;
                }
                else
                {
                    //Console.WriteLine("Scan failed or cancelled.");
                    return new GenericResponseFingerPrint<FingerPrintDto>()
                    {
                        IsError = true,
                        ErrorMessage = "Escaneo fallido o cancelado. "
                    };
                }
            }

            foreach (var item in capturedTemplates)
            {

                MemoryStream ms = new MemoryStream();
                BitmapFormat.GetBitmap(imageBuffer, mfpWidth, mfpHeight, ref ms);

                byte[] imgBytes = ms.ToArray();

                var base64Template = Convert.ToBase64String(imgBytes);
                base64ImgsFingerPrint.Add(base64Template);
            }

            zkfp2.CloseDevice(_deviceHandle);
            zkfp2.Terminate();

            return new GenericResponseFingerPrint<FingerPrintDto>()
            {
                Item = new FingerPrintDto()
                {
                    base64ImgsFingerPrint = base64ImgsFingerPrint
                }
            };
        }

        private async Task<(bool Success, byte[] Template, byte[] ImageBuffer)> WaitForFingerprintAsync(IntPtr deviceHandle, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                while (!ct.IsCancellationRequested)
                {
                    int ret = zkfp2.AcquireFingerprint(deviceHandle, imageBuffer, templateBuffer, ref templateLen);
                    if (ret == zkfperrdef.ZKFP_ERR_OK)
                    {
                        return (true, templateBuffer.Take(templateLen).ToArray(), imageBuffer);
                    }

                    Thread.Sleep(200); // Reduce CPU load
                }

                return (false, Array.Empty<byte>(), Array.Empty<byte>());
            }, ct);
        }
    }
}
