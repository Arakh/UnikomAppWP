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
        bool isOpenNavDraw;
        double marginLeft;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            isOpenNavDraw = false;
            marginLeft = -400;
            Map peta = new Map();
            peta.Center = new GeoCoordinate(-6.886773, 107.615392); //default 47.6097, -122.3331
            peta.ZoomLevel = 1;
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
            //Geolocator myGeolocator = new Geolocator();
            //Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            //Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            //GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
            //this.mymap.Center = myGeoCoordinate;
            this.mymap.Center = new GeoCoordinate(-6.886773, 107.615392);
            this.mymap.ZoomLevel = 17;

            //penanda posisi
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = new GeoCoordinate(-6.886773, 107.615392);
            MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);
            mymap.Layers.Add(myLocationLayer);
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavDrawer.SlideNavBarOpen.Begin();
            marginLeft = 0;
            NavDrawer.Margin = new Thickness(0, 0, 0, 0);
            isOpenNavDraw = true;
        }

        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            if (isOpenNavDraw)
            {
                NavDrawer.Margin = new Thickness(0, 0, 0, 0);
                isOpenNavDraw = false;
            }

            double temp = marginLeft + e.HorizontalChange;
            if (temp <= 0 && temp >= -400)
            {
                marginLeft += e.HorizontalChange;
                NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
            }
        }

        private void GestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            if (marginLeft >= -200)
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    while (marginLeft < 0)
                    {
                        marginLeft++;

                        NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
                    }
                });
            }
            else
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    while (marginLeft > -400)
                    {
                        marginLeft--;

                        NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
                    }
                });
            }
        }
    }
}