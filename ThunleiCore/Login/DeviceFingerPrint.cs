using System;

namespace ThunleiCore.Login
{
    public class DeviceFingerPrint
    {
        public DeviceFingerPrint(string deviceFingerPrintRaw, 
            string deviceFingerPrintSigned, string deviceFingerPrintChecksum)
        {
            DeviceFingerPrintRaw = deviceFingerPrintRaw;
            DeviceFingerPrintSigned = deviceFingerPrintSigned;
            DeviceFingerPrintChecksum = deviceFingerPrintChecksum;
        }

        public string DeviceFingerPrintRaw { get; set; }
        public string DeviceFingerPrintSigned { get; set; }
        public string DeviceFingerPrintChecksum { get; set; }
    }
}