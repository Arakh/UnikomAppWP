using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using Windows.Devices.Geolocation;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lokasi
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Map peta = new Map();
            peta.Center = new GeoCoordinate(47.6097, -122.3331);
            peta.ZoomLevel = 10;
            kontenpeta.Children.Add(peta);
            posisi();
        }

        Map peta = new Map();
        string appid = "239811944466";
        string authtoken = "AIzaSyAwhZN_lTNo9H6wV6Nv1_ltIOg14wwVCBc";

        public static class CoordinateConverter
        {
            public static GeoCoordinate ConvertGeocoordinate(Geocoordinate geocoordinate)
            {
                return new GeoCoordinate
                    (
                    geocoordinate.Latitude,
                    geocoordinate.Longitude,
                    geocoordinate.Altitude ?? Double.NaN,
                    geocoordinate.Accuracy,
                    geocoordinate.AltitudeAccuracy ?? Double.NaN,
                    geocoordinate.Speed ?? Double.NaN,
                    geocoordinate.Heading ?? Double.NaN
                    );
            }
        }
        void Road_Click(object sender, EventArgs args)
        {
            peta.CartographicMode = MapCartographicMode.Road;
        }

        void Aerial_Click(object sender, EventArgs args)
        {
            peta.CartographicMode = MapCartographicMode.Aerial;
        }

        void Hybrid_Click(object sender, EventArgs args)
        {
            peta.CartographicMode = MapCartographicMode.Hybrid;
        }

        void Terrain_Click(object sender, EventArgs args)
        {
            peta.CartographicMode = MapCartographicMode.Terrain;
        }

        void OnCenterZoom_Click(object sender, EventArgs args)
        {
            peta.Center = new GeoCoordinate(47.6097, -122.3331);
            peta.ZoomLevel = 18;
        }

        void OnAnimate_Click(object sender, EventArgs args)
        {
            peta.SetView(new GeoCoordinate(47.6097, -122.3331), 15, MapAnimationKind.Parabolic);
        }

        private void mapLoad(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = appid;
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = authtoken;
        }

        private async void posisi()
        {
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
            this.mymap.Center = myGeoCoordinate;
            this.mymap.ZoomLevel = 14;

            //penanda posisi
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = myGeoCoordinate;
            MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);
            mymap.Layers.Add(myLocationLayer);
        }
    }
}