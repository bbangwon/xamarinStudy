﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAMLmarkupExtensions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SystemStaticsPage : ContentPage
	{
		public SystemStaticsPage ()
		{
			InitializeComponent ();
		}
	}
}