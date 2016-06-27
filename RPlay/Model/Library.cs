﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace RPlay.Model
{
    public class Library
    {
        public async Task<Geopoint> Position()
        {
            return (await new Geolocator().GetGeopositionAsync()).Coordinate.Point;
        }

        public UIElement Marker()
        {
            Canvas marker = new Canvas();
            Ellipse outter = new Ellipse() { Width = 25, Height = 25 };
            outter.Fill = new SolidColorBrush(Color.FromArgb(255, 240, 240, 240));
            outter.Margin = new Thickness(-12.5, -12.5, 0, 0);
            Ellipse inner = new Ellipse() { Width = 20, Height = 20 };
            inner.Fill = new SolidColorBrush(Colors.Black);
            inner.Margin = new Thickness(-10, -10, 0, 0);
            Ellipse core = new Ellipse() { Width = 10, Height = 10 };
            core.Fill = new SolidColorBrush(Colors.White);
            core.Margin = new Thickness(-5, -5, 0, 0);
            marker.Children.Add(outter);
            marker.Children.Add(inner);
            marker.Children.Add(core);
            return marker;
        }
    }
}