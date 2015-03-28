using BookMyShow.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BookMyShow.View
{
	public sealed partial class ListView : Page
	{
		ListViewModel vm;
		public ListView()
		{
			this.InitializeComponent();
			vm = new ListViewModel();
        }

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			vm.getData();
            this.DataContext = vm;
			// TODO: Prepare page for display here.

			// TODO: If your application contains multiple pages, ensure that you are
			// handling the hardware Back button by registering for the
			// Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
			// If you are using the NavigationHelper provided by some templates,
			// this event is handled for you.
		}

		private void lplacesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedValue = ((Windows.UI.Xaml.Controls.Primitives.Selector)(sender)).SelectedItem;
			Frame.Navigate(typeof(DetailView), selectedValue);
		}
	}
}
