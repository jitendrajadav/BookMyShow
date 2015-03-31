using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.ViewModel
{
    class MapViewModel : INotifyPropertyChanged
    {
        #region Local Variable

        #endregion

        #region Properties

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

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public MapViewModel()
        {

        }

        #endregion

        #region Methods

        #endregion

    }
}
