using F4ToPokeys.FalconModule;
using F4ToPokeys.PokeysModule;
using F4ToPokeys.PololuMaestroModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace F4ToPokeys.Config
{
    public class Configuration : BindableObject, IDisposable
    {
        #region Construction/Destruction

        public Configuration()
        {
            AddPoKeysCommand = new RelayCommand(executeAddPoKeys);
            AddPololuMaestroCommand = new RelayCommand(executeAddPololuMaestro);
        }

        public void setOwner()
        {
            foreach (PoKeys poKeys in PoKeysList)
                poKeys.setOwner(this);

            foreach (PololuMaestro pololuMaestro in PololuMaestroList)
                pololuMaestro.setOwner(this);
        }

        public void Dispose()
        {
            foreach (PoKeys poKeys in PoKeysList)
                poKeys.Dispose();

            foreach (PololuMaestro pololuMaestro in PololuMaestroList)
                pololuMaestro.Dispose();
        }

        #endregion // Construction/Destruction

        #region FormatVersion
        [XmlIgnore]
        public static Version CurrentFormatVersion { get; } = new Version(1, 1);

        [XmlAttribute("formatVersion")]
        public string FormatVersion { get; set; }
        #endregion

        #region ReadFalconDataTimerIntervalMS
        public double ReadFalconDataTimerIntervalMS
        {
            get { return FalconConnector.Singleton.ReadFalconDataTimerInterval.TotalMilliseconds; }
            set { FalconConnector.Singleton.ReadFalconDataTimerInterval = TimeSpan.FromMilliseconds(value); }
        }
        #endregion

        #region PoKeysList
        public ObservableCollection<PoKeys> PoKeysList
        {
            get { return poKeysList; }
            set
            {
                poKeysList = value;
                RaisePropertyChanged("PoKeysList");
            }
        }
        private ObservableCollection<PoKeys> poKeysList = new ObservableCollection<PoKeys>();
        #endregion // PoKeysList

        #region AddPoKeysCommand
        [XmlIgnore]
        public RelayCommand AddPoKeysCommand { get; private set; }

        private void executeAddPoKeys(object o)
        {
            PoKeys poKeys = new PoKeys();
            poKeys.setOwner(this);
            PoKeysList.Add(poKeys);
        }
        #endregion // AddPoKeysCommand

        #region PololuMaestroList
        public ObservableCollection<PololuMaestro> PololuMaestroList
        {
            get { return pololuMaestroList; }
            set
            {
                pololuMaestroList = value;
                RaisePropertyChanged("PololuMaestroList");
            }
        }
        private ObservableCollection<PololuMaestro> pololuMaestroList = new ObservableCollection<PololuMaestro>();
        #endregion // PoKeysList

        #region AddPololuMaestroCommand
        [XmlIgnore]
        public RelayCommand AddPololuMaestroCommand { get; private set; }

        private void executeAddPololuMaestro(object o)
        {
            PololuMaestro pololuMaestro = new PololuMaestro();
            pololuMaestro.setOwner(this);
            PololuMaestroList.Add(pololuMaestro);
        }
        #endregion // AddPoKeysCommand
    }
}
