using Newtonsoft.Json;
using RPlay.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace RPlay.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<ModelAngkutan> _ListAngkot;
        public List<ModelAngkutan> ListAngkot
        {
            get { return _ListAngkot; }
            set
            {
                if (_ListAngkot != value)
                {
                    _ListAngkot = value;
                    NotifyPropertyChanged("ListAngkot");
                }
            }
        }

        public async void GetAngkot()
        {
            Uri dataUri = new Uri("ms-appx:///Assets/keretaku.json");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string Text = await FileIO.ReadTextAsync(file);
            ListAngkot = JsonConvert.DeserializeObject<List<ModelAngkutan>>(Text);
        }

        public async void GetKereta()
        {
            Uri dataUri = new Uri("ms-appx:///Assets/keretaku.json");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string Text = await FileIO.ReadTextAsync(file);
            ListAngkot = JsonConvert.DeserializeObject<List<ModelAngkutan>>(Text);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}