using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace What_to_Wear.ViewModels
{
    class HomeViewModel : Screen 
    {        
        private string _txtCityName;

        public HomeViewModel()
        {
      
        }

        public string TxtCityName
        {
            get
            {
                return _txtCityName;
            }
            set
            {
                _txtCityName = value;
                NotifyOfPropertyChange(() => TxtCityName);
            }
        }

        public string DayOne
        {
            get { return $""; }
        }
        public string DayTwo
        {
            get { return $""; }
        }
        public string DayThree
        {
            get { return $""; }
        }
        public string DayFour
        {
            get { return $""; }
        }
        public string DayFive
        {
            get { return $""; }
        }

    }
}
