using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Microsoft.VisualBasic.FileIO;
using System.Threading;

namespace SimulatedDevice
{
    class DeviceInfo
    {
        private String deviceId;
        private String deviceKey;
        private float poweroutput;
        private float fuelcomsuption;
        private float temperature;
        private DateTime eventDateTime;

        public String DeviceId
        {
            get
            {
                return deviceId;
            }

            set
            {
                deviceId = value;
            }
        }

        public float Poweroutput
        {
            get
            {
                return poweroutput;
            }

            set
            {
                poweroutput = value;
            }
        }

        public float Fuelcomsuption
        {
            get
            {
                return fuelcomsuption;
            }

            set
            {
                fuelcomsuption = value;
            }
        }

        public float Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                temperature = value;
            }
        }

        public DateTime EventDateTime
        {
            get
            {
                return eventDateTime;
            }

            set
            {
                eventDateTime = value;
            }
        }

        public string DeviceKey
        {
            get
            {
                return deviceKey;
            }

            set
            {
                deviceKey = value;
            }
        }

        public DeviceInfo(String deviceId, string deviceKey, float poweroutput, float fuelcomsuption, float temperature, DateTime eventDateTime)
        {
            this.deviceId = deviceId;
            this.deviceKey = deviceKey;
            this.fuelcomsuption = fuelcomsuption;
            this.poweroutput = poweroutput;
            this.temperature = temperature;
            this.eventDateTime = eventDateTime;
        }

        public void printMe()
        {
            Console.WriteLine("+++++++++++++++++++++");
            Console.WriteLine("deviceId: " + deviceId);
            Console.WriteLine("deviceKey: " + deviceKey);
            Console.WriteLine("poweroutput: " + poweroutput);
            Console.WriteLine("fuelcomsuption: " + fuelcomsuption);
            Console.WriteLine("temperature: " + temperature);
            Console.WriteLine("eventDateTime: " + eventDateTime);
        }
    }

    class DeviceKeys
    {
        private List<KeyValuePair<string, string>> listDevice = new List<KeyValuePair<string, string>>();

        public void Initialize()
        {
            using (TextFieldParser parser = new TextFieldParser("C:\\Users\\xinxue\\Desktop\\TelemetryDeviceIdKey2.txt"))
            {
                parser.HasFieldsEnclosedInQuotes = true;
                parser.TrimWhiteSpace = true;
                parser.Delimiters = new string[] { "," };
                int i = -1;
                while (!parser.EndOfData)
                {
                    try
                    {
                        i++;
                        string[] fieldRow = parser.ReadFields();
                        listDevice.Add(new KeyValuePair<string, string>(fieldRow[0], fieldRow[1]));
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("{0} is not a good data point");
                    }
                }

                foreach (KeyValuePair<string, string> e in listDevice)
                {
                    printMe(e);
                }

                Console.WriteLine("Total number of devices = " + listDevice.Count);
            }
        }

        public void printMe(KeyValuePair<string, string> e)
        {
            Console.WriteLine(e.Key + ", " + e.Value);
        }

        public string getDeviceKey(string deviceId)
        {
            foreach (KeyValuePair<string, string> e in listDevice)
            {
                if (e.Key == deviceId)
                    return e.Value;
            }
            return null;
        }
    }

    class Program
    {
        static string iotHubUri = "psbu20180215.azure-devices.net";
        static DeviceKeys deviceKeys = new DeviceKeys();

        static void Main(string[] args)
        {
            deviceKeys.Initialize();
            Console.ReadLine();

            Console.WriteLine("Before start Worker");
            ThreadStart testThread0Start = new ThreadStart(new Program().testThread0);
            ThreadStart testThread1Start = new ThreadStart(new Program().testThread1);
            ThreadStart testThread2Start = new ThreadStart(new Program().testThread2);
            ThreadStart testThread3Start = new ThreadStart(new Program().testThread3);
            ThreadStart testThread4Start = new ThreadStart(new Program().testThread4);
            ThreadStart testThread5Start = new ThreadStart(new Program().testThread5);
            ThreadStart testThread6Start = new ThreadStart(new Program().testThread6);
            ThreadStart testThread7Start = new ThreadStart(new Program().testThread7);
            ThreadStart testThread8Start = new ThreadStart(new Program().testThread8);
            ThreadStart testThread9Start = new ThreadStart(new Program().testThread9);

            Thread[] testThread = new Thread[10];
            testThread[0] = new Thread(testThread0Start);
            testThread[1] = new Thread(testThread1Start);
            testThread[2] = new Thread(testThread2Start);
            testThread[3] = new Thread(testThread3Start);
            testThread[4] = new Thread(testThread4Start);
            testThread[5] = new Thread(testThread5Start);
            testThread[6] = new Thread(testThread6Start);
            testThread[7] = new Thread(testThread7Start);
            testThread[8] = new Thread(testThread8Start);
            testThread[9] = new Thread(testThread9Start);

            foreach (Thread myThread in testThread)
            {
                myThread.Start();
                //myThread.Abort();
            }
            Console.WriteLine("End of Main");
            Console.ReadLine();
        }

        public void testThread0()
        {
            string deviceId = "Device0";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);

            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        public void testThread1()
        {
            string deviceId = "Device1";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        public void testThread2()
        {
            string deviceId = "Device2";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        public void testThread3()
        {
            string deviceId = "Device3";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        public void testThread4()
        {
            string deviceId = "Device4";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        public void testThread5()
        {
            string deviceId = "Device5";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        public void testThread6()
        {
            string deviceId = "Device6";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        public void testThread7()
        {
            string deviceId = "Device7";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        public void testThread8()
        {
            string deviceId = "Device8";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        /// 
        public void testThread9()
        {
            string deviceId = "Device9";
            DeviceClient deviceClient;
            string deviceKey = deviceKeys.getDeviceKey(deviceId);
            DeviceInfo aDeviceInfo = initializeDeviceInfo(deviceId, deviceKey);
            try
            {
                Console.WriteLine("Simulated device: " + deviceId);
                deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

                SendDeviceToCloudMessagesAsync(deviceClient, aDeviceInfo);

                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            Console.WriteLine();
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        private DeviceInfo initializeDeviceInfo(String deviceId, String deviceKey)
        {
            DeviceInfo aDevice = null;
            float powerOutput = GetRandomNumber(50, 100);
            float fuelComsuption = (float)(powerOutput * (1.0 + 0.5*(GetRandomNumber(0, 100) - 50) / 50.0));
            aDevice = new DeviceInfo(deviceId, deviceKey, powerOutput, fuelComsuption, GetRandomNumber(50, 200), DateTime.Now);
            
            return aDevice;
        }

        private async void SendDeviceToCloudMessagesAsync(DeviceClient deviceClient, DeviceInfo aDevice)
        {
            try
            {
                while (true)
                {
                    DateTime now = DateTime.Now;

                    var telemetryDataPoint = new
                    {
                        DeviceId = aDevice.DeviceId,
                        EventDateTime = aDevice.EventDateTime,
                        Temperature = aDevice.Temperature,
                        Poweroutput = aDevice.Poweroutput,
                        Fuelcomsuption = aDevice.Fuelcomsuption,
                    };
                    var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                    var message = new Message(Encoding.ASCII.GetBytes(messageString));

                    await deviceClient.SendEventAsync(message);
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);
                    aDevice.printMe();

                    // next location
                    aDevice.EventDateTime = now;
                    aDevice.Temperature = GetRandomNumber(50, 200);
                    float powerOutput = GetRandomNumber(50, 100);
                    float fuelComsuption = (float)(powerOutput * (1.0 + 0.5 * (GetRandomNumber(0, 100) - 50) / 50.0));
                    aDevice.Poweroutput = powerOutput;
                    aDevice.Fuelcomsuption = fuelComsuption;

                    Task.Delay(100000).Wait();
                }
            }
            catch (ArgumentException e1)
            {
                Console.WriteLine("{0}: {1}", e1.GetType().Name, e1.Message);
            }
        }
    }
}