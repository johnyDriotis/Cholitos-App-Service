using libzkfpcsharp;

namespace CholitosGymService.FingerPrintBackgroundTask
{
    public class Worker : BackgroundService
    {
        private IntPtr _deviceHandle = IntPtr.Zero;

        private int mfpWidth = 0;
        private int mfpHeight = 0;

        private byte[] imageBuffer;
        private byte[] templateBuffer = new byte[2048];
        private int templateLen = 2048;
        byte[][] RegTmps = new byte[3][];
        int RegisterCount = 0;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Initializing fingerprint device...");

            if (zkfperrdef.ZKFP_ERR_OK != zkfp2.Init())
            {
                Console.WriteLine("Failed to initialize zkfp.");
                return;
            }

            int count = zkfp2.GetDeviceCount();
            if (count <= 0)
            {
                Console.WriteLine("No fingerprint device found.");
                zkfp2.Terminate();
                return;
            }

            _deviceHandle = zkfp2.OpenDevice(0);
            if (_deviceHandle == IntPtr.Zero)
            {
                Console.WriteLine("Failed to open device.");
                zkfp2.Terminate();
                return;
            }

            RegisterCount = 0;

            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }

            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(_deviceHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(_deviceHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            imageBuffer = new byte[mfpWidth * mfpHeight];

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Waiting for user to scan fingerprint...");

                var result = await WaitForFingerprintAsync(_deviceHandle, stoppingToken);

                var resul = result.Template;

                if (result.Success)
                {
                    Console.WriteLine($"Fingerprint captured! Template length: {result.Template.Length}");
                    var a = templateBuffer; // Esto es lo que voy a guardar en la base de datos.

                    break;
                    // TODO: process result.Template, result.ImageBuffer
                }
                else
                {
                    Console.WriteLine("Fingerprint capture cancelled or failed.");
                }

                await Task.Delay(1000, stoppingToken); // Optional pause before restarting loop

            }

            zkfp2.CloseDevice(_deviceHandle);
            zkfp2.Terminate();
            Console.WriteLine("Service stopped.");
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
