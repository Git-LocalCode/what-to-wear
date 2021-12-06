using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using What_to_Wear.Models;
using WhatToWear.Data.Clothing;
using WhatToWear.Logic.Preferences;

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

        private List<Article> _ClothingArticles;
        private Dictionary<string, ClothingType> _TypePairing;

        public PreferencesViewModel()
        {
            ClothType.Add(new ClothModel { Type = "Outerwear" });
            ClothType.Add(new ClothModel { Type = "Tops" });
            ClothType.Add(new ClothModel { Type = "Headwear" });
            ClothType.Add(new ClothModel { Type = "Gloves" });
            ClothType.Add(new ClothModel { Type = "Bottoms" });
            ClothType.Add(new ClothModel { Type = "Shoes" });

            ClothTempF.Add(new ClothModel { TemperatureFrom = "40 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "35 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "30 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "25 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "20 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "15 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "10 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "5 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "0 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "-5 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "-10 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "-15 °C" });
            ClothTempF.Add(new ClothModel { TemperatureFrom = "-20 °C" });

            ClothTempT.Add(new ClothModel { TemperatureTill = "40 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "35 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "30 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "25 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "20 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "15 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "10 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "5 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "0 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "-5 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "-10 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "-15 °C" });
            ClothTempT.Add(new ClothModel { TemperatureTill = "-20 °C" });

            _ClothingArticles = PreferencesHandler.ParsePreferences(PreferencesHandler.GetPreferences());
            foreach(var article in _ClothingArticles)
            {
                int index = _ClothingArticles.IndexOf(article);
                _listCloth.Add(new ListModel() { Cloth = article.ToString(), ID = index });
            }
            _TypePairing = new Dictionary<string, ClothingType>()
            {
                ["Headwear"] = ClothingType.Headwear,
                ["Outerwear"] = ClothingType.Outerwear,
                ["Tops"] = ClothingType.Tops,
                ["Gloves"] = ClothingType.Gloves,
                ["Bottoms"] = ClothingType.Bottoms,
                ["Shoes"] = ClothingType.Shoes
            };
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

        public void SaveCloth(string _type, string _name, int _temperatureFrom = 0, int _temperatureTill = 0, bool _isWaterproof = false)
        {
            int tempt = Convert.ToInt32(SelectedTempT.TemperatureTill.Remove(SelectedTempT.TemperatureTill.IndexOf("°")));
            int tempf = Convert.ToInt32(SelectedTempF.TemperatureFrom.Remove(SelectedTempF.TemperatureFrom.IndexOf("°")));
            if (String.IsNullOrEmpty(SelectedType.Type) || String.IsNullOrEmpty(Name) || tempf > tempt)
                return;

            Article newArticle = new Article();
            newArticle.Name = Name;
            newArticle.Type = _TypePairing[SelectedType.Type];
            newArticle.Temperatures.TemperatureMax = tempt;
            newArticle.Temperatures.TemperatureMin = tempf;
            _ClothingArticles.Add(newArticle);
            PreferencesHandler.SavePreferences(PreferencesHandler.ParsePreferences(_ClothingArticles));

            string Cloth = "";
            if (IsWaterproof == true)
            {
                Cloth = SelectedType.Type + ": " + Name + ", " + SelectedTempF.TemperatureFrom + " to" + SelectedTempT.TemperatureTill + ", Waterproof";
            }
            else
            {
                Cloth = SelectedType.Type + ", " + Name + ": " + SelectedTempF.TemperatureFrom + " to" + SelectedTempT.TemperatureTill + ", not Waterproof";
            }
            ListCloth.Add(new ListModel { Cloth = Cloth, ID = _ClothingArticles.IndexOf(newArticle) });
        }

        public void DeleteCloth()
        {
            if (SelectedCloth is null)
                return;
            _ClothingArticles.RemoveAt(SelectedCloth.ID);
            PreferencesHandler.SavePreferences(PreferencesHandler.ParsePreferences(_ClothingArticles));
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
