using BookMyShow.Common;
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
	class ListViewModel : INotifyPropertyChanged
	{
		#region Local Variable
		Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
		#endregion

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

		private List<Result> _placesList;

		public List<Result> PlaceList
		{
			get { return _placesList; }
			set { _placesList = value;
				RaisePropertyChanged("PlaceList");
			}
		}


		#endregion

		#region Constructor
		public ListViewModel()
		{

		}
		#endregion

		#region Methods
		public async void getData()
		{
			try
			{
				string value = (string)localSettings.Values["latLong"];
				string type = (string)localSettings.Values["type"];
				var client = new HttpClient();

				var result = await client.GetStringAsync(new Uri("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + value.Split(',').FirstOrDefault() + "," + value.Split(',').LastOrDefault() + "&radius=500&types=" + type + "&key=AIzaSyD3jfeMZK1SWfRFDgMfxn_zrGRSjE7S8Vg"));
				var placesList = SerializeDeserialize.Deserialize<RootObject>(result);
				PlaceList = placesList.results;
			}
			catch (Exception)
			{
				throw;
			}
		} 
		#endregion
	}
}
