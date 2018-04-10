using System;
using System.Collections.Generic;
using System.Text;

namespace DisplayPlatformInfo
{
    public interface IPlatformInfo
    {
        string GetModel();
        string GetVersion();
    }
}
