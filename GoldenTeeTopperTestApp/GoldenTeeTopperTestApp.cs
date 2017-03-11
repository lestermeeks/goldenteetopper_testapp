using System;

using Xamarin.Forms;
using Particle.SDK;
using System.Collections.Generic;

namespace GoldenTeeTopperTestApp
{
	public class App : Application
	{
		public App()
		{/*
			// The root page of your application
			var content = new ContentPage
			{
				Title = "GoldenTeeTopperTestApp",
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
						new Button{
							Text = "Login",
							Command = new Command (async (obj) => {
								
							}),
						}

					}
				}
			};
			*/
			ParticleCloud.SharedCloud.SynchronizationContext = System.Threading.SynchronizationContext.Current;
			ParticleCloud.SharedCloud.OAuthClientId = "goldenteetoppertestapp-327";
			ParticleCloud.SharedCloud.OAuthClientSecret = "3258816931652c2bdf37849b154ba9a15cea12a0";

			MainPage = new NavigationPage(new HomePage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public static ParticleCloud DeviceCloud 
		{
			get { return ParticleCloud.SharedCloud;}
		}

		public static bool HasProperty(string id)
		{
			return Application.Current.Properties.ContainsKey(id);
		}

		public static object GetProperty(string id)
		{
			if (Application.Current.Properties.ContainsKey(id))
			{
				return Application.Current.Properties[id];
			}
			return null;
		}

		public static IDictionary<string, object> Properties
		{
			get { return Application.Current.Properties; }
		}

	}
}
