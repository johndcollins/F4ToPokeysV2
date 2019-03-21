using F4ToPokeys.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4ToPokeys.WpfControls.ViewModels
{
    public class FalconSamplingIntervalViewModel : INotifyPropertyChanged
    {
        public FalconSamplingIntervalViewModel()
        {
        }

        public double ReadFalconDataTimerIntervalMS
        {
            get
            {
                return ConfigHolder.Singleton.Configuration.ReadFalconDataTimerIntervalMS;
            }
            set
            {
                ConfigHolder.Singleton.Configuration.ReadFalconDataTimerIntervalMS = value;
                ConfigHolder.Singleton.Save();
                PropertyChanged(this, new PropertyChangedEventArgs("ReadFalconDataTimerIntervalMS"));
            }
        }

        public string FalconSamplingInterval => Translations.Main.FalconSamplingInterval;
        public string FalconSamplingUnit => Translations.Main.FalconSamplingUnit;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
