using System;
using System.Collections.Generic;
using Particle.SDK;
using Xamarin.Forms;

namespace GoldenTeeTopperTestApp
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
			BindingContext = new HomePageViewModel();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			var success = false;
			if (App.HasProperty("device_cloud_token"))
			{
				success = await App.DeviceCloud.TokenLoginAsync((string)App.GetProperty("device_cloud_token"));
			}
			else
			{
				success = await App.DeviceCloud.LoginAsync("lestermeeks@gmail.com", "San1198$$");
			}

			if (success)
			{
				App.Properties["device_cloud_token"] = App.DeviceCloud.AccessToken;
				await App.Current.SavePropertiesAsync();
				List<ParticleDevice> devices = await ParticleCloud.SharedCloud.GetDevicesAsync();
				(BindingContext as HomePageViewModel).SetDevicesList(devices);
				App.DeviceCloud.Logout();
			}
			else
			{
				App.Properties["device_cloud_token"] = null;
			}
		}
	}
}
