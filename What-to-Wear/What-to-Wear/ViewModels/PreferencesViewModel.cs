using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using What_to_Wear.Models;

namespace What_to_Wear.ViewModels
{
    public class PreferencesViewModel : Screen
    {
        private string _type;
        private string _name;
        private string _temperatureFrom;
        private string _temperatureTill;
        private bool _isWaterproof;

        private ClothModel _selectedType;
        private ClothModel _selectedTempF;
        private ClothModel _selectedTempT;
        private ListModel _selectedCloth;

        private BindableCollection<ListModel> _listCloth = new BindableCollection<ListModel>();
        private BindableCollection<ClothModel> _clothType = new BindableCollection<ClothModel>();
        private BindableCollection<ClothModel> _clothTempF = new BindableCollection<ClothModel>();
        private BindableCollection<ClothModel> _clothTempT = new BindableCollection<ClothModel>();

        public PreferencesViewModel()
        {
            ClothType.Add(new ClothModel { Type = "Jacke" });
            ClothType.Add(new ClothModel { Type = "Oberteil" });
            ClothType.Add(new ClothModel { Type = "Kopfbedeckung" });
            ClothType.Add(new ClothModel { Type = "Handschuhe" });
            ClothType.Add(new ClothModel { Type = "Hosen" });
            ClothType.Add(new ClothModel { Type = "Schuhe" });

            ClothTempF.Add(new ClothModel { TemperatureFrom = "-10" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "-5" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "0" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "5" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "10" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "15" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "20" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "25" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "30" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "35" });

            ClothTempT.Add(new ClothModel { TemperatureTill = "-10" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "-5" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "0" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "5" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "10" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "15" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "20" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "25" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "30" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "35" });
        }

       
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                NotifyOfPropertyChange(() => Type);             
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string TemperatureFrom
        {
            get
            {
                return _temperatureFrom;
            }
            set
            {
                _temperatureFrom = value;
                NotifyOfPropertyChange(() => TemperatureFrom);
            }
        }

        public string TemperatureTill
        {
            get
            {
                return _temperatureTill;
            }
            set
            {
                _temperatureTill = value;
                NotifyOfPropertyChange(() => TemperatureTill);
            }
        }

        public bool IsWaterproof
        {
            get
            {
                return _isWaterproof;
            }
            set
            {
                _isWaterproof = value;
                NotifyOfPropertyChange(() => IsWaterproof);
            }
        }

        public BindableCollection<ClothModel> ClothType
        {
            get { return _clothType; }
            set { _clothType = value; }
        }

        public ClothModel SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                NotifyOfPropertyChange(() => SelectedType);
            }
        }

        public BindableCollection<ClothModel> ClothTempF
        {
            get { return _clothTempF; }
            set { _clothTempF = value; }
        }
        public ClothModel SelectedTempF
        {
            get { return _selectedTempF; }
            set
            {
                _selectedTempF = value;
                NotifyOfPropertyChange(() => SelectedTempF);
            }
        }

        public BindableCollection<ClothModel> ClothTempT
        {
            get { return _clothTempT; }
            set { _clothTempT = value; }
        }
        public ClothModel SelectedTempT
        {
            get { return _selectedTempT; }
            set
            {
                _selectedTempT = value;
                NotifyOfPropertyChange(() => SelectedTempT);
            }
        }

        public void SaveCloth(string _type, string _name, int _temperatureFrom, int _temperatureTill, bool _isWaterproof)
        {
            string Cloth = "";
            if (IsWaterproof == true)
            {
                Cloth = SelectedType.Type + ": " + Name + ", Temperatur von " + SelectedTempF.TemperatureFrom + "°C bis " + SelectedTempT.TemperatureTill + "°C, Wasserfest";
            }
            else
            {
                Cloth = SelectedType.Type + ": " + Name + ", Temperatur von " + SelectedTempF.TemperatureFrom + "°C bis " + SelectedTempT.TemperatureTill + "°C, nicht Wasserfest";
            }
            ListCloth.Add(new ListModel { Cloth = Cloth });
        }

        public void DeleteCloth()
        {
            string tw = SelectedCloth.Cloth;
            ListCloth.RemoveAt(ListCloth.IndexOf(SelectedCloth));
            
        }

        public ListModel SelectedCloth
        {
            get { return _selectedCloth; }
            set
            {
                _selectedCloth = value;
                NotifyOfPropertyChange(() => SelectedCloth);
            }
        }
        public BindableCollection<ListModel> ListCloth
        {
            get { return _listCloth; }
            set { _listCloth = value; }
        }
    }
}
