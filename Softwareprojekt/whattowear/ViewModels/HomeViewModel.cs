using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using whattowear.Views;

namespace whattowear.ViewModels
{
    class HomeViewModel
    {
        public ICommand ButtonCommand { get; set; }

        public HomeViewModel()
        {
            ButtonCommand = new RelayCommand(o => MainButtonClick("MainButton"));
        }

        private void MainButtonClick(object sender)
        {
            ActivatKey win2 = new ActivatKey();
            win2.Show();
        }

        private void openPreference(object sender)
        {
          //  _NavigationFrame.Navigate(new Preferences());
        }
    }
}
