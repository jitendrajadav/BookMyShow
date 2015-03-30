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

        string basePath = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=";
        string key = "&key=AIzaSyD3jfeMZK1SWfRFDgMfxn_zrGRSjE7S8Vg";

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
            string photo_reference = parameter.photos != null ? parameter.photos.FirstOrDefault().photo_reference : string.Empty;
			this.Name = parameter.name;
            this.Icon = basePath + photo_reference + key;
			this.Types = parameter.types.FirstOrDefault();
			this.Lat = parameter.geometry.location.lat.ToString();
			this.Vicinity = parameter.vicinity;
		}

		#endregion
	}
}
