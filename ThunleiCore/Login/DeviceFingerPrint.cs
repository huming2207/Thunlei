using System;

namespace ThunleiCore.Login
{
    public class DeviceFingerPrint
    {
        public DeviceFingerPrint(string deviceFingerPrintRaw, 
            string deviceFingerPrintSingature, string deviceFingerPrintChecksum)
        {
            DeviceFingerPrintRaw = deviceFingerPrintRaw;
            DeviceFingerPrintSingature = deviceFingerPrintSingature;
            DeviceFingerPrintChecksum = deviceFingerPrintChecksum;
        }

        public string DeviceFingerPrintRaw { get; set; }
        public string DeviceFingerPrintSingature { get; set; }
        public string DeviceFingerPrintChecksum { get; set; }
    }
}