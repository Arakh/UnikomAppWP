using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UnikomApp.ViewModels;

namespace UnikomApp.Views
{
    public partial class PagePrestasi : PhoneApplicationPage
    {
        bool isOpenNavDraw;
        double marginLeft;
        public PagePrestasi()
        {
            InitializeComponent();
            DataContext = new PrestasiViewModel();
            isOpenNavDraw = false;
            marginLeft = -400;
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

        //private void Pivot_Geser(object sender, SelectionChangedEventArgs e)
        //{
        //    PivotItem selectedItem = (PivotItem)e.AddedItems[0];
        //    String pivotTag = (String)selectedItem.Tag;
        //    if (pivotTag.Equals("satu"))
        //    {
        //        textJudul.Text = "Prestasi & Penghargaan";
        //        textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore";

        //        elip1.Visibility = Visibility.Visible;
        //        elip2.Visibility = Visibility.Collapsed;
        //        elip3.Visibility = Visibility.Collapsed;
        //        elip4.Visibility = Visibility.Collapsed;
        //        elip5.Visibility = Visibility.Collapsed;
        //        elip1_Copy.Visibility = Visibility.Collapsed;
        //        elip2_Copy.Visibility = Visibility.Visible;
        //        elip3_Copy.Visibility = Visibility.Visible;
        //        elip4_Copy.Visibility = Visibility.Visible;
        //        elip5_Copy.Visibility = Visibility.Visible;
        //    }
        //    else if (pivotTag.Equals("dua"))
        //    {
        //        textJudul.Text = "Prestasi & Penghargaan";
        //        textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore lalala";


        //        elip1.Visibility = Visibility.Collapsed;
        //        elip2.Visibility = Visibility.Visible;
        //        elip3.Visibility = Visibility.Collapsed;
        //        elip4.Visibility = Visibility.Collapsed;
        //        elip5.Visibility = Visibility.Collapsed;
        //        elip1_Copy.Visibility = Visibility.Visible;
        //        elip2_Copy.Visibility = Visibility.Collapsed;
        //        elip3_Copy.Visibility = Visibility.Visible;
        //        elip4_Copy.Visibility = Visibility.Visible;
        //        elip5_Copy.Visibility = Visibility.Visible;
        //    }
        //    else if (pivotTag.Equals("tiga"))
        //    {
        //        textJudul.Text = "Prestasi & Penghargaan";
        //        textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore lilili";


        //        elip1.Visibility = Visibility.Collapsed;
        //        elip2.Visibility = Visibility.Collapsed;
        //        elip3.Visibility = Visibility.Visible;
        //        elip4.Visibility = Visibility.Collapsed;
        //        elip5.Visibility = Visibility.Collapsed;
        //        elip1_Copy.Visibility = Visibility.Visible;
        //        elip2_Copy.Visibility = Visibility.Visible;
        //        elip3_Copy.Visibility = Visibility.Collapsed;
        //        elip4_Copy.Visibility = Visibility.Visible;
        //        elip5_Copy.Visibility = Visibility.Visible;
        //    }
        //    else if (pivotTag.Equals("empat"))
        //    {
        //        textJudul.Text = "Prestasi & Penghargaan";
        //        textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore hahaha";

        //        elip1.Visibility = Visibility.Collapsed;
        //        elip2.Visibility = Visibility.Collapsed;
        //        elip3.Visibility = Visibility.Collapsed;
        //        elip4.Visibility = Visibility.Visible;
        //        elip5.Visibility = Visibility.Collapsed;
        //        elip1_Copy.Visibility = Visibility.Visible;
        //        elip2_Copy.Visibility = Visibility.Visible;
        //        elip3_Copy.Visibility = Visibility.Visible;
        //        elip4_Copy.Visibility = Visibility.Collapsed;
        //        elip5_Copy.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        textJudul.Text = "Prestasi & Penghargaan";
        //        textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore hihihi";

        //        elip1.Visibility = Visibility.Collapsed;
        //        elip2.Visibility = Visibility.Collapsed;
        //        elip3.Visibility = Visibility.Collapsed;
        //        elip4.Visibility = Visibility.Collapsed;
        //        elip5.Visibility = Visibility.Collapsed;
        //        elip1_Copy.Visibility = Visibility.Visible;
        //        elip2_Copy.Visibility = Visibility.Visible;
        //        elip3_Copy.Visibility = Visibility.Visible;
        //        elip4_Copy.Visibility = Visibility.Visible;
        //        elip5_Copy.Visibility = Visibility.Visible;
        //    }
        //}
    }
}