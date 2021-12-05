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
            get { return $"{TxtCityName}"; }
        }
        public string DayTwo
        {
            get { return $"Test"; }
        }
        public string DayThree
        {
            get { return $"Test"; }
        }
        public string DayFour
        {
            get { return $"Test"; }
        }
        public string DayFive
        {
            get { return $"Test"; }
        }

    }
}
