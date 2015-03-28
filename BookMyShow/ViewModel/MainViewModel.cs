using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.Devices.Geolocation;
using System.Threading;

namespace BookMyShow.ViewModel
{
	class MainViewModel : INotifyPropertyChanged
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

		string[] placeList = new string[] { "food", "gym", "school", "hospital", "spa", "restaurant" };

		#region Placelist

		private List<string> _Placelist;

		public List<string> Placelist
		{
			get { return _Placelist; }
			set { _Placelist = value;
				RaisePropertyChanged("Placelist");
			}
		}


		#endregion

		#endregion

		#region Constructor
		public MainViewModel()
		{
			Placelist = new List<string>();
			Placelist.AddRange(placeList);
		} 
		#endregion
	}
}
