using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace What_to_Wear.ViewModels
{
    class ActivateKeyViewModel : Screen
    {
        private string _key;

        public ActivateKeyViewModel()
        {

        }

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                NotifyOfPropertyChange(() => Key);
            }
        }
    }
}
