﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UnikomApp.ViewModels;
using UnikomApp.UserControl;

namespace UnikomApp
{
    public partial class menujurusan : PhoneApplicationPage
    {
        bool isOpenNavDraw;
        double marginLeft;

        public static string idJenjang;
         // Constructor
        public menujurusan()
        {
            InitializeComponent();
            this.DataContext = new FakultasViewModel();
            // Set the data context of the listbox control to the sample data
            //DataContext = App.ViewModel;
            //this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PivotItem selecteditem = (PivotItem)e.AddedItems[0];
            string pivotTag = (string)selecteditem.Tag;

            if (pivotTag.Equals("1"))
            {
                DiplomaBorder.Visibility = Visibility.Visible;
                SarjanaBorder.Visibility = Visibility.Collapsed;
                PascasarjanaBorder.Visibility = Visibility.Collapsed;
                idJenjang = "1";
            }
            if (pivotTag.Equals("2"))
            {
                DiplomaBorder.Visibility = Visibility.Collapsed;
                SarjanaBorder.Visibility = Visibility.Visible;
                PascasarjanaBorder.Visibility = Visibility.Collapsed;
            }
            if (pivotTag.Equals("3"))
            {
                DiplomaBorder.Visibility = Visibility.Collapsed;
                SarjanaBorder.Visibility = Visibility.Collapsed;
                PascasarjanaBorder.Visibility = Visibility.Visible;
            }
        }

        private void Tap_selectionChanged1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }


        private void Diplomatap_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
             Grid tapping = (Grid)sender;

            if (tapping.Name.Equals("Diplomatap"))
            {
                Pivot_Control.SelectedIndex = 0;
            }
            else if (tapping.Name.Equals("Sarjanatap"))
            {
                Pivot_Control.SelectedIndex = 1;
            }
            else if (tapping.Name.Equals("Pascasarjanatap"))
            {
                Pivot_Control.SelectedIndex = 2;
            }
        }

        private void inputHandlerTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid grid = (Grid)sender;
            NavigationService.Navigate(new Uri("/JurusanPage.xaml?idFakultas="+grid.Tag.ToString(), UriKind.Relative));
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
          
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

        private void stackMenu_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavDrawer.SlideNavBarOpen.Begin();
            marginLeft = 0;
            NavDrawer.Margin = new Thickness(0, 0, 0, 0);
            isOpenNavDraw = true;
        }

        private void Taptap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavDrawer.SlideNavBarOpen.Begin();
            marginLeft = 0;
            NavDrawer.Margin = new Thickness(0, 0, 0, 0);
            isOpenNavDraw = true;
        }

    }

}
    
