﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#if __IOS__
using UIKit;
#elif __ANDROID__
using Android.OS;
#elif WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_UWP
using Windows.Security.ExchangeActiveSyncProvisioning;
#endif

namespace PlatformSpecific
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlatInfoSap1Page : ContentPage
	{
		public PlatInfoSap1Page ()
		{
			InitializeComponent ();

#if __IOS__
            UIDevice device = new UIDevice();
            modelLabel.Text = device.Model.ToString();
            versionLabel.Text = String.Format("{0} {1}", device.SystemName, device.SystemVersion);
#elif __ANDROID__
            modelLabel.Text = String.Format("{0} {1}", Build.Manufacturer, Build.Model);
            versionLabel.Text = Build.VERSION.Release.ToString();

#elif WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_UWP
            EasClientDeviceInformation devInfo = new EasClientDeviceInformaion();
            modelLabel.Text = String.Format("{0} {1}", devInfo.SystemManufacturer, devInfo.SystemManufacturer);
            versionLabel.Text = devInfo.OperationgSystem;
#endif
        }
    }
}