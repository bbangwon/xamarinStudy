using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using DisplayPlatformInfo;

[assembly: Dependency(typeof(PlatformSpecificPCL.iOS.PlatformInfo))]
namespace PlatformSpecificPCL.iOS
{
    class PlatformInfo : IPlatformInfo
    {
        UIDevice device = new UIDevice();

        public string GetModel()
        {
            return device.Model.ToString();
        }

        public string GetVersion()
        {
            return String.Format("{0} {1}", device.SystemName, device.SystemVersion);
        }
    }
}
