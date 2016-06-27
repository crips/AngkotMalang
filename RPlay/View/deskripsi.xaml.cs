using RPlay.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RPlay.View
{
    public sealed partial class deskripsi : Page
    {
        Library Library = new Library();
        ModelAngkutan _selected;
        public deskripsi()
        {
            this.InitializeComponent();                        
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string id = Convert.ToString(e.Parameter);
            _selected = App.ViewKereta.ListAngkot.FirstOrDefault(p => p.Id == id);
            this.DataContext = _selected;

            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    MyMap.Visibility = Visibility.Visible;
                    GetGeoPosition();
                }
                else
                {
                    MyMap.Visibility = Visibility.Collapsed;
                    MessageDialog message = new MessageDialog("Maaf, Perangkat Anda Tidak Terhubung Dengan Internet!");
                    await message.ShowAsync();                    
                }
            }
            catch (UnauthorizedAccessException)
            {
                MyMap.Visibility = Visibility.Collapsed;
                MessageDialog message = new MessageDialog("Maaf, Kami Tidak Dapat Mencari Lokasi Anda! \n Harap Ijinkan Pengecekan Lokasi Pada Perangkat Anda");
                await message.ShowAsync();                
            }
        }

        public async void GetGeoPosition()
        {
            Geopoint position = await Library.Position();
            DependencyObject marker = Library.Marker();
            MyMap.Children.Add(marker);
            MapControl.SetLocation(marker, position);
            MapControl.SetNormalizedAnchorPoint(marker, new Point(0.5, 0.5));
            MyMap.ZoomLevel = 12;
            MyMap.Center = position;
        }

        private void map_loaded(object sender, RoutedEventArgs e)
        {
            //MyMap.Center = new Geopoint(new BasicGeoposition()
            //{
            //});
        }
    }
}