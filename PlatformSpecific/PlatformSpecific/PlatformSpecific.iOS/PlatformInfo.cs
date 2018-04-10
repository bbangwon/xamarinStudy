using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace PlatInfoSap2
{
    class PlatformInfo
    {
        UIDevice device = new UIDevice();

        public string GetModel()
        {
            return device.Model.ToString();
        }

        public string GetVersion()
        {
            return string.Format("{0} {1}", device.SystemName, device.SystemVersion);
        }
    }
}
