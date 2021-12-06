using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using What_to_Wear.Views;

namespace What_to_Wear.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItemAsync(new HomeViewModel());
        }

        public void Home()
        {
            ActivateItemAsync(new HomeViewModel());
        }

        public void Preferences()
        {
            ActivateItemAsync(new PreferencesViewModel());
        }

        public void ActivateKey()
        {
            ActivateKey win2 = new ActivateKey();
            win2.Show();
        }
    }
}
