using F4ToPokeys.Config;
using F4ToPokeys.PokeysModule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4ToPokeys.WpfControls.ViewModels
{
    public class PokeysListViewModel : INotifyPropertyChanged
    {
        public PokeysListViewModel()
        {

        }

        public ObservableCollection<PoKeys> PokeysList => ConfigHolder.Singleton.Configuration.PoKeysList;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
