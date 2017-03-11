using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Particle.SDK;

namespace GoldenTeeTopperTestApp
{
	public class ParticleDeviceViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void InvokePropertyChanged([CallerMemberName] string propertyName = null)
		{
			var evt = PropertyChanged;

			if (evt != null && propertyName != null)
			{
				evt.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public string Name { get; set; }
		public string ID { get; set; }
		public string Platform { get; set; }
		private bool _connected = false;
		public bool Connected { 
			get { return _connected; }
			set
			{
				if (_connected != value)
				{
					_connected = value;
					InvokePropertyChanged();
				}
			}
		}

		public static implicit operator ParticleDeviceViewModel(ParticleDevice d)
		{
			return new ParticleDeviceViewModel { Name = d.Name, ID = d.Id, Platform = d.KnownPlatformId.ToString()};
		}
	}

	public class HomePageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void InvokePropertyChanged([CallerMemberName] string propertyName = null)
		{
			var evt = PropertyChanged;

			if (evt != null && propertyName != null)
			{
				evt.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public ObservableCollection<ParticleDeviceViewModel> ItemsSource
		{
			get; set;
		}

		private string _selectedItem;
		public string SelectedItem
		{
			get { return _selectedItem; }
			set {
				_selectedItem = value;
				InvokePropertyChanged();
			}
		
		}

		public HomePageViewModel()
		{
			ItemsSource = new ObservableCollection<ParticleDeviceViewModel>();
		}

		public void SetDevicesList(List<ParticleDevice> devices)
		{
			ItemsSource.Clear();

			if (devices != null)
			{
				foreach (var device in devices)
				{
					ItemsSource.Add(device);
				}
			}
			
		}

	}
}
