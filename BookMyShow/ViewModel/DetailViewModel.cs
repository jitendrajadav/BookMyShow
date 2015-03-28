using BookMyShow.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.ViewModel
{
	class DetailViewModel : INotifyPropertyChanged
	{
		#region PropertyChangedEventHandler
		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		#region Properties

		#region Icon

		private string _Icon;

		public string Icon
		{
			get { return _Icon; }
			set
			{
				_Icon = value;
				RaisePropertyChanged("Icon");
			}
		}


		#endregion

		#region Name

		private string _Name;

		public string Name
		{
			get { return _Name; }
			set
			{
				_Name = value;
				RaisePropertyChanged("Name");
			}
		}


		#endregion

		#region Types

		private string _Types;

		public string Types
		{
			get { return _Types; }
			set
			{
				_Types = value;
				RaisePropertyChanged("Types");
			}
		}


		#endregion

		#region Lat

		private string _Lat;

		public string Lat
		{
			get { return _Lat; }
			set
			{
				_Lat = value;
				RaisePropertyChanged("Lat");
			}
		}


		#endregion

		#region Vicinity

		private string _Vicinity;

		public string Vicinity
		{
			get { return _Vicinity; }
			set
			{
				_Vicinity = value;
				RaisePropertyChanged("Vicinity");
			}
		}


		#endregion

		#endregion

		#region Contructor
		public DetailViewModel()
		{

		}
		#endregion

		#region Methods
		internal void setData(Result parameter)
		{
			this.Name = parameter.name;
			this.Icon = parameter.icon;
			this.Types = parameter.types.FirstOrDefault();
			this.Lat = parameter.geometry.location.lat.ToString();
			this.Vicinity = parameter.vicinity;
		}

		internal async void getData()
		{
			var client = new HttpClient();
			string reference = "CnRmAAAAHptbeGXdEl990NE90FPiutF-tkTe4VPsr30BUF0zNDUyvKJ1sSN7go1yEHaOllFschtfWcdyWOUeioLaAHrTWPP-US99dh2c3xRWAwLqauvYauTXKX6If1OeR9-ZInRbjJ4_RVzFHTXJ4x-YvOImqBIQaILjSGdzVpyFoPYo5V67vxoUMk3QnSNh6l5kv03-NS8Zrxa7gJE";
			var result = await client.GetStringAsync(new Uri("https://maps.googleapis.com/maps/api/place/photo?maxWidth=400&photoreference=" + reference + "&key=AIzaSyD3jfeMZK1SWfRFDgMfxn_zrGRSjE7S8Vg"));
		} 
		#endregion
	}
}
