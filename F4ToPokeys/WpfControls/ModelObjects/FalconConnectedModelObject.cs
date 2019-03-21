using F4ToPokeys.FalconModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4ToPokeys.WpfControls.ModelObjects
{
    public class FalconConnectedModelObject : INotifyPropertyChanged
    {
        private bool m_connected;

        public FalconConnectedModelObject()
        {
            FalconConnector.Singleton.FalconStarted += Singleton_FalconStarted;
            FalconConnector.Singleton.FalconStopped += Singleton_FalconStopped;

            m_connected = FalconConnector.Singleton.IsFalconRunning;
        }

        private void Singleton_FalconStopped(object sender, EventArgs e)
        {
            Connected = false;
        }

        private void Singleton_FalconStarted(object sender, EventArgs e)
        {
            Connected = true;
        }

        public bool Connected
        {
            get
            {
                return m_connected;
            }
            set
            {
                if (m_connected != value)
                {
                    m_connected = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Connected"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
