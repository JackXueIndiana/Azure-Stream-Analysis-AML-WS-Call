using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;
using System.IO;

namespace CreateDeviceIdentity
{
    class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=psbu20180215.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=FYMBUBh+WrZvviUDbDTjTa9GsNQdhUBtlTvhLVJwwXI=";
        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait(10);
            Console.ReadLine();
        }

        private static async Task AddDeviceAsync()
        {
            for (int i = 0; i <10; i++)
            {
                string deviceId = "Device" + i.ToString();
                //string deviceId = "Truck9";
                Console.WriteLine(deviceId);
                Device device;
                try
                {
                    device = await registryManager.AddDeviceAsync(new Device(deviceId));
                }
                catch (DeviceAlreadyExistsException)
                {
                    device = await registryManager.GetDeviceAsync(deviceId);
                }
                Console.WriteLine("Generated device " + deviceId + ", deviceIdkey: " + device.Authentication.SymmetricKey.PrimaryKey);
                StreamWriter sw = new StreamWriter("C:\\Users\\xinxue\\Desktop\\TelemetryDeviceIdKey2.txt", true);
                sw.WriteLine(deviceId + "," + device.Authentication.SymmetricKey.PrimaryKey);
                sw.Close();
            }
        }
    }
}
